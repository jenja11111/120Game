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
