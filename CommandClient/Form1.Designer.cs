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
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 146);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(863, 475);
            this.LogBox.TabIndex = 5;
            // 
            // IPadd
            // 
            this.IPadd.Location = new System.Drawing.Point(12, 41);
            this.IPadd.Name = "IPadd";
            this.IPadd.Size = new System.Drawing.Size(201, 26);
            this.IPadd.TabIndex = 0;
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(219, 41);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(155, 26);
            this.Port.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ConnectBtn.Location = new System.Drawing.Point(393, 26);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(130, 41);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(881, 146);
            this.InputBox.Multiline = true;
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(703, 99);
            this.InputBox.TabIndex = 3;
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point(877, 111);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(85, 20);
            this.InputLabel.TabIndex = 9;
            this.InputLabel.Text = "Input Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Log";
            // 
            // SendJson
            // 
            this.SendJson.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SendJson.Location = new System.Drawing.Point(881, 263);
            this.SendJson.Name = "SendJson";
            this.SendJson.Size = new System.Drawing.Size(130, 41);
            this.SendJson.TabIndex = 4;
            this.SendJson.Text = "Send as JSON";
            this.SendJson.UseVisualStyleBackColor = false;
            this.SendJson.Click += new System.EventHandler(this.SendJson_Click);
            // 
            // ClearLogBtn
            // 
            this.ClearLogBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClearLogBtn.Location = new System.Drawing.Point(12, 640);
            this.ClearLogBtn.Name = "ClearLogBtn";
            this.ClearLogBtn.Size = new System.Drawing.Size(130, 41);
            this.ClearLogBtn.TabIndex = 6;
            this.ClearLogBtn.Text = "Clear Log";
            this.ClearLogBtn.UseVisualStyleBackColor = false;
            this.ClearLogBtn.Click += new System.EventHandler(this.ClearLogBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.StartBtn.Location = new System.Drawing.Point(881, 26);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(130, 41);
            this.StartBtn.TabIndex = 11;
            this.StartBtn.Text = "Start SL";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.StopBtn.Location = new System.Drawing.Point(1454, 26);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(130, 41);
            this.StopBtn.TabIndex = 12;
            this.StopBtn.Text = "Stop SL";
            this.StopBtn.UseVisualStyleBackColor = false;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1182, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "SL Path";
            // 
            // txtSLPath
            // 
            this.txtSLPath.Location = new System.Drawing.Point(1017, 41);
            this.txtSLPath.Name = "txtSLPath";
            this.txtSLPath.Size = new System.Drawing.Size(436, 26);
            this.txtSLPath.TabIndex = 14;
            // 
            // chkAutomate
            // 
            this.chkAutomate.AutoSize = true;
            this.chkAutomate.Location = new System.Drawing.Point(1017, 73);
            this.chkAutomate.Name = "chkAutomate";
            this.chkAutomate.Size = new System.Drawing.Size(105, 24);
            this.chkAutomate.TabIndex = 15;
            this.chkAutomate.Text = "Automate";
            this.chkAutomate.UseVisualStyleBackColor = true;
            // 
            // txtLoadTime
            // 
            this.txtLoadTime.Location = new System.Drawing.Point(1017, 367);
            this.txtLoadTime.Name = "txtLoadTime";
            this.txtLoadTime.Size = new System.Drawing.Size(155, 26);
            this.txtLoadTime.TabIndex = 16;
            this.txtLoadTime.Text = "10000";
            // 
            // txtProgramRun
            // 
            this.txtProgramRun.Location = new System.Drawing.Point(1017, 414);
            this.txtProgramRun.Name = "txtProgramRun";
            this.txtProgramRun.Size = new System.Drawing.Size(155, 26);
            this.txtProgramRun.TabIndex = 17;
            this.txtProgramRun.Text = "10000";
            // 
            // txtFillerTime
            // 
            this.txtFillerTime.Location = new System.Drawing.Point(1017, 465);
            this.txtFillerTime.Name = "txtFillerTime";
            this.txtFillerTime.Size = new System.Drawing.Size(155, 26);
            this.txtFillerTime.TabIndex = 18;
            this.txtFillerTime.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(888, 471);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Filler";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(888, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "ProgramRun";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(888, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "LoadApplication";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(888, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Wait Times For Commands";
            // 
            // CommandClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1598, 698);
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
    }
}

