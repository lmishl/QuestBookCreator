using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace QuestBookCreator
{
    [Serializable()]
    public class Project
    {
        private static Project curProj=null;


        protected   Project() {  }
        public static Project Instance()
        {
            if (curProj == null)
            {
                curProj = new Project();
            }

            return curProj;
        }

        public static void resetInstance(Project pr)
        {
            curProj = pr;
        }


        List<Node> pars = new List<Node>();
        List<Edge> edges = new List<Edge>();
        static int naming = 0;

        public List<Node> get_all()
        {
            return pars;
        }

        public void addNode(Node k)
        {
            k.set_name(naming.ToString());
            pars.Add(k);
            naming++;


        }

        public void addEdge(Edge e)
        {
            edges.Add(e);

        }

        public Node getNode(int x, int y)
        {
            int w = Constants.nodeWidth;
            int h = Constants.nodeHeight;


            for (int i = 0; i < pars.Count; i++)
                if ((x >= pars[i].get_x()) && (x <= pars[i].get_x() + w) && (y >= pars[i].get_y()) && (y <= pars[i].get_y() + h))
                    return pars[i];

            return null;
        }

        public Node getNode(string name)
        {
            Node t = null;
            for (int i = 0; i < pars.Count; i++)
                if (pars[i].get_name().ToString() == name)
                {
                    t = pars[i];
                    break;
                }

            return t;
        }

        public void Paint(Graphics g)
        {

            for (int i = 0; i < pars.Count; i++)            //рисуем узлы
                pars[i].Draw(g);

            for (int i = 0; i < edges.Count; i++)            //рисуем узлы
                edges[i].Draw(g);
        }

        public void find_max_name()
        {
            int t = -1;
            for (int i = 0; i < pars.Count; i++)
                if (pars[i].get_name() > t) t = pars[i].get_name();
            naming = t + 1;
            //  return t + 1;
        }
    }
}
