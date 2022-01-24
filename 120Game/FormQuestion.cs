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
        Dictionary<int, string> QSecurity = new Dictionary<int, string>();
        string startPath = Application.StartupPath + "\\Questions";
        ImageForm img;

        public FormQuestion()
        {
            InitializeComponent();
        }

        public FormQuestion(int star)
        {
            InitializeComponent();

            switch (star)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    if (QSecurity.Count == 0)
                        readFile(startPath+"\\Security\\Security.txt");
                    formControlsAdd(startPath + "\\Security");
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            labelAnswer.Visible = true;
            buttonAnswer.Visible = false;
            buttonClose.Visible = true;          
        }

        private void readFile(string QPath)
        {
            using (StreamReader sr = new StreamReader(QPath, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] strs = line.Split(';');
                    QSecurity.Add(Convert.ToInt32(strs[0]), strs[1]);
                }
            }
        }

        private void formControlsAdd(string filesPath) 
        {
            Random rnd = new Random();
            int question = rnd.Next(1, 20);
            labelQuestion.Text = QSecurity[question];
            if(File.Exists(filesPath + "\\QCode\\" + question + ".png"))
            {
                pictureBoxQRCode.Image = Image.FromFile(filesPath + "\\QCode\\" + question + ".png");
            }
            if(File.Exists(filesPath + "\\Images\\" + question + ".png"))
            {
                img = new ImageForm(Image.FromFile(filesPath + "\\Images\\" + question + ".png"));                
                img.Show();
                img.Location = new Point(800, 300);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (img != null)
                img.Close();
            Close();     
        }
    }
}
