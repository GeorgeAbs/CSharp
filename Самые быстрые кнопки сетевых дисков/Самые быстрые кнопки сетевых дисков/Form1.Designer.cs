
namespace Самые_быстрые_кнопки_сетевых_дисков
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьКнопкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеКнопкамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clicksAccount = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.сброситьЗначениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьКнопкуToolStripMenuItem,
            this.управлениеКнопкамиToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(206, 70);
            // 
            // добавитьКнопкуToolStripMenuItem
            // 
            this.добавитьКнопкуToolStripMenuItem.Name = "добавитьКнопкуToolStripMenuItem";
            this.добавитьКнопкуToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.добавитьКнопкуToolStripMenuItem.Text = "Добавить кнопку";
            this.добавитьКнопкуToolStripMenuItem.Click += new System.EventHandler(this.добавитьКнопкуToolStripMenuItem_Click);
            // 
            // управлениеКнопкамиToolStripMenuItem
            // 
            this.управлениеКнопкамиToolStripMenuItem.Name = "управлениеКнопкамиToolStripMenuItem";
            this.управлениеКнопкамиToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.управлениеКнопкамиToolStripMenuItem.Text = "Управление кнопками";
            this.управлениеКнопкамиToolStripMenuItem.Click += new System.EventHandler(this.управлениеКнопкамиToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // clicksAccount
            // 
            this.clicksAccount.AutoSize = true;
            this.clicksAccount.Location = new System.Drawing.Point(2, 3);
            this.clicksAccount.Name = "clicksAccount";
            this.clicksAccount.Size = new System.Drawing.Size(24, 13);
            this.clicksAccount.TabIndex = 1;
            this.clicksAccount.Text = "0/0";
            this.clicksAccount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clicksAccount_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 396);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(62, -1);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(14, 20);
            this.aboutButton.TabIndex = 3;
            this.aboutButton.Text = "?";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сброситьЗначениеToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(187, 26);
            // 
            // сброситьЗначениеToolStripMenuItem
            // 
            this.сброситьЗначениеToolStripMenuItem.Name = "сброситьЗначениеToolStripMenuItem";
            this.сброситьЗначениеToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.сброситьЗначениеToolStripMenuItem.Text = "Сбросить значение";
            this.сброситьЗначениеToolStripMenuItem.Click += new System.EventHandler(this.сброситьЗначениеToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(348, 449);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.clicksAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = new System.Drawing.Point(20000, 20000);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьКнопкуToolStripMenuItem;
        private System.Windows.Forms.Label clicksAccount;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеКнопкамиToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem сброситьЗначениеToolStripMenuItem;
    }
}

