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
            pictureBoxBackground.Controls.Add(pictureBoxStart);
            pictureBoxBackground.Controls.Add(pictureBoxStar1);
            pictureBoxBackground.Controls.Add(pictureBoxStar2);
            pictureBoxBackground.Controls.Add(pictureBoxStar3);
            pictureBoxBackground.Controls.Add(pictureBoxStar4);
            pictureBoxBackground.Controls.Add(pictureBoxStar5);
            pictureBoxBackground.Controls.Add(pictureBoxStar6);
        }

        private async void pictureBoxStart_Click(object sender, EventArgs e)
        {
            pictureBoxStart.Enabled = false;

            StarsController starsController = new StarsController(ref pictureBoxStar1,
                                                                  ref pictureBoxStar2,
                                                                  ref pictureBoxStar3,
                                                                  ref pictureBoxStar4,
                                                                  ref pictureBoxStar5,
                                                                  ref pictureBoxStar6);

            starsController.ZoomStars();

            await Task.Delay(10000);

            pictureBoxStart.Enabled = true;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                pictureBoxStart_Click(pictureBoxStart, null);
            }
            else if (e.KeyValue == (char)Keys.Escape)
            {
                if (DialogResult.OK == MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    Application.Exit();
            }


        }
    }
}
