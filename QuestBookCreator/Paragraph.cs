using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace QuestBookCreator
{
    [Serializable()]
    class Paragraph : Node
    {
        String name;
        int x, y;
        NodeContent nCont;
        public int get_x() { return x; }
        public int get_y() { return y; }
        public void set_x(int p) { x = p; }
        public void set_y(int p) { y = p; }
        public void set_name(string s) { name = s; }
        public int get_name() { return Convert.ToInt32(name); }

        List<Node> children;

        public void Draw(Graphics g)
        {
            Pen p = new Pen(Brushes.DeepSkyBlue);
            g.DrawRectangle(p, x, y, Constants.nodeWidth, Constants.nodeHeight);

            Font drawFont = new Font("Arial", Constants.nodeHeight / 2);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = new PointF((x + 1), y);
            g.DrawString(name, drawFont, drawBrush, drawPoint);

            Edge ed;
            for (int i = 0; i < children.Count; i++)
            {
                ed = new ArrowEdge(this, children[i]);
                ed.Draw(g);
            }

        }

        public void setContent(NodeContent c)
        {
            nCont = c;
        }

        public NodeContent getContent()
        {

            return nCont;
        }

        public Paragraph()          //чепуха
        {
            Random rnd1 = new Random();
            x = rnd1.Next(Constants.panelWidth - Constants.nodeWidth);
            y = rnd1.Next(Constants.panelHeight - Constants.nodeHeight);
            name = rnd1.Next(100).ToString();
            nCont = new TextContent("текст");
            
            children= new List<Node>();


        }

        public void refreshChildren() 
        {
            children = new List<Node>();

            string s = this.getContent().getInfo();

            int link = s.IndexOf("link:");

            while(link!=-1)
            {
                s = s.Substring(link);              //обрезали по начало ссылки
                int reff = s.IndexOf("]|[")+3;
                s = s.Substring(reff);              //обрезали по вершину перехода
                int end_reff = s.IndexOf("]]");
                string name = s.Substring(0, end_reff); //получили вершину
                s = s.Substring(end_reff + 2);        //обрезали до конца ссылки

                Project curProj=Project.Instance();
                Node temp = curProj.getNode(name);
                if (temp!=null)
                    children.Add(temp);


                link = s.IndexOf("link:");
            }

        }
    }
}
