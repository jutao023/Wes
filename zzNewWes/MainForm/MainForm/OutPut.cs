using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wes
{
    public partial class OutPut : Form
    {
        public OutPut()
        {
            InitializeComponent();
        }

        public string uid { get; set; }
        public string coinSymbol { get; set; }

        public void printmsg(string _msg)
        {
            try
            {
                if (textBox.TextLength >= 5000)
                {
                    string date = DateTime.Now.ToString("yyyyMMdd");
                    string dirPath = ".\\print\\uid=" + uid;
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    string filePath = dirPath + "\\" + date + "_" + coinSymbol + ".txt";
                    File.AppendAllText(filePath, textBox.Text);
                    textBox.Clear();
                }
                this.textBox.Text += _msg + "\r\n";
            }catch
            {

            }
        }

        private void OutPut_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public void RealClose()
        {
            try
            {
                string date = DateTime.Now.ToString("yyyyMMdd");
                string dirPath = ".\\print\\uid=" + uid;
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                string filePath = dirPath + "\\" + date + "_" + coinSymbol + ".txt";
                File.AppendAllText(filePath, textBox.Text);
                textBox.Clear();
                Close();
            }
            catch
            {

            }
        }

        private void OutPut_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
