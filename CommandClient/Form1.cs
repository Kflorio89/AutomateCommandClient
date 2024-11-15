using Newtonsoft.Json;
using SocketAsync;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandClient
{
    public partial class CommandClient : Form
    {
        private string _ipAddress;
        private string _port;
        private string _message;
        private object _reportLock;
        private string _result;
        private const string LOG_SEPARATOR = "********************************************";
        private SocketClient _client;
        private JsonReport _jReport;
        private bool _closing;
        private List<string> _commandList;
        private bool _runCommandList = false;

        public JsonReport JReport
        {
            get
            {
                return _jReport;
            }
            set
            {
                AccessJsonReport(_jReport);
            }
        }

        // returns the success of the report and updates the report if passed in
        private string AccessJsonReport(JsonReport jsonReport = null)
        {
            lock (_reportLock)
            {
                if (jsonReport != null)
                {
                    _jReport = jsonReport;
                    //_reportUpdated = true;
                }

                if (_jReport != null)
                {
                    return _jReport.success;
                }
                return "N/A";
            }
        }

        public CommandClient()
        {
            InitializeComponent();
            InitializeClient();
            _closing = false;
            _jReport = null;
            _reportLock = new object();
            _commandList = new List<string>();
            _result = "";
            IPadd.Text = "127.0.0.2";
            Port.Text = "23001";
            txtSLPath.Text = @"C:\Program Files\3D Infotech\Streamline\Streamline.exe";
            //InputBox.Text = "Command:RunProgram, Part:Test1, Program:Test1_Program, Serial Number:1_7, Order Number:331020201231032, Operator Name:test, Operator Contact:1513454333";
            InputBox.Text = "Command:RunProgram, Part:!!Testing, Program:AutoTest, Serial Number:8";
            LogText("Application Started.");
        }
        // Command:RunProgram, Part:Test1, Program:Test1_Program, Serial Number:AR4198, Order Number:OC0175,  Operator Name:Joe

        ~CommandClient()
        {
            DisposeClient();
        }

        private bool InitializeClient()
        {
            try
            {
                DisposeClient();
                _client = new SocketClient();
                _client.RaiseTextReceivedEvent += HandleTextReceived;
                _client.RaiseMessageReceivedEvent += HandleMessage;
            }
            catch (Exception ex)
            {
                LogText($"Exception thrown: {ex.Message}");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns true if client was disposed
        /// </summary>
        /// <returns></returns>
        private bool DisposeClient()
        {
            try
            {
                if (_client != null)
                {
                    _client.RaiseTextReceivedEvent -= HandleTextReceived;
                    _client.RaiseMessageReceivedEvent -= HandleMessage;
                    _client.CloseAndDisconnect();
                    _client = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogText($"Exception thrown: {ex.Message}");
                _client = null;
            }
            return false;
        }

        private async void ConnectBtn_Click(object sender, EventArgs e)
        {
            await ConnectToHost();
        }

        private async Task<bool> ConnectToHost()
        {
            try
            {
                InitializeClient();
                if (IPadd.Text.Trim() == "")
                {
                    MessageBox.Show("IP Address cannot be empty.");
                    return false;
                }
                if (Port.Text.Trim() == "")
                {
                    MessageBox.Show("Port cannot be empty.");
                    return false;
                }
                _ipAddress = IPadd.Text.Trim();
                _port = Port.Text.Trim();

                if (!_client.SetServerIPAddress(_ipAddress) || !_client.SetPortNumber(_port))
                {
                    LogText(Environment.NewLine);
                    Console.ReadKey();
                    return false;
                }

                await ConnectToServerAsync();
                return true;
            }
            catch (Exception ex)
            {
                LogText($"Exception thrown: {ex.Message}");
                return false;
            }
        }

        private async void SendJson_Click(object sender, EventArgs e)
        {
            await SendCommand();
        }

        private async Task<bool> SendCommand(string cmd = "")
        {
            try
            {
                if (_client != null)
                {
                    if (string.IsNullOrWhiteSpace(cmd))
                    {
                        _message = InputBox.Text.Trim();
                        if (_message == "")
                        {
                            MessageBox.Show($"{InputLabel.Text} field is empty.");
                            return false;
                        }
                    }
                    else
                    {
                        _message = cmd;
                    }
                    string json = StringToJSON(_message);
                    LogText("Sent JSON: " + json);
                    await _client.SendToServer(json);
                    return true;
                }
                else
                {
                    LogText($"Client is not connected.");
                }
            }
            catch (Exception ex)
            {
                LogText($"Exception thrown: {ex.Message}");
            }
            return false;
        }

        private string StringToJSON(string message)
        {
            // Parse string for items

            RunProgram SLcommand = ConvertStringToObject(message);

            return JsonConvert.SerializeObject(SLcommand);
        }

        /// <summary>
        /// Populate RunProgram Object with => 
        /// Command:RunProgram, Part:PartName, Program:ProgramName, UserInputName1:Value, UserInputName2:Value, UserInputName3:Value, etc. 
        /// Assuming proper formatting prior to calling this function
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private RunProgram ConvertStringToObject(string message)
        {
            string[] pages = message.Split(',');
            RunProgram RP = new RunProgram();

            for (int i = 0; i < pages.Length; ++i)
            {
                string[] Split = pages[i].Split(':');
                switch (Split[0].ToLower().Trim())
                {
                    case "command":
                        RP.Command = Split.Length > 1 ? Split[1].Trim() : "N/A";
                        break;

                    case "part":
                        RP.PartName = Split.Length > 1 ? Split[1].Trim() : "N/A";
                        break;

                    case "program":
                        RP.ProgramName = Split.Length > 1 ? Split[1].Trim() : "N/A";
                        break;

                    // Should be all userinputs in here
                    default:
                        string[] uiSplit = pages[i].Split(':');
                        if (uiSplit.Length > 1)
                        {
                            RP.AddUserInput(uiSplit[0].Trim(), uiSplit[1].Trim());
                        }
                        break;
                }
            }
            return RP;
        }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            LogBox.Clear();
        }

        private void HandleTextReceived(object sender, TextReceivedEventArgs trea)
        {
            LogText(string.Format("{0} - Received {1}{2}", DateTime.Now, trea.TextReceived, Environment.NewLine));
        }

        private void HandleMessage(object sender, MessageReceivedEventArgs mrea)
        {
            if (mrea != null && mrea.Message.Contains("Received bytes:"))
            {
                try
                {
                    string[] nstr = mrea.Message.Split('{', '}');
                    if (nstr.Length >= 2)
                    {
                        string success = nstr[1].Split(':')[1].Split('\"')[1];
                        LogText($"Json response: {success}");
                        _result = success;
                    }
                    else
                    {
                        LogText($"JsonReport is null in handlemessage.");
                    }
                }
                catch (Exception ex)
                {
                    LogText($"Handle Message Exception: {ex.Message}");
                }
            }
            else
            {
                if (mrea.Message.Length > 50)
                {
                    LogText($"Trimmed Response: {mrea.Message.Substring(0, 50)}");
                }
                else
                {
                    LogText("Response: " + mrea.Message);
                }
            }
        }

        private async Task ConnectToServerAsync()
        {
            try
            {
                await _client.ConnectToServer();
            }
            catch (Exception ex)
            {
                LogText($"Exception: {ex.Message}");
                _client.CloseAndDisconnect();
                _client = null;
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (chkAutomate.Checked)
            {
                new Thread(AutomateCommands).Start();
            }
            else
            {
                StartApplication();
            }
        }

        private bool StartApplication()
        {
            string path = txtSLPath.Text.Trim();

            try
            {
                if (File.Exists(path))
                {
                    LogText($"Validated path, checking processes.");
                    // Check if app is running
                    Process[] processes = Process.GetProcessesByName("Streamline");
                    if (processes == null || processes.Length == 0)
                    {
                        // SL is not running
                        LogText($"Streamline is not running, launching now.");

                        ProcessStartInfo psi = new ProcessStartInfo(path)
                        {
                            Verb = "runas"
                        };
                        Process.Start(psi);

                        Thread.Sleep(100);
                        processes = Process.GetProcessesByName("Streamline");

                        bool loading = true;
                        while (loading)
                        {
                            Thread.Sleep(100);
                            loading = processes[processes.Length - 1].MainWindowHandle == IntPtr.Zero;
                        }
                        LogText($"Streamline loaded.");
                        return true;
                    }
                    else
                    {
                        LogText($"Streamline is currently running.");

                    }
                }
                else
                {
                    LogText($"File path: {path} does not exist.");
                }
            }
            catch (Exception ex)
            {
                LogText($"Exception: {ex.Message}");
            }
            return false;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopApplication();
        }

        private void StopApplication()
        {
            Process[] processes = Process.GetProcessesByName("Streamline");
            try
            {
                if (processes == null || processes.Length == 0)
                {
                    LogText($"Streamline is not running.");
                }
                else
                {
                    processes[processes.Length - 1].Kill();
                    LogText($"Stopping Streamline process.");
                }
            }
            catch (Exception ex)
            {
                LogText($"Exception thrown when stopping Streamline: {ex.Message}.");
            }
            finally
            {
                if (_client != null)
                {
                    _client.CloseAndDisconnect();
                    _client = null;
                }
            }
        }

        private void SaveLogFile()
        {
            try
            {
                string Logs = Environment.NewLine + LOG_SEPARATOR + DateTime.Now.ToString() + Environment.NewLine + LogBox.Text.Trim() + Environment.NewLine + LOG_SEPARATOR + Environment.NewLine;
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                File.AppendAllText(Path.Combine(path, "Logs.txt"), Logs);
                LogBox.Clear();
            }
            catch (Exception ex)
            {
                LogText($"Exception thrown saving log file. {ex.Message}");
            }
        }

        private void AutomateCommands()
        {
            string loadTime = txtLoadTime.Text.Trim();
            if (!int.TryParse(loadTime, out int LT))
            {
                LT = 10000;
            }

            string fillerTime = txtFillerTime.Text.Trim();
            if (!int.TryParse(fillerTime, out int FT))
            {
                FT = 1000;
            }

            string programTime = txtProgramRun.Text.Trim();
            if (!int.TryParse(programTime, out int PT))
            {
                PT = 10000;
            }
            bool error = false;
            while (!_closing && !error)
            {
                /*
                #region First Idea               
                try
                {
                    bool rslt = false;
                    LogBox.Text += $"Before starting app in AutomateCommands" + Environment.NewLine;
                    // Start Applicaiton
                    rslt = StartApplication();
                    while (!rslt)
                    {
                        LogBox.Text += $"Start Application has failed, trying again..." + Environment.NewLine;
                        try
                        {
                            Thread.Sleep(500);
                            StopApplication();
                            Thread.Sleep(500);
                            rslt = StartApplication();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Exception: {ex.Message} {Environment.NewLine}");
                            rslt = false;
                        }
                    }

                    LogBox.Text += $"Before Connecting to Host app in AutomateCommands" + Environment.NewLine;
                    // Connect to application
                    Thread.Sleep(LT);
                    rslt = ConnectToHost().Result;

                    while (!rslt)
                    {
                        LogBox.Text += $"Connecting to Host has failed, trying again..." + Environment.NewLine;
                        try
                        {
                            Thread.Sleep(500);
                            rslt = ConnectToHost().Result;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Exception: {ex.Message} {Environment.NewLine}");
                            rslt = false;
                        }
                    }

                    LogBox.Text += $"Before Sending command to Host app in AutomateCommands" + Environment.NewLine;
                    // Send Message to SL
                    rslt = SendCommand().Result;
                    while (!rslt)
                    {
                        Thread.Sleep(500);
                        rslt = SendCommand().Result;
                    }

                    LogBox.Text += $"Before Checking report updated in AutomateCommands" + Environment.NewLine;
                    Thread.Sleep(5000);
                    // Wait for report update from SL
                    while (string.IsNullOrWhiteSpace(_result))
                    {
                        LogBox.Text += "Waiting on response." + Environment.NewLine;
                        Thread.Sleep(1000);
                    }
                    LogBox.Text += $"Report update: {_result}";
                    _result = "";
                    LogBox.Text += $"Before Stopping application in AutomateCommands" + Environment.NewLine;
                    StopApplication();
                    Thread.Sleep(1000);
                    SaveLogFile();
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    LogBox.Text += $"Exception: {ex.Message}" + Environment.NewLine;
                    Thread.Sleep(1000);
                }

                #endregion
                */
                #region RAW AF RUN
                try
                {
                    LogText($"Starting application.");
                    StartApplication();

                    Thread.Sleep(LT);

                    //LogText($"Connecting to Host.");
                    //ConnectToHost();

                    //Thread.Sleep(FT);

                    LogText($"Sending Command.");
                    SendCommand();

                    Thread.Sleep(PT);

                    LogText($"Checking report updated.");
                    while (string.IsNullOrWhiteSpace(_result))
                    {
                        Thread.Sleep(FT);
                        LogText($"Report not updated yet....");
                    }
                    LogText($"Result of run: {_result}");
                    _result = "";
                    /*StopApplication();
                    Thread.Sleep(500);
                    SaveLogFile();
                    */
                    Thread.Sleep(FT);
                }
                catch (Exception ex)
                {
                    LogText($"Exception in automate: {ex.Message}");
                    error = true;
                }
                #endregion
            }
        }

        private void LogText(string log)
        {
            if (LogBox.InvokeRequired)
            {
                LogBox.Invoke(new Action(() => LogBox.Text += log + Environment.NewLine));
            }
            else
            {
                LogBox.Text += log + Environment.NewLine;
            }
        }

        /// <summary>
        /// Pings host
        /// </summary>
        /// <param name="nameOrAddress">IP Address of Device</param>
        /// <returns>True/False == pingable</returns>
        public static bool PingHost(string nameOrAddress)
        {
            //_detail?.Debug("In PingHost().");
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress, 100);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                Console.WriteLine($"Exception: {ex.Message} {Environment.NewLine}");
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        /// <summary>
        /// StreamLine Command class
        /// </summary>
        public class RunProgram
        {
            public string Command;
            public string PartName;
            public string ProgramName;
            public List<UserInput> UserInputs;

            public RunProgram()
            {
                PartName = "N/A";
                ProgramName = "N/A";
                UserInputs = new List<UserInput>();
            }

            public RunProgram(string command, string partname, string programname, List<UserInput> userinputs)
            {
                Command = command;
                PartName = partname;
                ProgramName = programname;
                UserInputs.AddRange(userinputs);
            }
            public void AddUserInput(string inputname, string inputvalue)
            {
                UserInputs.Add(new UserInput(inputname, inputvalue));
            }
        }

        public class UserInput
        {
            public string InputName;
            public string InputValue;

            public UserInput(string inputname, string inputvalue)
            {
                InputName = inputname;
                InputValue = inputvalue;
            }
        }

        public class JsonReport
        {
            public string success;
            public string message;


            public JsonReport(string suc, string mess)
            {
                success = suc;
                message = mess;
            }
        }

        private void CommandClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;
            DisposeClient();
        }

        private void BtnAddToList_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputBox.Text))
            {
                _commandList.Add(InputBox.Text.Trim());
            }
            UpdateCommandListBox();
        }

        private void BtnClearList_Click(object sender, EventArgs e)
        {
            _commandList.Clear();
            UpdateCommandListBox();
        }

        private void BtnRemoveAt_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(removeAtIndex.Text, out int rslt))
                {
                    if (_commandList.Count >= rslt && rslt > 0)
                    {
                        _commandList.RemoveAt(rslt - 1);
                    }
                    else
                    {
                        LogText($"Error index: {rslt} not in range");
                    }
                }
                else
                {
                    LogText($"Error, index not recognized as number");
                }
            }
            catch (Exception ex)
            {
                LogText($"Exception removing element from command list: {ex.Message}");
            }
            UpdateCommandListBox();
        }

        private void UpdateCommandListBox()
        {
            inputList.Clear();
            for (int i = 0; i < _commandList.Count; i++)
            {
                if (inputList.InvokeRequired)
                {
                    inputList.Invoke(new Action(() => inputList.Text += $"{i + 1}: {_commandList[i]}" + Environment.NewLine));
                }
                else
                {
                    inputList.Text += $"{i + 1}: {_commandList[i]}" + Environment.NewLine;
                }
            }
        }

        private void BtnStartLoopList_Click(object sender, EventArgs e)
        {
            if (_runCommandList)
            {
                LogText("Command List is running currently.");
            }
            else
            {
                _runCommandList = true;
                Task.Run(() => RunCommandList());
            }
        }

        private void RunCommandList()
        {
            bool error = false;
            int currentIndex = 0;
            if (_commandList?.Count > 0)
            {
                while (_runCommandList && !_closing && !error)
                {
                    try
                    {
                        if (currentIndex >= _commandList.Count)
                        {
                            currentIndex = 0;
                        }
                        LogText($"Sending Command.");
                        SendCommand(_commandList[currentIndex]);

                        Thread.Sleep(1000);

                        LogText($"Checking report...");
                        while (string.IsNullOrWhiteSpace(_result))
                        {
                            Thread.Sleep(1000);
                            LogText($"Report not updated yet....");
                        }
                        LogText($"Result of run: {_result}");
                        _result = "";
                        currentIndex++;
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        LogText($"Exception thrown running command list: {ex.Message}");
                        error = true;
                    }
                }
            }
            else
            {
                LogText("Error command list is empty.");
            }

            LogText($"Ending command list loop. run command list: {_runCommandList}, closing: {_closing}, error: {error}, current index: {currentIndex} ");
            _runCommandList = false;
        }

        private void BtnStopLoopList_Click(object sender, EventArgs e)
        {
            _runCommandList = false;
        }

        public static bool IsProcessRunning(string processName)
        {
            // Get all processes with the specified name
            Process[] processes = Process.GetProcessesByName(processName);

            // Check if any process with the specified name is running
            return processes.Length > 0;
        }

        private void RestartStreamline_Click(object sender, EventArgs e)
        {
            LogText($"Restarting Streamline...");
            try
            {
                StopApplication();

                while (IsProcessRunning("streamline"))
                {
                    Thread.Sleep(100);
                }

                StartApplication();
            }
            catch (Exception ex)
            {
                LogText($"Exception thrown when restarting Streamline: {ex.Message}.");
            }
        }
    }
}