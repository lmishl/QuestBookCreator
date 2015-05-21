using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBookCreator
{
    [Serializable()]
    class TextContent : NodeContent
    {
        string text;


        public TextContent()
        {

            text = "";
        }

        public TextContent(string p)
        {
           
            text = p;
        }

        public void setInfo(string s)
        { text = s; }

        public string getInfo()
        { return text; }
    }
}
