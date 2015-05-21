namespace QuestBookCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FiletoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildHtmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNodeButton = new System.Windows.Forms.Button();
            this.DeleteNode = new System.Windows.Forms.Button();
            this.MakeStartButton = new System.Windows.Forms.Button();
            this.zoomMinusbutton = new System.Windows.Forms.Button();
            this.zoomPlusbutton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(22, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 400);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FiletoolStripMenuItem1,
            this.BuildToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(809, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FiletoolStripMenuItem1
            // 
            this.FiletoolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.SaveToolStripMenuItem});
            this.FiletoolStripMenuItem1.Name = "FiletoolStripMenuItem1";
            this.FiletoolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.FiletoolStripMenuItem1.Text = "Файл";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newToolStripMenuItem.Text = "Новый проект";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.SaveAsToolStripMenuItem.Text = "Сохранить как";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // BuildToolStripMenuItem
            // 
            this.BuildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BuildPdfToolStripMenuItem,
            this.buildHtmlToolStripMenuItem});
            this.BuildToolStripMenuItem.Name = "BuildToolStripMenuItem";
            this.BuildToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.BuildToolStripMenuItem.Text = "Собрать";
            // 
            // BuildPdfToolStripMenuItem
            // 
            this.BuildPdfToolStripMenuItem.Name = "BuildPdfToolStripMenuItem";
            this.BuildPdfToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.BuildPdfToolStripMenuItem.Text = "Собрать в PDF";
            this.BuildPdfToolStripMenuItem.Click += new System.EventHandler(this.BuildPdfToolStripMenuItem_Click);
            // 
            // buildHtmlToolStripMenuItem
            // 
            this.buildHtmlToolStripMenuItem.Name = "buildHtmlToolStripMenuItem";
            this.buildHtmlToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.buildHtmlToolStripMenuItem.Text = "Собрать в HTML";
            this.buildHtmlToolStripMenuItem.Click += new System.EventHandler(this.buildHtmlToolStripMenuItem_Click);
            // 
            // AddNodeButton
            // 
            this.AddNodeButton.Location = new System.Drawing.Point(669, 152);
            this.AddNodeButton.Name = "AddNodeButton";
            this.AddNodeButton.Size = new System.Drawing.Size(116, 23);
            this.AddNodeButton.TabIndex = 3;
            this.AddNodeButton.Text = "Добавить узел";
            this.AddNodeButton.UseVisualStyleBackColor = true;
            this.AddNodeButton.Click += new System.EventHandler(this.AddNodeButton_Click);
            // 
            // DeleteNode
            // 
            this.DeleteNode.Location = new System.Drawing.Point(669, 209);
            this.DeleteNode.Name = "DeleteNode";
            this.DeleteNode.Size = new System.Drawing.Size(116, 23);
            this.DeleteNode.TabIndex = 4;
            this.DeleteNode.Text = "Удалить узел";
            this.DeleteNode.UseVisualStyleBackColor = true;
            this.DeleteNode.Click += new System.EventHandler(this.DeleteNode_Click);
            // 
            // MakeStartButton
            // 
            this.MakeStartButton.Location = new System.Drawing.Point(669, 268);
            this.MakeStartButton.Name = "MakeStartButton";
            this.MakeStartButton.Size = new System.Drawing.Size(116, 23);
            this.MakeStartButton.TabIndex = 5;
            this.MakeStartButton.Text = "Сделать стартовым";
            this.MakeStartButton.UseVisualStyleBackColor = true;
            this.MakeStartButton.Click += new System.EventHandler(this.MakeStartButton_Click);
            // 
            // zoomMinusbutton
            // 
            this.zoomMinusbutton.Location = new System.Drawing.Point(669, 64);
            this.zoomMinusbutton.Name = "zoomMinusbutton";
            this.zoomMinusbutton.Size = new System.Drawing.Size(52, 23);
            this.zoomMinusbutton.TabIndex = 6;
            this.zoomMinusbutton.Text = "-";
            this.zoomMinusbutton.UseVisualStyleBackColor = true;
            this.zoomMinusbutton.Click += new System.EventHandler(this.zoomMinus_Click);
            // 
            // zoomPlusbutton
            // 
            this.zoomPlusbutton.Location = new System.Drawing.Point(733, 64);
            this.zoomPlusbutton.Name = "zoomPlusbutton";
            this.zoomPlusbutton.Size = new System.Drawing.Size(52, 23);
            this.zoomPlusbutton.TabIndex = 7;
            this.zoomPlusbutton.Text = "+";
            this.zoomPlusbutton.UseVisualStyleBackColor = true;
            this.zoomPlusbutton.Click += new System.EventHandler(this.zoomPlus_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 454);
            this.Controls.Add(this.zoomPlusbutton);
            this.Controls.Add(this.zoomMinusbutton);
            this.Controls.Add(this.MakeStartButton);
            this.Controls.Add(this.DeleteNode);
            this.Controls.Add(this.AddNodeButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.mainForm_mouseWheel);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FiletoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.Button AddNodeButton;
        private System.Windows.Forms.ToolStripMenuItem BuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BuildPdfToolStripMenuItem;
        private System.Windows.Forms.Button DeleteNode;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.Button MakeStartButton;
        private System.Windows.Forms.Button zoomMinusbutton;
        private System.Windows.Forms.Button zoomPlusbutton;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildHtmlToolStripMenuItem;
    }
}

