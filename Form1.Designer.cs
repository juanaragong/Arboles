namespace Arboles
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
            txtDato = new TextBox();
            btnInsertar = new Button();
            SuspendLayout();
            // 
            // txtDato
            // 
            txtDato.Location = new Point(1347, 56);
            txtDato.Name = "txtDato";
            txtDato.Size = new Size(150, 31);
            txtDato.TabIndex = 1;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(1202, 35);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(112, 72);
            btnInsertar.TabIndex = 2;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 555);
            Controls.Add(btnInsertar);
            Controls.Add(txtDato);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDato;
        private Button btnInsertar;
    }
}
