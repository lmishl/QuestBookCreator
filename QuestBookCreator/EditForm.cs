using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace QuestBookCreator
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        public EditForm(Node k , List<Node> ln)
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
            curNode.getContent().setInfo(richTextBox1.Text);
            this.Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            if (curNode != null)
                richTextBox1.Text = curNode.getContent().getInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddingLink al = new AddingLink(curNode, lnod);
            al.ShowDialog();
            richTextBox1.Text += Constants.str_for_adding_form;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((openFileDialog1.OpenFile()) != null)
                    {
                        richTextBox1.Text += "[[image:" + openFileDialog1.FileName + "]]";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
