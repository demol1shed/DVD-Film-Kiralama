namespace DvdOtomasyonu
{
    partial class ucFilmler
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            kiraButton = new Button();
            label1 = new Label();
            txtArama = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1000, 404);
            dataGridView1.TabIndex = 0;
            // 
            // kiraButton
            // 
            kiraButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            kiraButton.Location = new Point(841, 458);
            kiraButton.Name = "kiraButton";
            kiraButton.Size = new Size(156, 39);
            kiraButton.TabIndex = 2;
            kiraButton.Text = "Kirala";
            kiraButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(315, 12);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 4;
            label1.Text = "Film Ara:";
            // 
            // txtArama
            // 
            txtArama.Anchor = AnchorStyles.Top;
            txtArama.BackColor = SystemColors.GradientInactiveCaption;
            txtArama.Location = new Point(388, 9);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(262, 27);
            txtArama.TabIndex = 5;
            txtArama.TextChanged += txtArama_TextChanged_1;
            // 
            // ucFilmler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtArama);
            Controls.Add(label1);
            Controls.Add(kiraButton);
            Controls.Add(dataGridView1);
            Name = "ucFilmler";
            Size = new Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button kiraButton;
        private Label label1;
        private TextBox txtArama;
    }
}
