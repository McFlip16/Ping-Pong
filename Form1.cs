using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping_Pong
{
    public partial class Form1 : Form
    {
        private Panel paddle1;
        private Panel paddle2;
        private Label ball;
        private Timer gameTimer;
        private int ballDX = 8;
        private int ballDY = 8;
        private int playerSpeed = 40;
        private int aiSpeed = 8;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {
            this.Width = 920;
            this.Height = 650;
            this.Text = "Ping Pong Spēle";

            paddle1 = new Panel
            {
                Width = 20,
                Height = 100,
                BackColor = Color.Blue,
                Location = new Point(30, this.ClientSize.Height / 2 - 50)
            };
            paddle2 = new Panel
            {
                Width = 20,
                Height = 100,
                BackColor = Color.Red,
                Location = new Point(this.ClientSize.Width - 50, this.ClientSize.Height / 2 - 50)
            };

            ball = new Label
            {
                Width = 20,
                Height = 20,
                BackColor = Color.Green,
                Location = new Point(this.ClientSize.Width / 2 - 10, this.ClientSize.Height / 2 - 10)
            };

            this.Controls.Add(paddle1);
            this.Controls.Add(paddle2);
            this.Controls.Add(ball);

            gameTimer = new Timer
            {
                Interval = 20
            };
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            this.KeyDown += GameForm_KeyDown;
            this.KeyUp += GameForm_KeyUp;
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            ball.Left += ballDX;
            ball.Top += ballDY;

            if (ball.Top <= 0 || ball.Bottom >= this.ClientSize.Height)
            {
                ballDY = -ballDY;
            }

            if (ball.Bounds.IntersectsWith(paddle1.Bounds) || ball.Bounds.IntersectsWith(paddle2.Bounds))
            {
                ballDX = -ballDX;
            }

            if (ball.Left <= 0 || ball.Right >= this.ClientSize.Width)
            {
                ball.Left = this.ClientSize.Width / 2 - 10;
                ball.Top = this.ClientSize.Height / 2 - 10;
                ballDX = -ballDX;
            }

            if (ballDY < 0)
            {
                if (paddle2.Top > 0)
                    paddle2.Top -= aiSpeed;
            }
            else if (ballDY > 0)
            {
                if (paddle2.Bottom < this.ClientSize.Height)
                    paddle2.Top += aiSpeed;
            }

            if (paddle1.Top < 0)
                paddle1.Top = 0;

            if (paddle1.Bottom > this.ClientSize.Height)
                paddle1.Top = this.ClientSize.Height - paddle1.Height;
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (paddle1.Top > 0)
                    paddle1.Top -= playerSpeed;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (paddle1.Bottom < this.ClientSize.Height)
                    paddle1.Top += playerSpeed;
            }
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
