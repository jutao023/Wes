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
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        SYBase stag;
        List<Form> forms = new List<Form>();
        private void MainForm_Load(object sender, EventArgs e)
        {
            stag = new SYStrategy();
            OutPut op = new OutPut();
            stag.setOutPut(op);
            forms.Add(op);
        }
    }
}
