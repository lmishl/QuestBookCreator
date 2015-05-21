using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

namespace QuestBookCreator
{
    class Constants
    {
        public static int panelWidth = 600;         //размер панели
        public static int panelHeight = 400;
        
        public static float extraX = 10;          //границы и т.д.
        public static float extraY = 30;
        public static string str_for_adding_form = "";
        public static double changingSpeed = 1.2;
        public static double maxH = 50;
        public static double minH = 10;

       // public static string str_for_adding_image = "";


       
    }
}
