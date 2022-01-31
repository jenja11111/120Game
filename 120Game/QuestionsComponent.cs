using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _120Game
{
    public static class QuestionsComponent
    {
        public static Dictionary<int, string> QSecurity = new Dictionary<int, string>();
        public static Dictionary<int, string> QPioneers = new Dictionary<int, string>();
        public static Dictionary<int, string> QNature = new Dictionary<int, string>();
        public static Dictionary<int, string> QMotherland = new Dictionary<int, string>();
        public static Dictionary<int, string> QLogic = new Dictionary<int, string>();
        public static Dictionary<int, string> QHealth = new Dictionary<int, string>();

        public static bool[] enableValue = new bool[] { true, true, true, true, true, true};

        public static void writeAllFile()
        {
            writeFile(ref QSecurity, Application.StartupPath + "\\Questions" + "\\Security" +"\\Save.txt");
            writeFile(ref QPioneers, Application.StartupPath + "\\Questions" + "\\Pioneers" + "\\Save.txt");
            writeFile(ref QNature, Application.StartupPath + "\\Questions" + "\\Nature" + "\\Save.txt");
            writeFile(ref QMotherland, Application.StartupPath + "\\Questions" + "\\Motherland" + "\\Save.txt");
            writeFile(ref QLogic, Application.StartupPath + "\\Questions" + "\\Logic" + "\\Save.txt");
            writeFile(ref QHealth, Application.StartupPath + "\\Questions" + "\\Health" + "\\Save.txt");
        }

        public static void readAllFile()
        {
            if (File.Exists(Application.StartupPath + "\\Questions" + "\\Security" + "\\Save.txt"))
                readFile(Application.StartupPath + "\\Questions" + "\\Security" + "\\Save.txt", ref QSecurity);
            if (File.Exists(Application.StartupPath + "\\Questions" + "\\Pioneers" + "\\Save.txt"))
                readFile(Application.StartupPath + "\\Questions" + "\\Pioneers" + "\\Save.txt", ref QPioneers);
            if (File.Exists(Application.StartupPath + "\\Questions" + "\\Nature" + "\\Save.txt"))
                readFile(Application.StartupPath + "\\Questions" + "\\Nature" + "\\Save.txt", ref QNature);
            if (File.Exists(Application.StartupPath + "\\Questions" + "\\Motherland" + "\\Save.txt"))
                readFile(Application.StartupPath + "\\Questions" + "\\Motherland" + "\\Save.txt", ref QMotherland);
            if (File.Exists(Application.StartupPath + "\\Questions" + "\\Logic" + "\\Save.txt"))
                readFile(Application.StartupPath + "\\Questions" + "\\Logic" + "\\Save.txt", ref QLogic);
            if (File.Exists(Application.StartupPath + "\\Questions" + "\\Health" + "\\Save.txt"))
                readFile(Application.StartupPath + "\\Questions" + "\\Health" + "\\Save.txt", ref QHealth);
        }

        private static void readFile(string QPath, ref Dictionary<int, string> Q)
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

        private static void writeFile(ref Dictionary<int, string> Q, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach(var item in Q)
                {
                    sw.WriteLine(item.Key + ";" + item.Value);
                }
            }
        }
    }
}
