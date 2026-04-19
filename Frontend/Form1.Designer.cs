namespace DvdOtomasyonu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button2 = new Button();
            button1 = new Button();
            panelKonteyner = new Panel();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(439, 44);
            button2.Name = "button2";
            button2.Size = new Size(146, 57);
            button2.TabIndex = 9;
            button2.Text = "Kayıt Ol\r\n";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(240, 44);
            button1.Name = "button1";
            button1.Size = new Size(154, 57);
            button1.TabIndex = 10;
            button1.Text = "Giriş Yap";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelKonteyner
            // 
            panelKonteyner.Location = new Point(143, 107);
            panelKonteyner.Name = "panelKonteyner";
            panelKonteyner.Size = new Size(549, 294);
            panelKonteyner.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelKonteyner);
            Controls.Add(button1);
            Controls.Add(button2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button2;
        private Button button1;
        private Panel panelKonteyner;
    }
}
