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
    public partial class Добавление_кнопки : Form
    {
        public Добавление_кнопки()
        {
            InitializeComponent();
            listBox1.SetSelected(0, true);
            listBox2.SetSelected(0, true);
            string[] pathAndnameText = settings[2].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string[] style = settings[3].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                exampleButton.Font = new System.Drawing.Font(style[1], Convert.ToInt32(pathAndnameText[2]));
            }
            catch { }
            exampleButton.Size = new System.Drawing.Size(Convert.ToInt32(pathAndnameText[0]), Convert.ToInt32(pathAndnameText[1]));
            textBoxPath.Text = Form1.nameOfDradDrop;
            try
            {
                string[] backColor = settings[5].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                this.BackColor = Color.FromName(backColor[1]);
            }
            catch { } //цвет фона
        }
        string pathForButton;
        string colourOfButton;
        string colourOfButtonText;
        string[] settings = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", Encoding.GetEncoding(1251));
        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + "Пути для быстрых кнопок сетевых дисков.txt", true, Encoding.GetEncoding(1251)))
            {
                //sw.WriteLine("");
                sw.WriteLine(textBoxPath.Text + "??" + buttonName.Text + "??" + colourOfButton + "??" + colourOfButtonText);
            }
            Close();
            Process.Start(Directory.GetCurrentDirectory() + "\\" + "Самые быстрые кнопки сетевых дисков.exe");
            Application.Exit();

        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonName_TextChanged(object sender, EventArgs e)
        {
            colourOfButtonText = listBox2.SelectedItem.ToString();
            colourOfButton = listBox1.SelectedItem.ToString();
            try { exampleButton.BackColor = Color.FromName(colourOfButton); } catch { }
            try { exampleButton.ForeColor = Color.FromName(colourOfButtonText); } catch { }
            exampleButton.Text = buttonName.Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //colourOfButtonText = listBox2.SelectedItem.ToString();
            colourOfButton = listBox1.SelectedItem.ToString();
            exampleButton.Text = buttonName.Text;
            try { exampleButton.BackColor = Color.FromName(colourOfButton); } catch { }
            try { exampleButton.ForeColor = Color.FromName(colourOfButtonText); } catch { }
        }

        private void Добавление_кнопки_DragDrop(object sender, DragEventArgs e)
        {
            string[] name = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxPath.Text = name[0];
        }

        private void Добавление_кнопки_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            colourOfButtonText = listBox2.SelectedItem.ToString();
            exampleButton.Text = buttonName.Text;
            colourOfButton = listBox1.SelectedItem.ToString();
            try { exampleButton.BackColor = Color.FromName(colourOfButton); } catch { }
            try { exampleButton.ForeColor = Color.FromName(colourOfButtonText); } catch { }
        }
    }
}
