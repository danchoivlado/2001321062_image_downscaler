namespace _2001321062_image_resizer
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(101, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(570, 291);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(101, 396);
            button1.Name = "button1";
            button1.Size = new Size(138, 23);
            button1.TabIndex = 2;
            button1.Text = "Choose Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(533, 396);
            button2.Name = "button2";
            button2.Size = new Size(138, 23);
            button2.TabIndex = 3;
            button2.Text = "Downscale";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%" });
            comboBox1.Location = new Point(307, 350);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(327, 332);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 6;
            label1.Text = "Downscale %";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.InactiveCaption;
            Name = "Form1";
            Text = "Image downscaler";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private Label label1;
    }
}
