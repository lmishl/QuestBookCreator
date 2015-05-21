using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace QuestBookCreator
{
    [Serializable()]
    class ArrowEdge : Edge
    {

        //char color;
        Node v1, v2;

        public Node get_v1()
        {
            return v1;
        }


        public Node get_v2()
        {
            return v2;
        }

        public void Draw(Graphics g)
        {
            //double r, r1, r2, k;
            //double xx1, yy1, xx2, yy2;
            Project curPr = Project.Instance();
            double x1 = v1.get_x() + curPr.nodeWidth;
            double y1 = v1.get_y() + curPr.nodeHeight / 2;
            double x2 = v2.get_x();
            double y2 = v2.get_y() + curPr.nodeHeight / 2;

            //r = Math.Sqrt(Convert.ToDouble((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
            //r1 = 11;
            //r2 = r1 + 15;

            //k = r / r1;

            //xx1 = (x1 * 1.0 + k * x2) / (1 + k);
            //yy1 = (y1 + k * y2) / (1 + k);

            //k = r / r2;

            //xx2 = (x1 + k * x2) / (1 + k);
            //yy2 = (y1 + k * y2) / (1 + k);

            //double raznX = xx1 - xx2, raznY = yy1 - yy2;

            //double newX = (-1) * (Math.Sqrt(3.0) / 2) * raznX + (-1) * 1.0 / 2 * raznY;
            //double newY = 1.0 / 2 * raznX + (-1) * (Math.Sqrt(3.0) / 2) * raznY;

            //double newX1 = (-1) * (Math.Sqrt(3.0) / 2) * raznX + 1.0 / 2 * raznY;
            //double newY1 = (-1) * 1.0 / 2 * raznX + (-1) * (Math.Sqrt(3.0) / 2) * raznY;


           // int bold = 1;
            Pen p = new Pen(Brushes.DeepSkyBlue);
            
            // g.DrawLine(p,new Point(x1,y1),new Point(x2,y2));
            g.DrawLine(p, (float)x1, (float)y1, (float)x2, (float)y2);
            //g.DrawLine(p, xx1, yy1, newX + xx1, newY + yy1);

            //g.DrawLine(gcnew System::Drawing::Pen(System::Drawing::Color::DarkBlue,bold), x1, y1, x2, y2);
            //g.DrawLine(gcnew System::Drawing::Pen(System::Drawing::Color::DarkBlue,bold), xx1, yy1, newX+xx1 , newY+yy1);
            //g.DrawLine(gcnew System::Drawing::Pen(System::Drawing::Color::DarkBlue,bold), xx1, yy1, newX1+xx1 , newY1+yy1);

            //if (x1 == x2 && y1 == y2)
            //    g->DrawEllipse(gcnew System::Drawing::Pen(System::Drawing::Color::DarkBlue,bold), x1 - 3, y1 - 14, 19, 27);




        }

        public ArrowEdge(Node vv1, Node vv2)
        {
            v1 = vv1;
            v2 = vv2;
        }
    }
}
