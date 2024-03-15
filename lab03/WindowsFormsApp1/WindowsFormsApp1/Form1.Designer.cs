namespace WindowsFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axPlay = new System.Windows.Forms.Button();
            this.filename = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dsPlay = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.wfPlay = new System.Windows.Forms.Button();
            this.chooseFile = new System.Windows.Forms.Button();
            this.playWithWOW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.recordButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axPlay
            // 
            this.axPlay.Location = new System.Drawing.Point(56, 154);
            this.axPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.axPlay.Name = "axPlay";
            this.axPlay.Size = new System.Drawing.Size(100, 28);
            this.axPlay.TabIndex = 1;
            this.axPlay.Text = "Play";
            this.axPlay.UseVisualStyleBackColor = true;
            this.axPlay.Click += new System.EventHandler(this.axPlay_Click);
            // 
            // filename
            // 
            this.filename.AutoSize = true;
            this.filename.Location = new System.Drawing.Point(187, 64);
            this.filename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(78, 16);
            this.filename.TabIndex = 2;
            this.filename.Text = "Name of file";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(423, 82);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(365, 277);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "ActiveX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 215);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "DirectSound";
            // 
            // dsPlay
            // 
            this.dsPlay.Location = new System.Drawing.Point(56, 235);
            this.dsPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dsPlay.Name = "dsPlay";
            this.dsPlay.Size = new System.Drawing.Size(100, 28);
            this.dsPlay.TabIndex = 5;
            this.dsPlay.Text = "Play";
            this.dsPlay.UseVisualStyleBackColor = true;
            this.dsPlay.Click += new System.EventHandler(this.dsPlay_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 299);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "WaveForm";
            // 
            // wfPlay
            // 
            this.wfPlay.Location = new System.Drawing.Point(56, 319);
            this.wfPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wfPlay.Name = "wfPlay";
            this.wfPlay.Size = new System.Drawing.Size(100, 28);
            this.wfPlay.TabIndex = 8;
            this.wfPlay.Text = "Play";
            this.wfPlay.UseVisualStyleBackColor = true;
            this.wfPlay.Click += new System.EventHandler(this.wfPlay_Click);
            // 
            // chooseFile
            // 
            this.chooseFile.Location = new System.Drawing.Point(56, 58);
            this.chooseFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chooseFile.Name = "chooseFile";
            this.chooseFile.Size = new System.Drawing.Size(100, 28);
            this.chooseFile.TabIndex = 9;
            this.chooseFile.Text = "Choose file";
            this.chooseFile.UseVisualStyleBackColor = true;
            this.chooseFile.Click += new System.EventHandler(this.chooseFile_Click);
            // 
            // playWithWOW
            // 
            this.playWithWOW.Location = new System.Drawing.Point(56, 454);
            this.playWithWOW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playWithWOW.Name = "playWithWOW";
            this.playWithWOW.Size = new System.Drawing.Size(100, 28);
            this.playWithWOW.TabIndex = 10;
            this.playWithWOW.Text = "Play";
            this.playWithWOW.UseVisualStyleBackColor = true;
            this.playWithWOW.Click += new System.EventHandler(this.playWithWOW_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 431);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "waveOutwrite()";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Location = new System.Drawing.Point(337, 89);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(80, 16);
            this.headerLabel.TabIndex = 12;
            this.headerLabel.Text = "lorem ipsum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Header details:";
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(341, 396);
            this.recordButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(180, 28);
            this.recordButton.TabIndex = 14;
            this.recordButton.Text = "Record your voice";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(341, 432);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(179, 69);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(321, 365);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 24);
            this.comboBox1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playWithWOW);
            this.Controls.Add(this.chooseFile);
            this.Controls.Add(this.wfPlay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dsPlay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.axPlay);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button axPlay;
        private System.Windows.Forms.Label filename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button dsPlay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button wfPlay;
        private System.Windows.Forms.Button chooseFile;
        private System.Windows.Forms.Button playWithWOW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

