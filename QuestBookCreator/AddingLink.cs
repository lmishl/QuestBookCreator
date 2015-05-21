using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestBookCreator
{
    public partial class AddingLink : Form
    {
        public AddingLink()
        {
            InitializeComponent();
        }

        public AddingLink(Node k, List<Node> ln)
        {
            InitializeComponent();
            curNode = k;
            lnod = ln;
        }

        Node curNode;
        List<Node> lnod;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.SelectedItem != null)
            {
                Constants.str_for_adding_form = "\n[[link:" + textBox1.Text + "]|[" + comboBox1.SelectedItem.ToString() + "]]";
                this.Close();
            }
            else
            MessageBox.Show("Error");
            //Owner.
        }

        private void AddingLink_Load(object sender, EventArgs e)
        {
            Constants.str_for_adding_form = "";
            for (int i = 0; i < lnod.Count; i++)
                comboBox1.Items.Add(lnod[i].get_name());

        }
    }
}
