using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestBookCreator
{
    class HtmlConverter
    {
        public List<string> get_processed(Node curN, string pathToIm)
        {
            string text = curN.getContent().getInfo();
            List<string> list = new List<string>();


            int link=0;
            while (true)
            {
                link = text.IndexOf("[[");       //ищем сложный объект
                if (link == -1)         //сложных объeктов нет, запиливаем текст и выходим
                {
                    list.Add("<h5>");
                    list.Add(text);
                    list.Add("</h5>");
                    break;
                }

                //сложный объект есть!
                if (link != 0)      //если есть текст до объекта
                {
                    //добавb  текст до ссылки     
                    list.Add("<h5>");
                    list.Add(text.Substring(0, link));
                    list.Add("</h5>");

                    text = text.Substring(link);        //обрезали начало
                }

                //обрабатываем сложный объект
                if (text.IndexOf("link:") == 2)    //ссылка
                {
                    //входит строка [[link:name]|[ref]]....
                    string tmp = text;
                    int end_name = tmp.IndexOf("]");
                    string name = tmp.Substring(7, end_name - 7);
                    tmp = tmp.Substring(end_name + 3);
                    int end_ref = tmp.IndexOf("]");
                    string reff = tmp.Substring(0, end_ref);

                   // < a href="http://www.web-lesson.ru/"> Абсолютная ссылка</a>
                    list.Add("<a href=\"" + reff + ".html\">" + name + "</a>");

                }
                else
                    if (text.IndexOf("image:") == 2)    //изображение
                    {
                        string tmp = text;
                        int end_im = tmp.IndexOf("]]");
                        string path = tmp.Substring(8, end_im - 8);
                       // <img src="link_img.png">
                        string imageName = path.Substring(path.LastIndexOf('\\') + 1);
                        string fullPathDest = pathToIm + "\\" + imageName;
                        
                        System.IO.File.Copy(path, fullPathDest, true);

                        string pathForHtml = "pics/" + imageName;
                        list.Add("<img src=\"" + pathForHtml + "\">");

                    }
                    else MessageBox.Show("Bad using [[ or ]]");

                int end = text.IndexOf("]]");
                text = text.Substring(end + 2);


            }
            return list;
        }


    }
}
