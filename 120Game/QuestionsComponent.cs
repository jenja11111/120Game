using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
