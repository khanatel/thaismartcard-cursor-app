namespace ThaiSmartCardReader
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReaderName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCardEvent = new System.Windows.Forms.Label();
            this.TimerSmartCard = new System.Windows.Forms.Timer(this.components);
            this.lblReaderConnect = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TimerChecker = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reader Name:";
            // 
            // lblReaderName
            // 
            this.lblReaderName.AutoSize = true;
            this.lblReaderName.Location = new System.Drawing.Point(149, 9);
            this.lblReaderName.Name = "lblReaderName";
            this.lblReaderName.Size = new System.Drawing.Size(20, 17);
            this.lblReaderName.TabIndex = 1;
            this.lblReaderName.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Card Event:";
            // 
            // lblCardEvent
            // 
            this.lblCardEvent.AutoSize = true;
            this.lblCardEvent.Location = new System.Drawing.Point(149, 59);
            this.lblCardEvent.Name = "lblCardEvent";
            this.lblCardEvent.Size = new System.Drawing.Size(20, 17);
            this.lblCardEvent.TabIndex = 3;
            this.lblCardEvent.Text = "...";
            // 
            // TimerSmartCard
            // 
            this.TimerSmartCard.Interval = 6000;
            this.TimerSmartCard.Tick += new System.EventHandler(this.TimerSmartCard_Tick);
            // 
            // lblReaderConnect
            // 
            this.lblReaderConnect.AutoSize = true;
            this.lblReaderConnect.Location = new System.Drawing.Point(149, 33);
            this.lblReaderConnect.Name = "lblReaderConnect";
            this.lblReaderConnect.Size = new System.Drawing.Size(20, 17);
            this.lblReaderConnect.TabIndex = 5;
            this.lblReaderConnect.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Reader Connected:";
            // 
            // TimerChecker
            // 
            this.TimerChecker.Interval = 6000;
            this.TimerChecker.Tick += new System.EventHandler(this.TimerChecker_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 30);
            this.panel1.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 121);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblReaderConnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCardEvent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblReaderName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Thai Smart Card Reader v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReaderName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCardEvent;
        private System.Windows.Forms.Timer TimerSmartCard;
        private System.Windows.Forms.Label lblReaderConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer TimerChecker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
    }
}

