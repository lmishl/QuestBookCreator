using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using iTextSharp;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

namespace QuestBookCreator
{
    class HtmlBuilder : AbstractBuilder
    {
        public void Create(Project curProj)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.Description =
            "Select the directory that you want to use as the default.";
            folderBrowserDialog1.ShowNewFolderButton = true;
            //folderBrowserDialog1.RootFolder = "c:\\";//Environment.SpecialFolder.Personal;


            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                List<Node> tmp = curProj.get_all();
                HtmlConverter hc = new HtmlConverter();
                string path = folderBrowserDialog1.SelectedPath+"\\";
                string pathToImages=path + "pics";
                System.IO.Directory.CreateDirectory(pathToImages);
                foreach (Node node in tmp)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + node.get_name() + ".html", false, Encoding.UTF8))
                    {
                        file.Write("<html>");
                        file.Write("<body>");
                        List<string> list_str = hc.get_processed(node, pathToImages);
                        foreach (string s in list_str)
                        {
                            file.WriteLine(s);
                        }

                       // file.WriteLine(node.getContent().getInfo());

                        file.Write("</body>");
                        file.Write("</html>");
                    }                    
                }
                MessageBox.Show("ok");
            }
        
        
        
        
        
        }


    }
}
