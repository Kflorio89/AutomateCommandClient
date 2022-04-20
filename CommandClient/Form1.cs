using Newtonsoft.Json;
using SocketAsync;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
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
        private SocketClient client;
        private JsonReport _jReport;
        private bool _closing;

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
            _result = "";
            IPadd.Text = "127.0.0.2";
            Port.Text = "23001";
            txtSLPath.Text = @"C:\Program Files\3D Infotech\Streamline\Streamline.exe";
            //InputBox.Text = "Command:RunProgram, Part:Test1, Program:Test1_Program, Serial Number:1_7, Order Number:331020201231032, Operator Name:test, Operator Contact:1513454333";
            InputBox.Text = "Command:RunProgram, Part:!!Testing, Program:JointposeTest";
            LogBox.Text = "Application Started." + Environment.NewLine;
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
                client = new SocketClient();
                client.RaiseTextReceivedEvent += HandleTextReceived;
                client.RaiseMessageReceivedEvent += HandleMessage;
            }
            catch (Exception ex)
            {
                LogBox.Text += $"Exception thrown: {ex.Message}" + Environment.NewLine;
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
                if (client != null)
                {
                    client.RaiseTextReceivedEvent -= HandleTextReceived;
                    client.RaiseMessageReceivedEvent -= HandleMessage;
                    client.CloseAndDisconnect();
                    client = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBox.Text += $"Exception thrown: {ex.Message}" + Environment.NewLine;
                client = null;
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

                if (!client.SetServerIPAddress(_ipAddress) || !client.SetPortNumber(_port))
                {
                    LogBox.Text += Environment.NewLine + (string.Format("Wrong IP Address or Port Number entered - {0} - {1} - press key to exit", _ipAddress, _port));
                    Console.ReadKey();
                    return false;
                }

                await ConnectToServerAsync();
                return true;
            }
            catch (Exception ex)
            {
                LogBox.Text += $"Exception thrown: {ex.Message}" + Environment.NewLine;
                return false;
            }
        }

        private async void SendJson_Click(object sender, EventArgs e)
        {
            await SendCommand();
        }

        private async Task<bool> SendCommand()
        {
            try
            {
                if (client != null)
                {
                    _message = InputBox.Text.Trim();
                    if (_message == "")
                    {
                        MessageBox.Show($"{InputLabel.Text} field is empty.");
                        return false;
                    }

                    string json = StringToJSON(_message);
                    LogBox.Text += "Sent JSON: " + json + Environment.NewLine;
                    await client.SendToServer(json);
                    return true;
                }
                else
                {
                    LogBox.Text += $"Client is not connected." + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                LogBox.Text += $"Exception thrown: {ex.Message}" + Environment.NewLine;
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
            LogBox.Text += (string.Format("{0} - Received {1}{2}", DateTime.Now, trea.TextReceived, Environment.NewLine));
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
                        LogBox.Text += $"Json response: {success}";
                        _result = success;
                    }
                    else
                    {
                        LogBox.Text += $"JsonReport is null in handlemessage." + Environment.NewLine;
                    }
                }
                catch (Exception ex)
                {
                    LogBox.Text += $"Handle Message Exception: {ex.Message}" + Environment.NewLine;
                }
            }
            else
            {
                if (mrea.Message.Length > 50)
                {
                    LogBox.Text += $"Trimmed Response: {mrea.Message.Substring(0, 50)}" + Environment.NewLine;
                }
                else
                {
                    LogBox.Text += "Response: " + mrea.Message + Environment.NewLine;
                }
            }
        }

        private async Task ConnectToServerAsync()
        {
            try
            {
                await client.ConnectToServer();
            }
            catch (Exception ex)
            {
                LogBox.Text += $"Exception: {ex.Message} {Environment.NewLine}";
                client.CloseAndDisconnect();
                client = null;
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
                    LogBox.Text += $"Validated path, checking processes." + Environment.NewLine;
                    // Check if app is running
                    Process[] processes = Process.GetProcessesByName("Streamline");
                    if (processes == null || processes.Length == 0)
                    {
                        // SL is not running
                        LogBox.Text += $"Streamline is not running, launching now." + Environment.NewLine;

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
                        LogBox.Text += $"Streamline loaded." + Environment.NewLine;
                        return true;
                    }
                    else
                    {
                        LogBox.Text += $"Streamline is currently running." + Environment.NewLine;

                    }
                }
                else
                {
                    LogBox.Text += $"File path: {path} does not exist." + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                LogBox.Text += $"Exception: {ex.Message}" + Environment.NewLine;
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
                    LogBox.Text += $"Streamline is not running." + Environment.NewLine;
                }
                else
                {
                    processes[processes.Length - 1].Kill();
                    LogBox.Text += $"Stopping Streamline process." + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                LogBox.Text += $"Exception thrown when stopping Streamline: {ex.Message}." + Environment.NewLine;
            }
            finally
            {
                if (client != null)
                {
                    client.CloseAndDisconnect();
                    client = null;
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
                LogBox.Text += $"Exception thrown saving log file. {ex.Message}" + Environment.NewLine;
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

            while (!_closing)
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
                    LogBox.Text += $"Starting application." + Environment.NewLine;
                    StartApplication();

                    Thread.Sleep(LT);

                    LogBox.Text += $"Connecting to Host." + Environment.NewLine;
                    ConnectToHost();

                    Thread.Sleep(FT);

                    LogBox.Text += $"Sending Command." + Environment.NewLine;
                    SendCommand();

                    Thread.Sleep(PT);

                    LogBox.Text += $"Checking report updated." + Environment.NewLine;
                    while (string.IsNullOrWhiteSpace(_result))
                    {
                        Thread.Sleep(FT);
                        LogBox.Text += $"Report not updated yet...." + Environment.NewLine;
                    }
                    LogBox.Text += $"Result of run: {_result}" + Environment.NewLine;
                    _result = "";
                    StopApplication();
                    Thread.Sleep(FT);
                    SaveLogFile();
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    LogBox.Text += $"Exception in automate: {ex.Message}" + Environment.NewLine;
                }
                #endregion
            
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
            this.Close();
        }
    }
}