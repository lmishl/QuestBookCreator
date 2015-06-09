using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace QuestBookCreator
{
    [Serializable()]
    public class Project
    {
        Memento mem;
        List<Node> pars = new List<Node>();
        int naming = 0;
        public bool haveStart=false;
        public bool isChanged = false;
        public double nodeWidth = 60;           //размер узла
        public double nodeHeight = 40;
        private Node _curNode=null;
        public Node startNode { set; get; }
        public Node curNode
        {
            get { return _curNode; }
            set 
            {
                _curNode = value;
                pars.Remove(_curNode);
                pars.Insert(0,value);
            }
        }


        private static Project curProj = null;
        protected Project()
        {
            mem = new Memento();
        }
        public static Project Instance()
        {
            if (curProj == null)
            {
                curProj = new Project();
            }

            return curProj;
        }


        protected static void resetInstance(Project pr)
        {
            curProj = pr;
            // curProj.find_max_name();
        }

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

        public Node getNode(int x, int y)
        {
            for (int i = 0; i < pars.Count; i++)
                if ((x >= pars[i].get_x()) && (x <= pars[i].get_x() + nodeWidth) && (y >= pars[i].get_y()) && (y <= pars[i].get_y() + nodeHeight))
                    return pars[i];

            return null;
        }

        public Node getNode(float x, float y)
        {
            return getNode((int)x,(int)y);
        }

        public Node getNode(string name)
        {
            Node t = null;
            for (int i = 0; i < pars.Count; i++)
                if (pars[i].get_name() == name)
                {
                    t = pars[i];
                    break;
                }
            return t;
        }

        public void Paint(Graphics g)
        {
            if (curNode != null)
                curNode.DrawSpec(g);
            for (int i = 0; i < pars.Count; i++)            //рисуем узлы
                pars[i].Draw(g);
            if (startNode != null)
                startNode.DrawSpec2(g);    
        }

        //public void find_max_id()
        //{
        //    int t = -1;
        //    for (int i = 0; i < pars.Count; i++)
        //        if (pars[i].get_id() > t) t = pars[i].get_id();
        //    naming = t + 1;
        //}

        public void saveAs(string s)
        {
            mem.saveProject(this, s);
        }

        public Project load(string path)
        {
            Project pr;

            if (path == "")
            {
                pr = new Project();
            }
            else
            {
                Stream st = File.Open(path, FileMode.Open);
                pr = mem.loadProject(st);
                st.Close();
            }
            resetInstance(pr);
            pr.refreshMem(path);
            
            return curProj;

        }

        public void save()
        {
            mem.saveProject(this);
        }

        public void refreshMem(string s)
        {
            mem = new Memento(s);

        }

        public void deleteCurNode()
        {
            if (curNode == startNode)
            {
                startNode = null;
                haveStart = false;
            }
            pars.Remove(curNode);
            _curNode = null;
        }

        public bool canSave()
        {
            return mem.hasPath();
        }

        public void zoomPlus() 
        { 
            foreach (Node nod in pars)
            {
                nod.set_x((float)(nod.get_x() * Constants.changingSpeed));
                nod.set_y((float)(nod.get_y() * Constants.changingSpeed));
            }
        
        
        }
        public void zoomMinus() 
        {
            foreach (Node nod in pars)
            {
                nod.set_x((float)(nod.get_x() / Constants.changingSpeed));
                nod.set_y((float)(nod.get_y() / Constants.changingSpeed));
            }
        }

        public void movingAll(int xx, int yy)
        {
            foreach (Node nod in pars)
            {
                nod.set_x(nod.get_x() + xx);
                nod.set_y(nod.get_y() + yy);
            }
        }

        public bool hasInputEdge(Node node)
        {
            foreach (Node cur in pars)
            {
                if (cur == node) continue;

                NodeContent nc = cur.getContent();
                if (nc.hasLink(node.get_name()) == true)
                    return true;
            
            
            
            }

            return false;
        }

        /// <summary>
        /// Удаляет все ссылки на параграф Node из всех остальных параграфов
        /// </summary>
        /// <param name="node"></param>
        public void deleteLinksOn(Node node)
        {
            foreach (Node cur in pars)
            {
                if (cur == node) continue;

                NodeContent nc = cur.getContent();
                if (nc.hasLink(node.get_name()) == true)
                {
                    nc.deleteLink(node.get_name());
                    cur.refreshChildren();
                }
            }

            
        }
    }
}
