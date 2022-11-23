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
    public partial class Управление_кнопками : Form
    {
        public Управление_кнопками()
        {
            InitializeComponent();
            listBox1.SetSelected(0, true);
            listBox2.SetSelected(0, true);
        }
        string colourOfButton;
        string colourOfButtonText;
        Button but;
        Control butControl;
        MyButton button;
        string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Пути для быстрых кнопок сетевых дисков.txt", Encoding.GetEncoding(1251));
        string[] settings = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", Encoding.GetEncoding(1251));

        private void Управление_кнопками_Load(object sender, EventArgs e)
        {
            try
            {
                string[] backColor = settings[5].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                this.BackColor = Color.FromName(backColor[1]);
            }
            catch { } //цвет формы
            int top = 50;
            int left = 2;
            int i = 2;
            while (i < lines.Length)
            {
                string[] pathAndname = lines[i].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                string[] pathAndnameText = settings[2].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                MyButton button = new MyButton();
                button.Left = left;
                button.Top = top;
                button.Tag = pathAndname[0];
                button.Name = "order".ToString();
                button.Text = pathAndname[1];
                try
                {
                    string[] style = settings[3].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                    button.Font = new System.Drawing.Font(style[1], Convert.ToInt32(pathAndnameText[2]));
                }
                catch { }
                try { button.BackColor = Color.FromName(pathAndname[2]); } catch { };
                try { button.ForeColor = Color.FromName(pathAndname[3]); } catch { };
                button.Size = new System.Drawing.Size(Convert.ToInt32(pathAndnameText[0]), Convert.ToInt32(pathAndnameText[1]));
                button.Visible = true;
                button.Click += ButtonOnDelete;
                this.Controls.Add(button);
                top += button.Height + 2;
                i++;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {

            File.Delete(Directory.GetCurrentDirectory() + "\\" + "Пути для быстрых кнопок сетевых дисков.txt");
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + "Пути для быстрых кнопок сетевых дисков.txt", true, Encoding.GetEncoding(1251)))
            {
                Control curtainButton;
                sw.WriteLine("....."); sw.WriteLine(".....");
                int q = 0;
                while (q<this.Controls.Count)
                {
                    int topPosition = 999999999;
                    int topPositionTemp = 999999999;
                    int t = 0;
                    while (t< this.Controls.Count - q)
                    {
                        topPositionTemp = this.Controls[t].Location.Y;
                        if (topPositionTemp< topPosition)
                        {
                            if (this.Controls[t].Name == "order")
                            {
                                topPosition = topPositionTemp;
                                butControl = this.Controls[t];
                            }
                        }
                        t++;
                    }
                        sw.WriteLine(butControl.Tag + "??" + butControl.Text + "??" + butControl.BackColor.Name.ToString() + "??" + butControl.ForeColor.Name.ToString());
                        this.Controls.Remove(butControl);
                    if (this.Controls.Count==9)
                    {
                        break;
                    }
                }
            }

            Close();
            Process.Start(Directory.GetCurrentDirectory() + "\\" + "Самые быстрые кнопки сетевых дисков.exe");
            Application.Exit();
        }

        private void ButtonOnDelete(object sender, EventArgs eventArgs)
        {
            if (sender is Button button)
            {
                but = button;
                buttonName.Text = but.Text;
                int i = 0;
                while (i< listBox1.Items.Count && listBox1.Items[i].ToString()!= but.BackColor.Name.ToString())
                {
                    i++;
                }
                try { listBox1.SetSelected(i, true); } catch { }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(but);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (but!=null)
            {
                colourOfButtonText = listBox2.SelectedItem.ToString();
                colourOfButton = listBox1.SelectedItem.ToString();
                try { but.Text = buttonName.Text; } catch { }
                try { but.BackColor = Color.FromName(colourOfButton); } catch { }
            }
        }

        private void buttonName_TextChanged(object sender, EventArgs e)
        {
            if (but != null)
            {
                colourOfButtonText = listBox2.SelectedItem.ToString();
                colourOfButton = listBox1.SelectedItem.ToString();
                try { but.Text = buttonName.Text; } catch { }
                //try { but.BackColor = Color.FromName(colourOfButton); } catch { }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (but != null)
            {
                colourOfButtonText = listBox2.SelectedItem.ToString();
                try { but.Text = buttonName.Text; } catch { }
                try { but.ForeColor = Color.FromName(colourOfButtonText); } catch { }
            }
        }
    }
    class MyButton : Button
    {
        //точка перемещения
        Point DownPoint;
        //нажата ли кнопка мыши
        bool IsDragMode;

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (mevent.Button==MouseButtons.Left ==true)
            {
                DownPoint = mevent.Location;
                IsDragMode = true;
                base.OnMouseDown(mevent);
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (mevent.Button == MouseButtons.Left == true)
            {
                IsDragMode = false;
                base.OnMouseUp(mevent);
            }
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            //если кнопка мыши нажата
            if (IsDragMode)
            {
                Point p = mevent.Location;
                //вычисляем разницу в координатах между положением курсора и "нулевой" точкой кнопки
                Point dp = new Point(p.X - DownPoint.X, p.Y - DownPoint.Y);
                Location = new Point(Location.X + dp.X, Location.Y + dp.Y);
            }
            base.OnMouseMove(mevent);
        }
    }
}
