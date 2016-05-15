using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace QuestBookCreator
{
    public interface Node
    {
        void Draw(Graphics g);
        int get_x();
        int get_y();
        void setContent(NodeContent c);
        NodeContent getContent();

        int get_name();
        void set_name(string s);
        void set_x(int p);
        void set_y(int p);

        void refreshChildren();
    }
}
