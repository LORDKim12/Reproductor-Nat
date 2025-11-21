namespace Reproductor_Nat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            axWindowsMediaPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnCarpeta = new Button();
            listBox1 = new ListBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(axWindowsMediaPlayer2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(245, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(543, 426);
            panel1.TabIndex = 0;
            // 
            // axWindowsMediaPlayer2
            // 
            axWindowsMediaPlayer2.Enabled = true;
            axWindowsMediaPlayer2.Location = new Point(3, 3);
            axWindowsMediaPlayer2.Name = "axWindowsMediaPlayer2";
            axWindowsMediaPlayer2.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer2.OcxState");
            axWindowsMediaPlayer2.Size = new Size(537, 420);
            axWindowsMediaPlayer2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(537, 420);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSiguiente);
            panel2.Controls.Add(btnAnterior);
            panel2.Controls.Add(btnCarpeta);
            panel2.Controls.Add(listBox1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(227, 426);
            panel2.TabIndex = 1;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(112, 390);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(94, 29);
            btnSiguiente.TabIndex = 5;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(3, 390);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(103, 29);
            btnAnterior.TabIndex = 4;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnCarpeta
            // 
            btnCarpeta.Location = new Point(0, 350);
            btnCarpeta.Name = "btnCarpeta";
            btnCarpeta.Size = new Size(94, 29);
            btnCarpeta.TabIndex = 3;
            btnCarpeta.Text = "Cargar";
            btnCarpeta.UseVisualStyleBackColor = true;
            btnCarpeta.Click += btnCarpeta_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(224, 344);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private ListBox listBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer2;
        private PictureBox pictureBox1;
        private Button btnCarpeta;
        private Button btnSiguiente;
        private Button btnAnterior;
    }
}
