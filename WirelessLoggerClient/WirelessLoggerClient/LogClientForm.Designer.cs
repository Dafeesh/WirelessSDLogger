namespace WirelessLoggerClient
{
    partial class LogClientForm
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
            this.button_deleteAll = new System.Windows.Forms.Button();
            this.textBox_runId = new System.Windows.Forms.TextBox();
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.textBox_sensorA = new System.Windows.Forms.TextBox();
            this.textBox_sensorB = new System.Windows.Forms.TextBox();
            this.label_runId = new System.Windows.Forms.Label();
            this.label_sensorA = new System.Windows.Forms.Label();
            this.label_sensorB = new System.Windows.Forms.Label();
            this.checkBox_connected = new System.Windows.Forms.CheckBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_readFlow = new System.Windows.Forms.TextBox();
            this.textBox_guard = new System.Windows.Forms.TextBox();
            this.textBox_fillNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_fillTime = new System.Windows.Forms.TextBox();
            this.textBox_fillDur = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_isLeak = new System.Windows.Forms.TextBox();
            this.textBox_fillDelta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_deleteAll
            // 
            this.button_deleteAll.Location = new System.Drawing.Point(762, 391);
            this.button_deleteAll.Name = "button_deleteAll";
            this.button_deleteAll.Size = new System.Drawing.Size(75, 23);
            this.button_deleteAll.TabIndex = 1;
            this.button_deleteAll.Text = "Delete All";
            this.button_deleteAll.UseVisualStyleBackColor = true;
            this.button_deleteAll.Click += new System.EventHandler(this.button_deleteAll_Click);
            // 
            // textBox_runId
            // 
            this.textBox_runId.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_runId.Location = new System.Drawing.Point(123, 78);
            this.textBox_runId.Name = "textBox_runId";
            this.textBox_runId.ReadOnly = true;
            this.textBox_runId.Size = new System.Drawing.Size(100, 62);
            this.textBox_runId.TabIndex = 2;
            this.textBox_runId.Text = "000";
            this.textBox_runId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_time
            // 
            this.textBox_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_time.Location = new System.Drawing.Point(229, 78);
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.ReadOnly = true;
            this.textBox_time.Size = new System.Drawing.Size(268, 62);
            this.textBox_time.TabIndex = 3;
            this.textBox_time.Text = "00h00m00s";
            this.textBox_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_sensorA
            // 
            this.textBox_sensorA.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_sensorA.Location = new System.Drawing.Point(229, 147);
            this.textBox_sensorA.Name = "textBox_sensorA";
            this.textBox_sensorA.ReadOnly = true;
            this.textBox_sensorA.Size = new System.Drawing.Size(134, 62);
            this.textBox_sensorA.TabIndex = 4;
            this.textBox_sensorA.Text = "0000";
            this.textBox_sensorA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_sensorB
            // 
            this.textBox_sensorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_sensorB.Location = new System.Drawing.Point(229, 215);
            this.textBox_sensorB.Name = "textBox_sensorB";
            this.textBox_sensorB.ReadOnly = true;
            this.textBox_sensorB.Size = new System.Drawing.Size(134, 62);
            this.textBox_sensorB.TabIndex = 5;
            this.textBox_sensorB.Text = "0000";
            this.textBox_sensorB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_runId
            // 
            this.label_runId.AutoSize = true;
            this.label_runId.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_runId.Location = new System.Drawing.Point(12, 84);
            this.label_runId.Name = "label_runId";
            this.label_runId.Size = new System.Drawing.Size(113, 51);
            this.label_runId.TabIndex = 6;
            this.label_runId.Text = "Run:";
            // 
            // label_sensorA
            // 
            this.label_sensorA.AutoSize = true;
            this.label_sensorA.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sensorA.Location = new System.Drawing.Point(12, 153);
            this.label_sensorA.Name = "label_sensorA";
            this.label_sensorA.Size = new System.Drawing.Size(211, 51);
            this.label_sensorA.TabIndex = 8;
            this.label_sensorA.Text = "Sensor A:";
            // 
            // label_sensorB
            // 
            this.label_sensorB.AutoSize = true;
            this.label_sensorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sensorB.Location = new System.Drawing.Point(14, 221);
            this.label_sensorB.Name = "label_sensorB";
            this.label_sensorB.Size = new System.Drawing.Size(211, 51);
            this.label_sensorB.TabIndex = 9;
            this.label_sensorB.Text = "Sensor B:";
            // 
            // checkBox_connected
            // 
            this.checkBox_connected.AutoCheck = false;
            this.checkBox_connected.AutoSize = true;
            this.checkBox_connected.Location = new System.Drawing.Point(725, 368);
            this.checkBox_connected.Name = "checkBox_connected";
            this.checkBox_connected.Size = new System.Drawing.Size(78, 17);
            this.checkBox_connected.TabIndex = 10;
            this.checkBox_connected.Text = "Connected";
            this.checkBox_connected.UseVisualStyleBackColor = true;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(681, 391);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 11;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 59);
            this.label2.TabIndex = 14;
            this.label2.Text = "Live Feed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(359, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 51);
            this.label3.TabIndex = 16;
            this.label3.Text = "psi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(359, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 51);
            this.label4.TabIndex = 17;
            this.label4.Text = "psi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(689, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 59);
            this.label1.TabIndex = 18;
            this.label1.Text = "Last Fill";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(538, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 51);
            this.label5.TabIndex = 19;
            this.label5.Text = "Fill:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 51);
            this.label6.TabIndex = 20;
            this.label6.Text = "Guard Dog:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 51);
            this.label7.TabIndex = 21;
            this.label7.Text = "Read Flow:";
            // 
            // textBox_readFlow
            // 
            this.textBox_readFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_readFlow.Location = new System.Drawing.Point(251, 283);
            this.textBox_readFlow.Name = "textBox_readFlow";
            this.textBox_readFlow.ReadOnly = true;
            this.textBox_readFlow.Size = new System.Drawing.Size(112, 62);
            this.textBox_readFlow.TabIndex = 22;
            this.textBox_readFlow.Text = "On";
            this.textBox_readFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_guard
            // 
            this.textBox_guard.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_guard.Location = new System.Drawing.Point(251, 351);
            this.textBox_guard.Name = "textBox_guard";
            this.textBox_guard.ReadOnly = true;
            this.textBox_guard.Size = new System.Drawing.Size(112, 62);
            this.textBox_guard.TabIndex = 23;
            this.textBox_guard.Text = "On";
            this.textBox_guard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_fillNumber
            // 
            this.textBox_fillNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_fillNumber.Location = new System.Drawing.Point(630, 78);
            this.textBox_fillNumber.Name = "textBox_fillNumber";
            this.textBox_fillNumber.ReadOnly = true;
            this.textBox_fillNumber.Size = new System.Drawing.Size(104, 62);
            this.textBox_fillNumber.TabIndex = 24;
            this.textBox_fillNumber.Text = "---";
            this.textBox_fillNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(538, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 51);
            this.label8.TabIndex = 25;
            this.label8.Text = "Duration:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(538, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(198, 51);
            this.label10.TabIndex = 27;
            this.label10.Text = "Leaking?";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(538, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(202, 51);
            this.label11.TabIndex = 28;
            this.label11.Text = "Delta psi:";
            // 
            // textBox_fillTime
            // 
            this.textBox_fillTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_fillTime.Location = new System.Drawing.Point(740, 78);
            this.textBox_fillTime.Name = "textBox_fillTime";
            this.textBox_fillTime.ReadOnly = true;
            this.textBox_fillTime.Size = new System.Drawing.Size(268, 62);
            this.textBox_fillTime.TabIndex = 30;
            this.textBox_fillTime.Text = "00h00m00s";
            this.textBox_fillTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_fillDur
            // 
            this.textBox_fillDur.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_fillDur.Location = new System.Drawing.Point(740, 146);
            this.textBox_fillDur.Name = "textBox_fillDur";
            this.textBox_fillDur.ReadOnly = true;
            this.textBox_fillDur.Size = new System.Drawing.Size(158, 62);
            this.textBox_fillDur.TabIndex = 31;
            this.textBox_fillDur.Text = "-";
            this.textBox_fillDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(904, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 51);
            this.label9.TabIndex = 32;
            this.label9.Text = "sec";
            // 
            // textBox_isLeak
            // 
            this.textBox_isLeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_isLeak.Location = new System.Drawing.Point(740, 282);
            this.textBox_isLeak.Name = "textBox_isLeak";
            this.textBox_isLeak.ReadOnly = true;
            this.textBox_isLeak.Size = new System.Drawing.Size(158, 62);
            this.textBox_isLeak.TabIndex = 33;
            this.textBox_isLeak.Text = "-";
            this.textBox_isLeak.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_fillDelta
            // 
            this.textBox_fillDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_fillDelta.Location = new System.Drawing.Point(740, 214);
            this.textBox_fillDelta.Name = "textBox_fillDelta";
            this.textBox_fillDelta.ReadOnly = true;
            this.textBox_fillDelta.Size = new System.Drawing.Size(158, 62);
            this.textBox_fillDelta.TabIndex = 34;
            this.textBox_fillDelta.Text = "-";
            this.textBox_fillDelta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(904, 220);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 51);
            this.label12.TabIndex = 35;
            this.label12.Text = "psi";
            // 
            // LogClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 427);
            this.Controls.Add(this.textBox_fillDelta);
            this.Controls.Add(this.textBox_isLeak);
            this.Controls.Add(this.textBox_fillDur);
            this.Controls.Add(this.textBox_fillTime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_fillNumber);
            this.Controls.Add(this.textBox_guard);
            this.Controls.Add(this.textBox_readFlow);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.checkBox_connected);
            this.Controls.Add(this.textBox_sensorB);
            this.Controls.Add(this.textBox_sensorA);
            this.Controls.Add(this.textBox_time);
            this.Controls.Add(this.textBox_runId);
            this.Controls.Add(this.label_sensorB);
            this.Controls.Add(this.label_sensorA);
            this.Controls.Add(this.label_runId);
            this.Controls.Add(this.button_deleteAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LogClientForm";
            this.Text = "Log Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogClientForm_FormClosing);
            this.Shown += new System.EventHandler(this.LogClientForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_deleteAll;
        private System.Windows.Forms.TextBox textBox_runId;
        private System.Windows.Forms.TextBox textBox_time;
        private System.Windows.Forms.TextBox textBox_sensorA;
        private System.Windows.Forms.TextBox textBox_sensorB;
        private System.Windows.Forms.Label label_runId;
        private System.Windows.Forms.Label label_sensorA;
        private System.Windows.Forms.Label label_sensorB;
        private System.Windows.Forms.CheckBox checkBox_connected;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_readFlow;
        private System.Windows.Forms.TextBox textBox_guard;
        private System.Windows.Forms.TextBox textBox_fillNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_fillTime;
        private System.Windows.Forms.TextBox textBox_fillDur;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_isLeak;
        private System.Windows.Forms.TextBox textBox_fillDelta;
        private System.Windows.Forms.Label label12;
    }
}

