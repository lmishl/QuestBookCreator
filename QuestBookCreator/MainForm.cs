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

        Project curProj;

        bool flag_node = false;
        bool flag_click = false;
        int raznX = 0, raznY = 0; //для мыши

        public void Redraw()
        {
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            curProj.Paint(e.Graphics);
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            float mouseX = MousePosition.X - this.Location.X - panel1.Location.X - Constants.extraX;
            float mouseY = MousePosition.Y - this.Location.Y - panel1.Location.Y - Constants.extraY;

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
            float mouseX = MousePosition.X - this.Location.X - panel1.Location.X - Constants.extraX;
            float mouseY = MousePosition.Y - this.Location.Y - panel1.Location.Y - Constants.extraY;
            flag_click = true;
            raznX = MousePosition.X;          //текущее смещение
            raznY = MousePosition.Y;

            Node curN = curProj.getNode(mouseX, mouseY);
            if (curN != null)
            {
                flag_node = true;
               
                curProj.curNode = curN;
                Refresh();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            flag_node = flag_click = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag_click)
            {
                if (flag_node)
                    movingNode(curProj.curNode);
                else
                {
                    curProj.movingAll(MousePosition.X - raznX, MousePosition.Y - raznY);
                    raznX = MousePosition.X;
                    raznY = MousePosition.Y;
                }
                Redraw();
            }
        }

        void movingNode(Node k)
        {
            //float mouseX = MousePosition.X - this.Location.X - panel1.Location.X - Constants.extraX;
            //float mouseY = MousePosition.Y - this.Location.Y - panel1.Location.Y - Constants.extraY;

            //k.set_x(mouseX - raznX);
            //k.set_y(mouseY - raznY);
            k.set_x(k.get_x() + MousePosition.X - raznX);
            k.set_y(k.get_y() + MousePosition.Y - raznY);
            raznX = MousePosition.X;
            raznY = MousePosition.Y;
        }

        private void panel1_Click(object sender, EventArgs e)       //тут коменты
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

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "qbc files (*.qbc)|*.qbc|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = saveFileDialog1.FileName;
                curProj.saveAs(s);
                this.Text = s;
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "qbc files (*.qbc)|*.qbc|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string s = openFileDialog1.FileName;
                    curProj = curProj.load(s);
                    this.Text = s;
                    Redraw();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
        }

        private void BuildPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curProj.haveStart == false)
            {
                MessageBox.Show("Необходимо задать стартовый узел");
                return;
            }
            curProj.curNode = curProj.startNode;
            AbstractBuilder bb = new PdfBuilder();
            bb.Create(curProj);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            curProj = Project.Instance();
        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            Paragraph p = new Paragraph();
            curProj.addNode(p);
            Redraw();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curProj.canSave() == true)
            {

                try
                {
                    curProj.save();
                    MessageBox.Show("Сохранено");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
            else SaveAsToolStripMenuItem_Click(sender, e);

        }

        private void DeleteNode_Click(object sender, EventArgs e)
        {
            if (curProj.curNode == null)
            {
                MessageBox.Show("Выберите узел");
                return;
            }

            if (curProj.hasInputEdge(curProj.curNode) == true)
            {
                DialogResult result = MessageBox.Show("На этот параграф есть действующие ссылки. Удалить параграф и все ссылки на него?", "Подтвердите действие",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    curProj.deleteLinksOn(curProj.curNode);
                    curProj.deleteCurNode();
                    Redraw();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить этот узел?", "Подтвердите действие",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    curProj.deleteCurNode();
                    Redraw();
                }
            }
        }

        private void MakeStartButton_Click(object sender, EventArgs e)
        {
            if (curProj.curNode == null)
                MessageBox.Show("Выбери вершину");
            else
            {
                curProj.startNode = curProj.curNode;
                curProj.haveStart = true;
                Redraw();
            }
        }


        private void mainForm_mouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // MessageBox.Show("1");
            


        }

        private void zoomMinus_Click(object sender, EventArgs e)
        {
            if (Constants.minH > curProj.nodeHeight) return;          //уже слишком мелко
            curProj.nodeHeight = curProj.nodeHeight / Constants.changingSpeed;
            curProj.nodeWidth = curProj.nodeWidth / Constants.changingSpeed;
            curProj.zoomMinus();
            Redraw();
            //label1.Text = Constants.nodeHeight.ToString();
            //label2.Text = Constants.nodeWidth.ToString();

        }

        private void zoomPlus_Click(object sender, EventArgs e)
        {
            if (Constants.maxH < curProj.nodeHeight) return;          //уже слишком крупно
            curProj.nodeHeight = curProj.nodeHeight * Constants.changingSpeed;
            curProj.nodeWidth = curProj.nodeWidth * Constants.changingSpeed;
            curProj.zoomPlus();
            Redraw();
            //label1.Text = Constants.nodeHeight.ToString();
            //label2.Text = Constants.nodeWidth.ToString();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curProj = curProj.load("");
            Redraw();

        }

        private void buildHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curProj.haveStart == false)
            {
                MessageBox.Show("Необходимо задать стартовый узел");
                return;
            }
            curProj.curNode = curProj.startNode;
            AbstractBuilder bb = new HtmlBuilder();
            bb.Create(curProj);

        }
    }
}
