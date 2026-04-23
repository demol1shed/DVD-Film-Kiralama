namespace DvdOtomasyonu
{
    partial class AnaForms
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
            filmButton = new Button();
            kiraButton = new Button();
            cikisButton = new Button();
            panelAnaKonteyner = new Panel();
            SuspendLayout();
            // 
            // filmButton
            // 
            filmButton.Location = new Point(220, 15);
            filmButton.Name = "filmButton";
            filmButton.Size = new Size(156, 39);
            filmButton.TabIndex = 0;
            filmButton.Text = "Filmler";
            filmButton.UseVisualStyleBackColor = true;
            filmButton.Click += filmButton_Click;
            // 
            // kiraButton
            // 
            kiraButton.Location = new Point(421, 15);
            kiraButton.Name = "kiraButton";
            kiraButton.Size = new Size(156, 39);
            kiraButton.TabIndex = 1;
            kiraButton.Text = "Kiraladıklarım";
            kiraButton.UseVisualStyleBackColor = true;
            kiraButton.Click += kiraButton_Click;
            // 
            // cikisButton
            // 
            cikisButton.Location = new Point(690, 15);
            cikisButton.Name = "cikisButton";
            cikisButton.Size = new Size(98, 33);
            cikisButton.TabIndex = 4;
            cikisButton.Text = "Çıkış";
            cikisButton.UseVisualStyleBackColor = true;
            cikisButton.Click += cikisButton_Click;
            // 
            // panelAnaKonteyner
            // 
            panelAnaKonteyner.Location = new Point(12, 74);
            panelAnaKonteyner.Name = "panelAnaKonteyner";
            panelAnaKonteyner.Size = new Size(776, 364);
            panelAnaKonteyner.TabIndex = 5;
            // 
            // AnaForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelAnaKonteyner);
            Controls.Add(cikisButton);
            Controls.Add(kiraButton);
            Controls.Add(filmButton);
            Name = "AnaForms";
            Text = "AnaForms";
            ResumeLayout(false);
        }

        #endregion

        private Button filmButton;
        private Button kiraButton;
        private Button button3;
        private Button button4;
        private Button cikisButton;
        private Panel panelAnaKonteyner;
    }
}