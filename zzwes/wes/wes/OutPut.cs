using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public void printmsg(string _msg)
        {
            this.textBox.Text += _msg + "\r\n";
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OutPut_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
