using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBookCreator
{
    [Serializable()]
    public class NodeContent
    {
        string text;


        public NodeContent()
        {

            text = "";
        }

        public NodeContent(string p)
        {

            text = p;
        }

        public void setInfo(string s)
        { text = s; }

        public string getInfo()
        { return text; }

        public bool hasLink(string name)
        {
            string temp = text;
            int index = temp.IndexOf("[[link:");
            while (index != -1)
            {
                temp = temp.Substring(index);       //обрезаем всё до ссылки
                index = temp.IndexOf("]|[");
                temp = temp.Substring(index + 3);   //обрезаем до начала name
                int endIndex = temp.IndexOf("]]");
                string linkName = temp.Substring(0, endIndex);

                if (name == linkName)
                    return true;


                index = temp.IndexOf("[[link:");
            }


            return false;
        }



        public void deleteLink(string name)
        {
            string newText = "";
            string temp = text;

            int startIndex = temp.IndexOf("[[link:");
            while (startIndex != -1)
            {

                newText += temp.Substring(0, startIndex);       //записали всё до ссылки
                temp = temp.Substring(startIndex);       //обрезаем всё до ссылки


                int mediumIndex = temp.IndexOf("]|[");
                string allLink = temp.Substring(0, mediumIndex + 3);
                temp = temp.Substring(mediumIndex + 3);   //обрезаем до начала name
                int endIndex = temp.IndexOf("]]");
                string linkName = temp.Substring(0, endIndex);
                allLink += linkName + "]]";
                temp = temp.Substring(endIndex + 2);

                if (name != linkName)
                    newText += allLink;

                startIndex = temp.IndexOf("[[link:");
            }

            newText += temp;        //дописываем остаток, в котором уже нет ссылок

            text = newText;     //перезапись всего контента
            
        }


    }
}
