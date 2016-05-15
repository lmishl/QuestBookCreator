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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Project curProj;// = Project.Instance();

        bool flag = false;
        //bool edgeFlag = false;
        //Node nod_for_edge;
        Node tmp_node;
        int raznX = 0, raznY = 0; //для мыши

        public void Redraw()
        {
            panel1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)          //это кнопка create node
        {
            Paragraph p = new Paragraph();
            curProj.addNode(p);
            Redraw();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            curProj.Paint(e.Graphics);
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            int mouseX = MousePosition.X - this.Location.X - panel1.Location.X - Constants.extraX;
            int mouseY = MousePosition.Y - this.Location.Y - panel1.Location.Y - Constants.extraY;

            Node curN = curProj.getNode(mouseX, mouseY);
            if (curN != null)
            {
                EditForm ef = new EditForm(curN, curProj.get_all());
                ef.ShowDialog();
                curN.refreshChildren();
                Redraw();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = MousePosition.X - this.Location.X - panel1.Location.X - Constants.extraX;
            int mouseY = MousePosition.Y - this.Location.Y - panel1.Location.Y - Constants.extraY;


            Node curN = curProj.getNode(mouseX, mouseY);
            if (curN != null)
            {
                flag = true;
                tmp_node = curN;
                raznX = mouseX - curN.get_x();
                raznY = mouseY - curN.get_y();
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                movingNode(tmp_node);
                Redraw();
            }
        }

        void movingNode(Node k)
        {
            int mouseX = MousePosition.X - this.Location.X - panel1.Location.X - Constants.extraX;
            int mouseY = MousePosition.Y - this.Location.Y - panel1.Location.Y - Constants.extraY;

            k.set_x(mouseX - raznX);
            k.set_y(mouseY - raznY);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //int mouseX = MousePosition.X - this.Location.X - panel1.Location.X - Constants.extraX;
            //int mouseY = MousePosition.Y - this.Location.Y - panel1.Location.Y - Constants.extraY;


            //Node curN = curProj.getNode(mouseX, mouseY);
            //if (curN != null)
            //{
            //    if (edgeFlag == true)
            //    {
            //        if (nod_for_edge == curN)
            //        {
            //            edgeFlag = false;
            //            return;
            //        }
            //        Edge q = new ArrowEdge(nod_for_edge, curN);
            //        curProj.addEdge(q);
            //        edgeFlag = false;
            //        Redraw();

            //    }
            //    else
            //    {
            //        nod_for_edge = curN;
            //        edgeFlag = true;
            //    }

            //}
            //else
            //{
            //    edgeFlag = false;
            //}



        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(myStream, curProj);
                    myStream.Close();
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            BinaryFormatter deserializer = new BinaryFormatter();
                            curProj = (Project)deserializer.Deserialize(myStream);
                            curProj.find_max_name();
                            Project.resetInstance(curProj);
                            myStream.Close();
                            Redraw();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void собратьКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookBuilder bb = new BookBuilder();
            bb.Create(curProj);
  
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           curProj = Project.Instance();
        }



    }
}
