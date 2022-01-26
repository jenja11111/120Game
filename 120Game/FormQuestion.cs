using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _120Game
{
    public partial class FormQuestion : Form
    {
        //private Dictionary<int, string> QSecurity = new Dictionary<int, string>();
        //private Dictionary<int, string> QPioneers = new Dictionary<int, string>();
        //private Dictionary<int, string> QNature = new Dictionary<int, string>();
        //private Dictionary<int, string> QMotherland = new Dictionary<int, string>();
        //private Dictionary<int, string> QLogic = new Dictionary<int, string>();
        //private Dictionary<int, string> QHealth = new Dictionary<int, string>();

        string startPath = Application.StartupPath + "\\Questions";
        public int star = 0;
        ImageForm img;

        public FormQuestion()
        {
            InitializeComponent();
        }

        public FormQuestion(int star)
        {
            InitializeComponent();
            this.star = star;
            switch (this.star)
            {
                case 1:                   
                    if (QuestionsComponent.QMotherland.Count == 0)
                        readFile(startPath + "\\Motherland\\Motherland.txt",ref QuestionsComponent.QMotherland);
                    formControlsAdd(startPath + "\\Motherland", ref QuestionsComponent.QMotherland);
                    labelNameQuestion.Text = "Мая радзима - Беларусь!";
                    panelLeft.BackColor = Color.FromArgb(255, 36, 0);
                    panelRight.BackColor = Color.FromArgb(255, 36, 0);
                    panelBottom.BackColor = Color.FromArgb(255, 36, 0);
                    panelTop.BackColor = Color.FromArgb(255, 36, 0);
                    break;
                case 2:
                    if (QuestionsComponent.QHealth.Count == 0)
                        readFile(startPath + "\\Health\\Health.txt", ref QuestionsComponent.QHealth);
                    formControlsAdd(startPath + "\\Health", ref QuestionsComponent.QHealth);
                    labelNameQuestion.Text = "Навстречу ЗОЖ";
                    panelLeft.BackColor = Color.FromArgb(255, 165, 0);
                    panelRight.BackColor = Color.FromArgb(255, 165, 0);
                    panelBottom.BackColor = Color.FromArgb(255, 165, 0);
                    panelTop.BackColor = Color.FromArgb(255, 165, 0);
                    break;
                case 3:
                    if (QuestionsComponent.QSecurity.Count == 0)
                        readFile(startPath+"\\Security\\Security.txt", ref QuestionsComponent.QSecurity);
                    formControlsAdd(startPath + "\\Security", ref QuestionsComponent.QSecurity);
                    labelNameQuestion.Text = "Формула безопасности";
                    panelLeft.BackColor = Color.FromArgb(64, 255, 64);
                    panelRight.BackColor = Color.FromArgb(64, 255, 64);
                    panelBottom.BackColor = Color.FromArgb(64, 255, 64);
                    panelTop.BackColor = Color.FromArgb(64, 255, 64);
                    break;
                case 4:
                    if (QuestionsComponent.QNature.Count == 0)
                        readFile(startPath + "\\Nature\\Nature.txt", ref QuestionsComponent.QNature);
                    formControlsAdd(startPath + "\\Nature", ref QuestionsComponent.QNature);
                    labelNameQuestion.Text = "Беречь природы дар бесценный";
                    panelLeft.BackColor = Color.FromArgb(0, 191, 255);
                    panelRight.BackColor = Color.FromArgb(0, 191, 255);
                    panelBottom.BackColor = Color.FromArgb(0, 191, 255);
                    panelTop.BackColor = Color.FromArgb(0, 191, 255);
                    break;
                case 5:
                    if (QuestionsComponent.QLogic.Count == 0)
                        readFile(startPath + "\\Logic\\Logic.txt", ref QuestionsComponent.QLogic);
                    formControlsAdd(startPath + "\\Logic", ref QuestionsComponent.QLogic);
                    labelNameQuestion.Text = "Логика и внимание";
                    panelLeft.BackColor = Color.FromArgb(83, 61, 171);
                    panelRight.BackColor = Color.FromArgb(83, 61, 171);
                    panelBottom.BackColor = Color.FromArgb(83, 61, 171);
                    panelTop.BackColor = Color.FromArgb(83, 61, 171);
                    break;
                case 6:
                    if (QuestionsComponent.QPioneers.Count == 0)
                        readFile(startPath + "\\Pioneers\\Pioneers.txt", ref QuestionsComponent.QPioneers);
                    formControlsAdd(startPath + "\\Pioneers", ref QuestionsComponent.QPioneers);
                    labelNameQuestion.Text = "Страна \"Пионерия\" ";
                    panelLeft.BackColor = Color.FromArgb(255, 255, 0);
                    panelRight.BackColor = Color.FromArgb(255, 255, 0);
                    panelBottom.BackColor = Color.FromArgb(255, 255, 0);
                    panelTop.BackColor = Color.FromArgb(255, 255, 0);
                    break;
                default:
                    MessageBox.Show("Этого не может быть! Сюда попасть нереально!", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    break;
            }

            labelNameQuestion.Location = new Point(Width / 2 - labelNameQuestion.Width / 2, labelNameQuestion.Location.Y);
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            labelAnswer.Visible = true;
            pictureBoxQRCode.Visible = true;
            buttonAnswer.Visible = false;
            buttonClose.Visible = true;          
        }

        private void readFile(string QPath,ref Dictionary<int, string> Q)
        {
            using (StreamReader sr = new StreamReader(QPath, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] strs = line.Split(';');
                    Q.Add(Convert.ToInt32(strs[0]), strs[1]);
                }
            }
        }

        private void formControlsAdd(string filesPath, ref Dictionary<int, string> Q) 
        {
            while (true)
            {
                Random rnd = new Random();
                int question = rnd.Next(1, 20);
                if (Q.ContainsKey(question))
                {
                    labelQuestion.Text = Q[question];

                    if (File.Exists(filesPath + "\\QCode\\" + question + ".png") || File.Exists(filesPath + "\\QCode\\" + question + ".jpg"))
                    {
                        if (File.Exists(filesPath + "\\QCode\\" + question + ".png"))
                            pictureBoxQRCode.Image = Image.FromFile(filesPath + "\\QCode\\" + question + ".png");
                        else
                            pictureBoxQRCode.Image = Image.FromFile(filesPath + "\\QCode\\" + question + ".jpg");
                    }
                    if (File.Exists(filesPath + "\\Images\\" + question + ".png") || File.Exists(filesPath + "\\Images\\" + question + ".jpg"))
                    {
                        if (File.Exists(filesPath + "\\Images\\" + question + ".png"))
                            img = new ImageForm(Image.FromFile(filesPath + "\\Images\\" + question + ".png"));
                        else
                            img = new ImageForm(Image.FromFile(filesPath + "\\Images\\" + question + ".jpg"));
                        img.Show();
                        img.Location = new Point(800, 300);
                    }

                    Q.Remove(question);
                    break;
                }
            }
            if(Q.Count == 0)
            {
                QuestionsComponent.enableValue[star - 1] = false;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                img.Close();
            }
            Close();       
        }

    }
}
