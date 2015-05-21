using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace QuestBookCreator
{
    public interface Edge
    {

        Node get_v1();
        Node get_v2();
        

        void Draw(Graphics g);

        //Edge(Node vv1, Node vv2);
    }
}
