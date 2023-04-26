namespace OOP_Game15
{
    public partial class Form1 : Form
    {
        public static int gridSize;
        public static int emptyBtn;
        public static bool startGame;
        public Form1()
        {
            InitializeComponent();
            startGame = false;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            int.TryParse(gridSizeText.Text, out gridSize);
            if (defaultCheck.Checked == false) int.TryParse(emptyBtnText.Text, out emptyBtn);
            if (gridSize < 2 || gridSize > 10) MessageBox.Show("–азмер пол€ не может быть меньше 3 или больше 10!");
            else if (defaultCheck.Checked == false & emptyBtn == 0 | emptyBtn > gridSize * gridSize) MessageBox.Show($"Ќомер пустой клетки не может быть равен 0 или больше {gridSize * gridSize}!");
            else { startGame = true; Close(); }
        }

        private void defaultCheck_CheckedChanged(object sender, EventArgs e)
        {
            emptyBtnText.Enabled = !defaultCheck.Checked;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}