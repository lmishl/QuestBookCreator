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
        float x, y;
        NodeContent nCont;
        public float get_x() { return x; }
        public float get_y() { return y; }
        public void set_x(float p) { x = p; }
        public void set_y(float p) { y = p; }
        public void set_name(string s) { name = s; }
        public int get_name() { return Convert.ToInt32(name); }

        List<Node> children;

        public void DrawSpec(Graphics g)
        {
            DrawRectSpec(g);
            DrawName(g);
            DrawEdges(g);
        }

        public void Draw(Graphics g)
        {
            DrawRect(g);
            DrawName(g);
            DrawEdges(g);
        }

        public void DrawSpec2(Graphics g)
        {
            DrawRect(g);
            DrawName(g);
            DrawEdges(g);
            DrawStart(g);
        }

        public void DrawStart(Graphics g)
        {
            Project curPr = Project.Instance();
            Font drawFont = new Font("Arial", (int)(curPr.nodeHeight / 4));
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = new PointF((x + 1), (float)(y + curPr.nodeHeight * 2 / 3));
            g.DrawString("start", drawFont, drawBrush, drawPoint);

        }

        public void DrawEdges(Graphics g)
        {
            Edge ed;
            for (int i = 0; i < children.Count; i++)
            {
                ed = new ArrowEdge(this, children[i]);
                ed.Draw(g);
            }
        }

        public void DrawName(Graphics g)
        {
            Project curPr = Project.Instance();
            Font drawFont = new Font("Arial", (int)(curPr.nodeHeight / 2));
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = new PointF((x + 1), y);
            g.DrawString(name, drawFont, drawBrush, drawPoint);


        }

        public void DrawRect(Graphics g)
        {
            Project curPr = Project.Instance();
            Pen p = new Pen(Brushes.DeepSkyBlue);
            g.DrawRectangle(p, x, y, (int)curPr.nodeWidth, (int)curPr.nodeHeight);
        }

        public void DrawRectSpec(Graphics g)
        {
            Project curPr = Project.Instance();
            Pen p = new Pen(Brushes.DeepSkyBlue);
            g.FillRectangle(Brushes.Aqua, x, y, (int)curPr.nodeWidth, (int)curPr.nodeHeight);
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
            Project curPr = Project.Instance();
            Random rnd1 = new Random();
            x = (float)rnd1.Next((int)(Constants.panelWidth - curPr.nodeWidth));
            y = (float)rnd1.Next((int)(Constants.panelHeight - curPr.nodeHeight));
            name = rnd1.Next(100).ToString();
            nCont = new TextContent("текст");

            children = new List<Node>();


        }

        public void refreshChildren()
        {
            children = new List<Node>();

            string s = this.getContent().getInfo();

            int link = s.IndexOf("link:");

            while (link != -1)
            {
                s = s.Substring(link);              //обрезали по начало ссылки
                int reff = s.IndexOf("]|[") + 3;
                s = s.Substring(reff);              //обрезали по вершину перехода
                int end_reff = s.IndexOf("]]");
                string name = s.Substring(0, end_reff); //получили вершину
                s = s.Substring(end_reff + 2);        //обрезали до конца ссылки

                Project curProj = Project.Instance();
                Node temp = curProj.getNode(name);
                if (temp != null)
                    children.Add(temp);


                link = s.IndexOf("link:");
            }

        }
    }
}
