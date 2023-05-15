namespace OOP_Game15
{
    abstract class Puzzle
    {
        protected Button[,] buttons;
        protected Random random = new Random();
        protected int gridSize { get; }
        protected int EmptyButton { get; }
        protected int spaceX, spaceY;
        protected Control.ControlCollection controls { get; }
        public Puzzle(Control.ControlCollection controls, int gridSize, int emptyButton) { this.controls = controls; this.gridSize = gridSize; this.EmptyButton = EmptyButton = emptyButton; }
        public abstract void Initialize();
        public abstract void Move(object sender, EventArgs e);
        public abstract void CheckIfSolved();
        public abstract void Shuffle();
    }

    class Game15 : Puzzle
    {
        public Game15(Control.ControlCollection controls, int gridSize, int emptyButton) : base(controls, gridSize, emptyButton) { }
        int count;
        public override void Initialize()
        {
            buttons = new Button[gridSize, gridSize];
            count = 1;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Text = (count).ToString(),
                        Location = new Point(j * 60 + 10, i * 60 + 10),
                        Size = new Size(50, 50),
                    };
                    count++;
                    if ((i * gridSize + j + 1) == EmptyButton)
                    {
                        buttons[i, j].Text = "";
                        buttons[i, j].Enabled = false;
                        spaceX = j;
                        spaceY = i;
                        count--;
                    }
                    buttons[i, j].Click += Move;
                    controls.Add(buttons[i, j]);
                }
            }
        }

        public override void Move(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int bX = button.Location.X / 60;
            int bY = button.Location.Y / 60;
            if (Math.Abs(buttons[spaceY, spaceX].Location.X / 60 - bX) + Math.Abs(buttons[spaceY, spaceX].Location.Y / 60 - bY) != 1) return;
            SwapButtons(buttons[spaceY, spaceX], button, 100);
        }

        private void SwapButtons(Button b1, Button b2, int fps)
        {
            int dx = b2.Left - b1.Left;
            int dy = b2.Top - b1.Top;
            int steps = 15;
            int stepX = dx / steps;
            int stepY = dy / steps;
            int currentStep = 0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += (sender, e) =>
            {
                if (currentStep >= steps)
                {
                    timer.Stop();
                    CheckIfSolved();
                    return;
                }
                b1.Left += stepX;
                b1.Top += stepY;
                b2.Left -= stepX;
                b2.Top -= stepY;
                currentStep++;
            };
            timer.Interval = 1;
            timer.Start();
        }

        public override void CheckIfSolved()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (buttons[i, j].Text == "") continue;
                    if (int.Parse(buttons[i,j].Text) != (buttons[i, j].Location.X / 60 + buttons[i, j].Location.Y / 60 * gridSize + 1)) return;
                }
            }
            MessageBox.Show("Вы выиграли!"); Shuffle();
        }

        public override void Shuffle()
        {
            do
            {
                for (int i = 0; i < gridSize * gridSize; i++)
                {
                    Button b1 = buttons[random.Next(gridSize), random.Next(gridSize)];
                    Button b2 = buttons[random.Next(gridSize), random.Next(gridSize)];
                    if (b1.Text == "" || b2.Text == "") continue;
                    SwapButtons(b1, b2);
                }
            } while (!IsSolvable());
        }

        private bool IsSolvable()
        {
            int inversions = GetInversions();
            if (gridSize % 2 == 1) return inversions % 2 == 0;
            int blankRow = spaceY;
            if (blankRow % 2 == 0) return inversions % 2 == 1;
            return inversions % 2 == 0;
        }

        private int GetInversions()
        {
            int[] linear = buttons.Cast<Button>().Select(b => int.TryParse(b.Text, out int num) ? num : 0).ToArray();
            int inversions = 0;

            for (int i = 0; i < gridSize * gridSize - 1; i++)
            {
                for (int j = i + 1; j < gridSize * gridSize; j++)
                {
                    if (linear[i] != 0 && linear[j] != 0 && linear[i] > linear[j]) inversions++;
                }
            }
            return inversions;
        }

        private void SwapButtons(Button b1, Button b2)
        {
            string tempText = b1.Text;
            bool tempEnabled = b1.Enabled;
            b1.Text = b2.Text;
            b1.Enabled = b2.Enabled;
            b2.Text = tempText;
            b2.Enabled = tempEnabled;
        }
    }

    public class Program : Form
    {
        public Program(int a, int b)
        {
            Text = "Игра 15";
            Size = new Size(a * 60 + 25, a * 60 + 50);
            Game15 game;
            if (b == 0) game = new Game15(Controls,a,a*a);
            else game = new Game15(Controls, a, b);
            game.Initialize();
            game.Shuffle();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if (Form1.startGame) Application.Run(new Program(Form1.gridSize, Form1.emptyBtn));
        }
    }
}