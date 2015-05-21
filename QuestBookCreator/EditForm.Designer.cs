namespace QuestBookCreator
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.AddLinkButton = new System.Windows.Forms.Button();
            this.AddImageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(36, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(304, 190);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(320, 250);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton1
            // 
            this.CancelButton1.Location = new System.Drawing.Point(413, 250);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(75, 23);
            this.CancelButton1.TabIndex = 2;
            this.CancelButton1.Text = "Отмена";
            this.CancelButton1.UseVisualStyleBackColor = true;
            this.CancelButton1.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddLinkButton
            // 
            this.AddLinkButton.Location = new System.Drawing.Point(372, 57);
            this.AddLinkButton.Name = "AddLinkButton";
            this.AddLinkButton.Size = new System.Drawing.Size(116, 23);
            this.AddLinkButton.TabIndex = 3;
            this.AddLinkButton.Text = "Добавить переход";
            this.AddLinkButton.UseVisualStyleBackColor = true;
            this.AddLinkButton.Click += new System.EventHandler(this.AddLinkButton_Click);
            // 
            // AddImageButton
            // 
            this.AddImageButton.Location = new System.Drawing.Point(372, 110);
            this.AddImageButton.Name = "AddImageButton";
            this.AddImageButton.Size = new System.Drawing.Size(116, 23);
            this.AddImageButton.TabIndex = 4;
            this.AddImageButton.Text = "Добавить картинку";
            this.AddImageButton.UseVisualStyleBackColor = true;
            this.AddImageButton.Click += new System.EventHandler(this.AddImageButton_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 294);
            this.Controls.Add(this.AddImageButton);
            this.Controls.Add(this.AddLinkButton);
            this.Controls.Add(this.CancelButton1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton1;
        private System.Windows.Forms.Button AddLinkButton;
        private System.Windows.Forms.Button AddImageButton;
    }
}