namespace CommandClient
{
    partial class CommandClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogBox = new System.Windows.Forms.TextBox();
            this.IPadd = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.InputLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SendJson = new System.Windows.Forms.Button();
            this.ClearLogBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSLPath = new System.Windows.Forms.TextBox();
            this.chkAutomate = new System.Windows.Forms.CheckBox();
            this.txtLoadTime = new System.Windows.Forms.TextBox();
            this.txtProgramRun = new System.Windows.Forms.TextBox();
            this.txtFillerTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.inputList = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._btnAddToList = new System.Windows.Forms.Button();
            this._btnClearList = new System.Windows.Forms.Button();
            this._btnRemoveAt = new System.Windows.Forms.Button();
            this.removeAtIndex = new System.Windows.Forms.TextBox();
            this._btnStopLoopList = new System.Windows.Forms.Button();
            this._btnStartLoopList = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this._btnRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(8, 95);
            this.LogBox.Margin = new System.Windows.Forms.Padding(2);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(577, 310);
            this.LogBox.TabIndex = 5;
            // 
            // IPadd
            // 
            this.IPadd.Location = new System.Drawing.Point(8, 27);
            this.IPadd.Margin = new System.Windows.Forms.Padding(2);
            this.IPadd.Name = "IPadd";
            this.IPadd.Size = new System.Drawing.Size(135, 20);
            this.IPadd.TabIndex = 0;
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(146, 27);
            this.Port.Margin = new System.Windows.Forms.Padding(2);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(105, 20);
            this.Port.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ConnectBtn.Location = new System.Drawing.Point(262, 17);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(87, 27);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(587, 95);
            this.InputBox.Margin = new System.Windows.Forms.Padding(2);
            this.InputBox.Multiline = true;
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(539, 66);
            this.InputBox.TabIndex = 3;
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point(588, 72);
            this.InputLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(57, 13);
            this.InputLabel.TabIndex = 9;
            this.InputLabel.Text = "Input Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Log";
            // 
            // SendJson
            // 
            this.SendJson.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SendJson.Location = new System.Drawing.Point(587, 171);
            this.SendJson.Margin = new System.Windows.Forms.Padding(2);
            this.SendJson.Name = "SendJson";
            this.SendJson.Size = new System.Drawing.Size(87, 27);
            this.SendJson.TabIndex = 4;
            this.SendJson.Text = "Send as JSON";
            this.SendJson.UseVisualStyleBackColor = false;
            this.SendJson.Click += new System.EventHandler(this.SendJson_Click);
            // 
            // ClearLogBtn
            // 
            this.ClearLogBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClearLogBtn.Location = new System.Drawing.Point(8, 416);
            this.ClearLogBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ClearLogBtn.Name = "ClearLogBtn";
            this.ClearLogBtn.Size = new System.Drawing.Size(87, 27);
            this.ClearLogBtn.TabIndex = 6;
            this.ClearLogBtn.Text = "Clear Log";
            this.ClearLogBtn.UseVisualStyleBackColor = false;
            this.ClearLogBtn.Click += new System.EventHandler(this.ClearLogBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.StartBtn.Location = new System.Drawing.Point(619, 17);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(87, 27);
            this.StartBtn.TabIndex = 11;
            this.StartBtn.Text = "Start SL";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.StopBtn.Location = new System.Drawing.Point(1001, 17);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(87, 27);
            this.StopBtn.TabIndex = 12;
            this.StopBtn.Text = "Stop SL";
            this.StopBtn.UseVisualStyleBackColor = false;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(820, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "SL Path";
            // 
            // txtSLPath
            // 
            this.txtSLPath.Location = new System.Drawing.Point(710, 27);
            this.txtSLPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtSLPath.Name = "txtSLPath";
            this.txtSLPath.Size = new System.Drawing.Size(292, 20);
            this.txtSLPath.TabIndex = 14;
            // 
            // chkAutomate
            // 
            this.chkAutomate.AutoSize = true;
            this.chkAutomate.Location = new System.Drawing.Point(710, 47);
            this.chkAutomate.Margin = new System.Windows.Forms.Padding(2);
            this.chkAutomate.Name = "chkAutomate";
            this.chkAutomate.Size = new System.Drawing.Size(71, 17);
            this.chkAutomate.TabIndex = 15;
            this.chkAutomate.Text = "Automate";
            this.chkAutomate.UseVisualStyleBackColor = true;
            // 
            // txtLoadTime
            // 
            this.txtLoadTime.Location = new System.Drawing.Point(678, 239);
            this.txtLoadTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoadTime.Name = "txtLoadTime";
            this.txtLoadTime.Size = new System.Drawing.Size(58, 20);
            this.txtLoadTime.TabIndex = 16;
            this.txtLoadTime.Text = "10000";
            // 
            // txtProgramRun
            // 
            this.txtProgramRun.Location = new System.Drawing.Point(678, 269);
            this.txtProgramRun.Margin = new System.Windows.Forms.Padding(2);
            this.txtProgramRun.Name = "txtProgramRun";
            this.txtProgramRun.Size = new System.Drawing.Size(58, 20);
            this.txtProgramRun.TabIndex = 17;
            this.txtProgramRun.Text = "10000";
            // 
            // txtFillerTime
            // 
            this.txtFillerTime.Location = new System.Drawing.Point(678, 302);
            this.txtFillerTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtFillerTime.Name = "txtFillerTime";
            this.txtFillerTime.Size = new System.Drawing.Size(58, 20);
            this.txtFillerTime.TabIndex = 18;
            this.txtFillerTime.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 306);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Filler";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(592, 273);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "ProgramRun";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(592, 242);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "LoadApplication";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(592, 218);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Wait Times For Commands";
            // 
            // inputList
            // 
            this.inputList.Location = new System.Drawing.Point(740, 198);
            this.inputList.Margin = new System.Windows.Forms.Padding(2);
            this.inputList.Multiline = true;
            this.inputList.Name = "inputList";
            this.inputList.Size = new System.Drawing.Size(386, 238);
            this.inputList.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(902, 178);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Input List";
            // 
            // _btnAddToList
            // 
            this._btnAddToList.BackColor = System.Drawing.SystemColors.ControlDark;
            this._btnAddToList.Location = new System.Drawing.Point(773, 171);
            this._btnAddToList.Margin = new System.Windows.Forms.Padding(2);
            this._btnAddToList.Name = "_btnAddToList";
            this._btnAddToList.Size = new System.Drawing.Size(98, 27);
            this._btnAddToList.TabIndex = 25;
            this._btnAddToList.Text = "Add to List";
            this._btnAddToList.UseVisualStyleBackColor = false;
            this._btnAddToList.Click += new System.EventHandler(this.BtnAddToList_Click);
            // 
            // _btnClearList
            // 
            this._btnClearList.BackColor = System.Drawing.SystemColors.ControlDark;
            this._btnClearList.Location = new System.Drawing.Point(991, 171);
            this._btnClearList.Margin = new System.Windows.Forms.Padding(2);
            this._btnClearList.Name = "_btnClearList";
            this._btnClearList.Size = new System.Drawing.Size(98, 27);
            this._btnClearList.TabIndex = 26;
            this._btnClearList.Text = "Clear List";
            this._btnClearList.UseVisualStyleBackColor = false;
            this._btnClearList.Click += new System.EventHandler(this.BtnClearList_Click);
            // 
            // _btnRemoveAt
            // 
            this._btnRemoveAt.BackColor = System.Drawing.SystemColors.ControlDark;
            this._btnRemoveAt.Location = new System.Drawing.Point(589, 409);
            this._btnRemoveAt.Margin = new System.Windows.Forms.Padding(2);
            this._btnRemoveAt.Name = "_btnRemoveAt";
            this._btnRemoveAt.Size = new System.Drawing.Size(98, 27);
            this._btnRemoveAt.TabIndex = 27;
            this._btnRemoveAt.Text = "Remove #";
            this._btnRemoveAt.UseVisualStyleBackColor = false;
            this._btnRemoveAt.Click += new System.EventHandler(this.BtnRemoveAt_Click);
            // 
            // removeAtIndex
            // 
            this.removeAtIndex.Location = new System.Drawing.Point(691, 413);
            this.removeAtIndex.Margin = new System.Windows.Forms.Padding(2);
            this.removeAtIndex.Name = "removeAtIndex";
            this.removeAtIndex.Size = new System.Drawing.Size(45, 20);
            this.removeAtIndex.TabIndex = 28;
            this.removeAtIndex.Text = "1";
            // 
            // _btnStopLoopList
            // 
            this._btnStopLoopList.BackColor = System.Drawing.SystemColors.ControlDark;
            this._btnStopLoopList.Location = new System.Drawing.Point(665, 353);
            this._btnStopLoopList.Margin = new System.Windows.Forms.Padding(2);
            this._btnStopLoopList.Name = "_btnStopLoopList";
            this._btnStopLoopList.Size = new System.Drawing.Size(71, 27);
            this._btnStopLoopList.TabIndex = 29;
            this._btnStopLoopList.Text = "Stop";
            this._btnStopLoopList.UseVisualStyleBackColor = false;
            this._btnStopLoopList.Click += new System.EventHandler(this.BtnStopLoopList_Click);
            // 
            // _btnStartLoopList
            // 
            this._btnStartLoopList.BackColor = System.Drawing.SystemColors.ControlDark;
            this._btnStartLoopList.Location = new System.Drawing.Point(589, 353);
            this._btnStartLoopList.Margin = new System.Windows.Forms.Padding(2);
            this._btnStartLoopList.Name = "_btnStartLoopList";
            this._btnStartLoopList.Size = new System.Drawing.Size(71, 27);
            this._btnStartLoopList.TabIndex = 30;
            this._btnStartLoopList.Text = "Start";
            this._btnStartLoopList.UseVisualStyleBackColor = false;
            this._btnStartLoopList.Click += new System.EventHandler(this.BtnStartLoopList_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(637, 338);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Loop List";
            // 
            // _btnRestart
            // 
            this._btnRestart.BackColor = System.Drawing.SystemColors.ControlDark;
            this._btnRestart.Location = new System.Drawing.Point(814, 51);
            this._btnRestart.Margin = new System.Windows.Forms.Padding(2);
            this._btnRestart.Name = "_btnRestart";
            this._btnRestart.Size = new System.Drawing.Size(87, 27);
            this._btnRestart.TabIndex = 32;
            this._btnRestart.Text = "Restart SL";
            this._btnRestart.UseVisualStyleBackColor = false;
            this._btnRestart.Click += new System.EventHandler(this.RestartStreamline_Click);
            // 
            // CommandClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1137, 454);
            this.Controls.Add(this._btnRestart);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._btnStartLoopList);
            this.Controls.Add(this._btnStopLoopList);
            this.Controls.Add(this.removeAtIndex);
            this.Controls.Add(this._btnRemoveAt);
            this.Controls.Add(this._btnClearList);
            this.Controls.Add(this._btnAddToList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.inputList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFillerTime);
            this.Controls.Add(this.txtProgramRun);
            this.Controls.Add(this.txtLoadTime);
            this.Controls.Add(this.chkAutomate);
            this.Controls.Add(this.txtSLPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.ClearLogBtn);
            this.Controls.Add(this.SendJson);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IPadd);
            this.Controls.Add(this.LogBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CommandClient";
            this.Text = "Command Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandClient_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.TextBox IPadd;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SendJson;
        private System.Windows.Forms.Button ClearLogBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSLPath;
        private System.Windows.Forms.CheckBox chkAutomate;
        private System.Windows.Forms.TextBox txtLoadTime;
        private System.Windows.Forms.TextBox txtProgramRun;
        private System.Windows.Forms.TextBox txtFillerTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inputList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button _btnAddToList;
        private System.Windows.Forms.Button _btnClearList;
        private System.Windows.Forms.Button _btnRemoveAt;
        private System.Windows.Forms.TextBox removeAtIndex;
        private System.Windows.Forms.Button _btnStopLoopList;
        private System.Windows.Forms.Button _btnStartLoopList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button _btnRestart;
    }
}

