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
    class PdfBuilder : AbstractBuilder
    {
        public void Create(Project curProj)
        {
            var doc = new Document();
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    PdfWriter.GetInstance(doc, myStream);
                    doc.Open();
                    List<Node> tmp = curProj.get_all();

                    List<IElement> lElem;
                    PdfConverter pr = new PdfConverter();

                    for (int i = 0; i < tmp.Count; i++)
                    {
                        lElem = pr.get_processed(tmp[i]);

                        for (int j = 0; j < lElem.Count; j++)
                        {
                            doc.Add(lElem[j]);
                        }
                        doc.NewPage(); 
                    }

                    doc.Close();
                    MessageBox.Show("ok");
                }
            }
        }
    }
}
