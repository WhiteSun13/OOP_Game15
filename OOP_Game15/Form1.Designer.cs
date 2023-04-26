namespace OOP_Game15
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
            gridSizeText = new TextBox();
            startBtn = new Button();
            emptyBtnText = new TextBox();
            defaultCheck = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // gridSizeText
            // 
            gridSizeText.Location = new Point(12, 116);
            gridSizeText.Name = "gridSizeText";
            gridSizeText.Size = new Size(125, 27);
            gridSizeText.TabIndex = 0;
            gridSizeText.KeyPress += TextBox_KeyPress;
            // 
            // startBtn
            // 
            startBtn.Font = new Font("Stencil", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            startBtn.ForeColor = Color.Crimson;
            startBtn.Location = new Point(12, 149);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(414, 52);
            startBtn.TabIndex = 1;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // emptyBtnText
            // 
            emptyBtnText.Enabled = false;
            emptyBtnText.Location = new Point(294, 116);
            emptyBtnText.Name = "emptyBtnText";
            emptyBtnText.Size = new Size(125, 27);
            emptyBtnText.TabIndex = 2;
            emptyBtnText.KeyPress += TextBox_KeyPress;
            // 
            // defaultCheck
            // 
            defaultCheck.AutoSize = true;
            defaultCheck.Checked = true;
            defaultCheck.CheckState = CheckState.Checked;
            defaultCheck.Location = new Point(152, 118);
            defaultCheck.Name = "defaultCheck";
            defaultCheck.Size = new Size(136, 24);
            defaultCheck.TabIndex = 3;
            defaultCheck.Text = "По умолчанию";
            defaultCheck.UseVisualStyleBackColor = true;
            defaultCheck.CheckedChanged += defaultCheck_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.MistyRose;
            label1.Font = new Font("Stencil", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(167, 9);
            label1.Name = "label1";
            label1.Size = new Size(101, 71);
            label1.TabIndex = 4;
            label1.Text = "15";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 5;
            label2.Text = "Размер поля:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(152, 93);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 6;
            label3.Text = "Пустая клетка:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(438, 209);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(defaultCheck);
            Controls.Add(emptyBtnText);
            Controls.Add(startBtn);
            Controls.Add(gridSizeText);
            MaximumSize = new Size(456, 256);
            MinimumSize = new Size(456, 256);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox gridSizeText;
        private Button startBtn;
        private TextBox emptyBtnText;
        private CheckBox defaultCheck;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}