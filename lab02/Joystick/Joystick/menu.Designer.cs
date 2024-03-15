namespace Pady
{
    partial class Menu
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.test = new System.Windows.Forms.Button();
            this.emulacja = new System.Windows.Forms.Button();
            this.rysowanie = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(39, 75);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(185, 41);
            this.test.TabIndex = 0;
            this.test.Text = "Test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.button1_Click);
            // 
            // emulacja
            // 
            this.emulacja.Location = new System.Drawing.Point(39, 171);
            this.emulacja.Name = "emulacja";
            this.emulacja.Size = new System.Drawing.Size(185, 41);
            this.emulacja.TabIndex = 1;
            this.emulacja.Text = "Emulacja myszy";
            this.emulacja.UseVisualStyleBackColor = true;
            this.emulacja.Click += new System.EventHandler(this.emulacja_Click);
            // 
            // rysowanie
            // 
            this.rysowanie.Location = new System.Drawing.Point(39, 274);
            this.rysowanie.Name = "rysowanie";
            this.rysowanie.Size = new System.Drawing.Size(185, 41);
            this.rysowanie.TabIndex = 2;
            this.rysowanie.Text = "Rysowanie";
            this.rysowanie.UseVisualStyleBackColor = true;
            this.rysowanie.Click += new System.EventHandler(this.rysowanie_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(248, 75);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(473, 238);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.rysowanie);
            this.Controls.Add(this.emulacja);
            this.Controls.Add(this.test);
            this.Name = "Menu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button test;
        private System.Windows.Forms.Button emulacja;
        private System.Windows.Forms.Button rysowanie;
        private System.Windows.Forms.ListBox listBox1;
    }
}

