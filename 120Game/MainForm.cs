using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _120Game
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.Icon;

            pictureBoxBackground.Controls.Add(pictureBoxStart);

            pictureBoxStart.Size = new Size((int)(Width / 2.5), (int)(Height / 1.75));
            pictureBoxStart.Location = new Point(Width / 2 - pictureBoxStart.Width / 2, Height / 2 - (int)(pictureBoxStart.Height / 1.6));

            //ControlsLoad(ref pictureBoxStart, new Size((int)(Width / 2.5), (int)(Height / 1.75)),
            //    new Point(Width / 2 - pictureBoxStart.Width / 2, Height / 2 - (int)(pictureBoxStart.Height / 1.6))); //почему-то сдвигается ????

            pictureBoxBackground.Controls.Add(pictureBoxButtonStart);

            pictureBoxButtonStart.Location = new Point(Width / 2 - pictureBoxButtonStart.Width / 2, Height - Height / 6);

            pictureBoxBackground.Controls.Add(pictureBoxStar1);

            pictureBoxStar1.Size = new Size((int)(Width / 5.5), (int)(Height / 3.5));
            pictureBoxStar1.Location = new Point(Width / 10, Height - (int)(Height / 3));

            pictureBoxBackground.Controls.Add(pictureBoxStar2);

            pictureBoxStar2.Size = new Size((int)(Width / 5.5), (int)(Height / 3.5));
            pictureBoxStar2.Location = new Point(Width / 30, Height / 2 - pictureBoxStar2.Height / 2);

            pictureBoxBackground.Controls.Add(pictureBoxStar3);

            pictureBoxStar3.Size = new Size((int)(Width / 5.5), (int)(Height / 3.5));
            pictureBoxStar3.Location = new Point(Width / 10, Height / 30);

            pictureBoxBackground.Controls.Add(pictureBoxStar4);

            pictureBoxStar4.Size = new Size((int)(Width / 5.5), (int)(Height / 3.5));
            pictureBoxStar4.Location = new Point(Width - Width / 10 - pictureBoxStar4.Width, Height / 30);

            pictureBoxBackground.Controls.Add(pictureBoxStar5);

            pictureBoxStar5.Size = new Size((int)(Width / 5.5), (int)(Height / 3.5));
            pictureBoxStar5.Location = new Point(Width - Width / 30 - pictureBoxStar5.Width, Height / 2 - pictureBoxStar2.Height / 2);

            pictureBoxBackground.Controls.Add(pictureBoxStar6);

            pictureBoxStar6.Size = new Size((int)(Width / 5.5), (int)(Height / 3.5));
            pictureBoxStar6.Location = new Point(Width - Width / 10 - pictureBoxStar6.Width, Height - (int)(Height / 3));
        }

        private void ControlsLoad(ref PictureBox pBox, Size size, Point point) //Метод для инициализации каждой звезды, но почему-то работает криво.
        {
            pictureBoxBackground.Controls.Add(pBox);

            pBox.Size = size;
            pBox.Location = point;
        }

        private async void pictureBoxStart_Click(object sender, EventArgs e)
        {
            pictureBoxStart.Enabled = false;
            pictureBoxButtonStart.Enabled = false;

            StarsController starsController = new StarsController(ref pictureBoxStar1,
                                                                  ref pictureBoxStar2,
                                                                  ref pictureBoxStar3,
                                                                  ref pictureBoxStar4,
                                                                  ref pictureBoxStar5,
                                                                  ref pictureBoxStar6);

            starsController.ZoomStars();


            await Task.Delay(10000);

            pictureBoxStart.Enabled = true;
            pictureBoxButtonStart.Enabled = true;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter && pictureBoxStart.Enabled)
            {
                pictureBoxStart_Click(pictureBoxStart, null);
            }
            else if (e.KeyValue == (char)Keys.Escape)
            {
                DialogResult dR = MessageBox.Show("Хотите сохранить игру?", "Подтверждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (DialogResult.Yes == dR)
                {
                    QuestionsComponent.writeAllFile();
                    Application.Exit();
                }      
                else if(DialogResult.No == dR)
                {
                    Application.Exit();
                }
            }
        }
    }
}
