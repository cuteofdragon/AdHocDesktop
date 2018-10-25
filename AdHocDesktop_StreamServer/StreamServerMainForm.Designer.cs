using AdHocDesktop.Core;

namespace AdHocDesktop.StreamServer
{
    partial class StreamServerMainForm
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
            if (disposing)
            {
                LoggingManager.Export("log.txt");
                server.Stop();
            }
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
            this.components = new System.ComponentModel.Container();
            this.bandwidthTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bandwidthOutputLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bandwidthInputLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.copyLogButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.onlineGroupLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.onlinePeopleLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bandwidthTimer
            // 
            this.bandwidthTimer.Enabled = true;
            this.bandwidthTimer.Interval = 3000;
            this.bandwidthTimer.Tick += new System.EventHandler(this.bandwidthTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.bandwidthOutputLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bandwidthInputLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 72);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "頻寬（平均3秒）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "KB/S";
            // 
            // bandwidthOutputLabel
            // 
            this.bandwidthOutputLabel.Location = new System.Drawing.Point(44, 44);
            this.bandwidthOutputLabel.Name = "bandwidthOutputLabel";
            this.bandwidthOutputLabel.Size = new System.Drawing.Size(60, 12);
            this.bandwidthOutputLabel.TabIndex = 4;
            this.bandwidthOutputLabel.Text = "0";
            this.bandwidthOutputLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "KB/S";
            // 
            // bandwidthInputLabel
            // 
            this.bandwidthInputLabel.Location = new System.Drawing.Point(44, 18);
            this.bandwidthInputLabel.Name = "bandwidthInputLabel";
            this.bandwidthInputLabel.Size = new System.Drawing.Size(60, 12);
            this.bandwidthInputLabel.TabIndex = 2;
            this.bandwidthInputLabel.Text = "0";
            this.bandwidthInputLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "輸出:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "輸入:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.logTextBox);
            this.groupBox2.Controls.Add(this.copyLogButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 203);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "訊息";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(6, 21);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(270, 145);
            this.logTextBox.TabIndex = 0;
            // 
            // copyLogButton
            // 
            this.copyLogButton.Location = new System.Drawing.Point(6, 172);
            this.copyLogButton.Name = "copyLogButton";
            this.copyLogButton.Size = new System.Drawing.Size(75, 23);
            this.copyLogButton.TabIndex = 2;
            this.copyLogButton.Text = "複製";
            this.copyLogButton.UseVisualStyleBackColor = true;
            this.copyLogButton.Click += new System.EventHandler(this.copyLogButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.onlineGroupLabel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.onlinePeopleLabel);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(13, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 72);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "線上資訊";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "團";
            // 
            // onlineGroupLabel
            // 
            this.onlineGroupLabel.Location = new System.Drawing.Point(44, 44);
            this.onlineGroupLabel.Name = "onlineGroupLabel";
            this.onlineGroupLabel.Size = new System.Drawing.Size(60, 12);
            this.onlineGroupLabel.TabIndex = 4;
            this.onlineGroupLabel.Text = "0";
            this.onlineGroupLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "人";
            // 
            // onlinePeopleLabel
            // 
            this.onlinePeopleLabel.Location = new System.Drawing.Point(44, 18);
            this.onlinePeopleLabel.Name = "onlinePeopleLabel";
            this.onlinePeopleLabel.Size = new System.Drawing.Size(60, 12);
            this.onlinePeopleLabel.TabIndex = 2;
            this.onlinePeopleLabel.Text = "0";
            this.onlinePeopleLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "群組:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "人數:";
            // 
            // StreamServerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 378);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StreamServerMainForm";
            this.Text = "隨意桌面串流伺服器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer bandwidthTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button copyLogButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label bandwidthOutputLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label bandwidthInputLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label onlineGroupLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label onlinePeopleLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;

    }
}

