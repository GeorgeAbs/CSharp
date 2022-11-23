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
using Microsoft.Win32;
using IWshRuntimeLibrary;

namespace Самые_быстрые_кнопки_сетевых_дисков
{
    public partial class Настройки : Form
    {
        public Настройки()
        {
            InitializeComponent();
            listBox1.SetSelected(0, true);
            listBox2.SetSelected(0, true);
        }
        string[] settings = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", Encoding.GetEncoding(1251));
        string[] position;
        int butHe;
        int butWi;
        private void OK_Click(object sender, EventArgs e)
        {
            settings = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", Encoding.GetEncoding(1251));
            System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt");
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", true))
            {
                sw.WriteLine(settings[0]);
                sw.WriteLine(settings[1]);
                sw.WriteLine(buttonWidth.Text + "??" + buttonHeight.Text + "??" + sizeOfSh.Text);
                sw.WriteLine(listBox1.SelectedIndex.ToString() + "??" + listBox1.SelectedItem.ToString());
                sw.WriteLine(autostart.CheckState.ToString());
                sw.WriteLine(listBox2.SelectedIndex.ToString() + "??" + listBox2.SelectedItem.ToString());
                int i = 6;
                if (i < settings.Length)
                {
                    while (i < settings.Length)
                    {
                        sw.WriteLine(settings[i]);
                        i++;
                    }
                }
            }
            if (autostart.Checked ==true)
            {
                WshShell shell = new WshShell();
                string shortcutPath = @"C:\Users" + "\\" + Environment.UserName.ToString() + "\\" + @"AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup" +"\\" + "Самые быстрые кнопки сетевых дисков.lnk";
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = Directory.GetCurrentDirectory() + "\\" + "Самые быстрые кнопки сетевых дисков.exe";
                shortcut.Save();

            }
            else
            {
                System.IO.File.Delete(@"C:\Users" + "\\" + Environment.UserName.ToString() + "\\" + @"AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup" + "\\" + "Самые быстрые кнопки сетевых дисков.lnk");
                
            }
            Close();
            Process.Start(Directory.GetCurrentDirectory() + "\\" + "Самые быстрые кнопки сетевых дисков.exe");
            Application.Exit();
        }

        private void sizeOfSh_TextChanged(object sender, EventArgs e)
        {
            try { testButton.Font = new System.Drawing.Font(listBox1.SelectedItem.ToString(), Convert.ToInt32(sizeOfSh.Text)); } catch { }
        }

        private void buttonWidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                butWi = Convert.ToInt32(buttonWidth.Text);
                testButton.Size = new System.Drawing.Size(butWi, butHe);
            }
            catch { }
        }

        private void buttonHeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                butHe = Convert.ToInt32(buttonHeight.Text);
                testButton.Size = new System.Drawing.Size(butWi, butHe);
            }
            catch { }
        }

        private void Настройки_Load(object sender, EventArgs e)
        {
            settings = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + "Общие настройки.txt", Encoding.GetEncoding(1251));
            try {
                string[] style = settings[3].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                listBox1.SetSelected(Convert.ToInt32(style[0]), true);
                string[] backColor = settings[5].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
                listBox2.SetSelected(Convert.ToInt32(style[0]), true);
                this.BackColor = Color.FromName(backColor[1]);
            } catch { }
            position = settings[2].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries);
            sizeOfSh.Text = position[2];
            buttonWidth.Text = position[0];
            buttonHeight.Text = position[1];
            butHe = Convert.ToInt32(buttonHeight.Text);
            butWi = Convert.ToInt32(buttonWidth.Text);
            testButton.Size = new System.Drawing.Size(butWi, butHe);
            testButton.Font = new System.Drawing.Font(listBox1.SelectedItem.ToString(), Convert.ToInt32(sizeOfSh.Text));
            try { if (settings[4] == "Checked") { autostart.Checked = true; } else { autostart.Checked = false; } } catch { }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try { testButton.Font = new System.Drawing.Font(listBox1.SelectedItem.ToString(), Convert.ToInt32(sizeOfSh.Text)); } catch { }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { string[] backColor = settings[5].Split(new[] { "??" }, StringSplitOptions.RemoveEmptyEntries); ;
                this.BackColor = Color.FromName(listBox2.SelectedItem.ToString()); } catch { }
        }
    }
}
