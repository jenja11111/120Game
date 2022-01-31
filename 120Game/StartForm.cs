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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            pictureBoxIcon1.Image = Properties.Resources.Кнопка;
            pictureBoxIcon2.Image = Properties.Resources.Кнопка;
            Icon = Properties.Resources.BigIcon;

            labelName.Text = "120 Вопросов для октябрят";
        }

        private void StartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Escape)
            {
                if (DialogResult.OK == MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    Application.Exit();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Visible = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игра была создана для Хожовской СШ.\nКод и составляющие разработал: Морозов Е.А.\nДизайн и идея проекта: Морозов А.В.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            QuestionsComponent.readAllFile();
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Visible = false;
        }
    }
}
