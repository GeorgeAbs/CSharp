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
using System.Diagnostics;



namespace Самые_быстрые_кнопки_сетевых_дисков
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double clicksCount = 0;
        double clicksCountSeconds = 0;
        public static string nameOfDradDrop="";
        string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\"+"Пути для быстрых кнопок сетевых дисков.txt", Encoding.GetEncoding(1251));
        string[] settings = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", Encoding.GetEncoding(1251));
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] pathAndnameText = settings[2].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
            string[] position = settings[0].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
            string[] dimensions = settings[1].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string[] backColor = settings[5].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                this.BackColor = Color.FromName(backColor[1]);
            }
            catch { }
            this.Location = new System.Drawing.Point(Convert.ToInt32(position[0]), Convert.ToInt32(position[1]));
            this.ClientSize = new System.Drawing.Size(Convert.ToInt32(pathAndnameText[0]), (lines.Length - 2)*(2+ Convert.ToInt32(pathAndnameText[1]))+20+33); //Convert.ToInt32(dimensions[1]));
            toolTip1.SetToolTip(clicksAccount, "сэкономлено кликов/секунд");
            pictureBox1.Location = new System.Drawing.Point(0, (lines.Length - 2) * (2 + Convert.ToInt32(pathAndnameText[1])) + 20);
            aboutButton.Location = new System.Drawing.Point(Convert.ToInt32(pathAndnameText[0])-20, 0);
            int top = 20;
            int left = 0;
            int i= 2;
            while (i<lines.Length)
            {
                string[] pathAndname = lines[i].Split(new[] {"??"}, StringSplitOptions.RemoveEmptyEntries);
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Name = i.ToString();
                button.Text = pathAndname[1];
                try {
                    string[] style = settings[3].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                    button.Font = new System.Drawing.Font(style[1], Convert.ToInt32(pathAndnameText[2])); } catch { }
                try { button.BackColor = Color.FromName(pathAndname[2]); } catch { };
                try { button.ForeColor = Color.FromName(pathAndname[3]); } catch { };
                button.Size = new System.Drawing.Size(Convert.ToInt32(pathAndnameText[0]), Convert.ToInt32(pathAndnameText[1]));
                button.Visible = true;
                button.Click += ButtonOnClick;
                button.MouseDown += new System.Windows.Forms.MouseEventHandler(ButtonDown);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                this.Controls.Add(button);
                top += button.Height + 2;
                i++;
            }
            try { clicksAccount.Text = settings[6] + @"/" + (double.Parse(settings[6]) * 0.6).ToString() + " (clck/s)"; clicksCount = double.Parse(settings[6]); } catch { }
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {

            if (sender is Button button)
            {
                int i = 2;
                string[] pathAndname = lines[i].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                while (button.Text!= pathAndname[1])
                {
                    pathAndname = lines[i].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                    
                    i++;
                }
                try { Process.Start(pathAndname[0]); } catch { }
                string[] foldersInPath = pathAndname[0].Split(new[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
                clicksCount = clicksCount+ foldersInPath.Length;
                clicksCountSeconds = clicksCount * 0.6;
                clicksAccount.Text = clicksCount.ToString() + @"/" + clicksCountSeconds.ToString() + " (clck/s)";

                settings = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", Encoding.GetEncoding(1251));
                File.Delete(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt");
                using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", true))
                {
                    int ii = 0;
                    
                    while (ii < 6)
                    {
                        sw.WriteLine(settings[ii]);
                        ii++;
                    }
                    sw.WriteLine(clicksCount.ToString());
                    ii = 7;
                    if (ii < settings.Length)
                    {
                        while (ii < settings.Length)
                        {
                            sw.WriteLine(settings[ii]);
                            ii++;
                        }
                    }
                }
            }
        }
        private void ButtonDown (object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X + 10, MousePosition.Y + 10);
            }
        }

        private void добавитьКнопкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form q = new Добавление_кнопки();
            q.Owner = this;
            q.Visible = true;
            q.TopLevel = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X+10, MousePosition.Y+10);
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            settings = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", Encoding.GetEncoding(1251));
            File.Delete(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt");
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", true))
            {
                sw.WriteLine(this.Location.X.ToString() + "??" + this.Location.Y.ToString());
                int i = 1;
                while (i< settings.Length)
                {
                    sw.WriteLine(settings[i]);
                    i++;
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            settings = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", Encoding.GetEncoding(1251));
            File.Delete(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt");
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", true))
            {
                sw.WriteLine(settings[0]);
                sw.WriteLine(ClientSize.Width.ToString() + "??" + ClientSize.Height.ToString());
                int i = 2;
                if (i < settings.Length)
                {
                    while (i < settings.Length)
                    {
                        sw.WriteLine(settings[i]);
                        i++;
                    }
                }
            }
        }

        public void перезагрузитьПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Directory.GetCurrentDirectory() + "\\" + "Самые быстрые кнопки сетевых дисков.exe");
            Close();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form q = new Настройки();
            q.Owner = this;
            q.Visible = true;
            q.TopLevel = true;
        }

        private void управлениеКнопкамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form q = new Управление_кнопками();
            q.Owner = this;
            q.Visible = true;
            q.TopLevel = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X + 10, MousePosition.Y + 10);
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            Form q = new About();
            q.Visible = true;
            q.TopLevel = true;
            q.Show();
        }

        private void сброситьЗначениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", Encoding.GetEncoding(1251));
            File.Delete(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt");
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", true))
            {
                int ii = 0;

                while (ii < 6)
                {
                    sw.WriteLine(settings[ii]);
                    ii++;
                }
                clicksCount = 0;
                clicksCountSeconds = 0;
                clicksAccount.Text = clicksCount.ToString() + @"/" + clicksCountSeconds.ToString() + " (clck/s)";
                sw.WriteLine(clicksCount.ToString());
                ii = 7;
                if (ii < settings.Length)
                {
                    while (ii < settings.Length)
                    {
                        sw.WriteLine(settings[ii]);
                        ii++;
                    }
                }
            }
        }

        private void clicksAccount_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(MousePosition.X + 10, MousePosition.Y + 10);
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] name = (string[])e.Data.GetData(DataFormats.FileDrop);
            nameOfDradDrop = name[0];
            Form q = new Добавление_кнопки();
            q.Owner = this;
            q.Visible = true;
            q.TopLevel = true;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }
    }
}
