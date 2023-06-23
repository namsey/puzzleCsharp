using System;
using System.Windows.Forms;

namespace PuzzleGame
{
    public class Puzzle : Form
    {
        private Button b1, b2, b3, b4, b5, b6, b7, b8, b9, next;

        public Puzzle()
        {
            Text = "Puzzle Game - C#";
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            b1 = new Button { Text = "1" };
            b2 = new Button { Text = " " };
            b3 = new Button { Text = "3" };
            b4 = new Button { Text = "4" };
            b5 = new Button { Text = "5" };
            b6 = new Button { Text = "6" };
            b7 = new Button { Text = "7" };
            b8 = new Button { Text = "8" };
            b9 = new Button { Text = "2" };
            next = new Button { Text = "Next" };

            b1.Click += Button_Click;
            b2.Click += Button_Click;
            b3.Click += Button_Click;
            b4.Click += Button_Click;
            b5.Click += Button_Click;
            b6.Click += Button_Click;
            b7.Click += Button_Click;
            b8.Click += Button_Click;
            b9.Click += Button_Click;
            next.Click += Next_Click;

            next.BackColor = System.Drawing.Color.Black;
            next.ForeColor = System.Drawing.Color.Green;

            Controls.Add(b1);
            Controls.Add(b2);
            Controls.Add(b3);
            Controls.Add(b4);
            Controls.Add(b5);
            Controls.Add(b6);
            Controls.Add(b7);
            Controls.Add(b8);
            Controls.Add(b9);
            Controls.Add(next);

            b1.SetBounds(10, 30, 50, 40);
            b2.SetBounds(70, 30, 50, 40);
            b3.SetBounds(130, 30, 50, 40);
            b4.SetBounds(10, 80, 50, 40);
            b5.SetBounds(70, 80, 50, 40);
            b6.SetBounds(130, 80, 50, 40);
            b7.SetBounds(10, 130, 50, 40);
            b8.SetBounds(70, 130, 50, 40);
            b9.SetBounds(130, 130, 50, 40);
            next.SetBounds(70, 200, 100, 40);

            Size = new System.Drawing.Size(250, 300);
            LayoutMdi(MdiLayout.Cascade);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string s = button.Text;
            Button emptyButton = FindEmptyButton();

            if (IsAdjacent(button, emptyButton))
            {
                SwapButtonLabels(button, emptyButton);
                CheckWin();
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            SwapButtonLabels(b1, b5);
            SwapButtonLabels(b4, b9);
            SwapButtonLabels(b2, b7);
        }

        private Button FindEmptyButton()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button && button.Text == " ")
                {
                    return button;
                }
            }
            return null;
        }

        private bool IsAdjacent(Button button1, Button button2)
        {
