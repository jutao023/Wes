using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JiaoHui.JHCore;

namespace JHWinUI
{
    public partial class OutPut : PrintMessage
    {
        private bool showHeart = false;
        public OutPut()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        public void Print(string _msg)
        {
            if (_msg == null)
                return;
            if (showHeart || _msg.Length < 5)
            {
                txtOutPut.Text += (_msg + "\r\n");
            }else
            {
                int ind = _msg.IndexOf('@');
                if(ind < 0)
                {
                    txtOutPut.Text += (_msg + "\r\n");
                }
                else
                {
                    string ssr = _msg.Substring(0,ind);
                    if(ssr == "993" || ssr == "994" || ssr == "995")
                    {
                        return;
                    }else
                    {
                        txtOutPut.Text += (_msg + "\r\n");
                    }
                }
            }
        }

        private void txtOutPut_TextChanged(object sender, EventArgs e)
        {
            txtOutPut.SelectionStart = txtOutPut.Text.Length;
            txtOutPut.ScrollToCaret();
        }

        public void HeartInfoOnConsole(bool showr = true)
        {
            showHeart = showr;
        }

        public bool GetHeartState()
        {
            return showHeart;
        }
    }
}
