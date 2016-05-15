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
    class Proxy
    {
        List<IElement> lElem;
        IElement nextElem;

        public List<IElement> get_processed(Node curN)
        {
            int link=0;
            int cur_sign=0;
            string tmp = curN.getContent().getInfo();
            lElem=new List<IElement>();



            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
           


            Anchor anchor0 = new Anchor(curN.get_name().ToString()+"\n", font);
            anchor0.Name = curN.get_name().ToString();
            lElem.Add(anchor0);


            IElement q=null;

            while (true)
            {
                link = tmp.IndexOf("[[");       //ищем сложный объект


                if (link == -1)         //сложных объуктов нет, запиливаем текст и выходим
                {
                    nextElem = new Phrase(tmp.Substring(cur_sign), font);      
                    lElem.Add(nextElem);
                    break;
                }

                //сложный объект есть!
                if (link != 0)      //если есть текст до объекта
                {
                    nextElem = new Phrase(tmp.Substring(cur_sign, link - cur_sign), font);      //добавили  текст до ссылки     
                    lElem.Add(nextElem);
                    tmp=tmp.Substring(link);        //обрезали начало
                }

                //обрабатываем сложный объект

                if (tmp.IndexOf("link:") == 2)    //ссылка
                    q = link_proccessing(tmp);
                else
                    if (tmp.IndexOf("image:") == 2)    //изображение
                        q = image_proccessing(tmp);
                    else MessageBox.Show("Bad using [[ or ]]");
                    
                lElem.Add(q);

                int end = tmp.IndexOf("]]");
                tmp = tmp.Substring(end + 2);
            }

            return lElem;
        }

        IElement link_proccessing(string s)     //входит строка [[link:name]|[ref]]....
        {
            Anchor e = null;
            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font_link = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.ITALIC);

            int end_name = s.IndexOf("]");
            string name = s.Substring(7, end_name - 7);

            ///Тут короче проверки на корректную ссылку
            ///
            //////////..........
            //.............
            ///
            s = s.Substring(end_name + 3);
            int end_ref = s.IndexOf("]");
            string reff = s.Substring(0, end_ref);
            e = new Anchor(name, font_link);
            e.Reference = "#" + reff;

            return e;
        }

        IElement image_proccessing(string s)    //входит строка [[image:name]]....
        {
            
            int end = s.IndexOf("]]");
            string path = s.Substring(8, end-8);
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(path);
            jpg.Alignment = Element.ALIGN_CENTER;

            return jpg;
        }

    }
}
