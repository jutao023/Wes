using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wes;
namespace 手工测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_buy_Click(object sender, EventArgs e)
        {
            long userid = long.Parse(txt_id_buy.Text);
            string symbol = txt_coin_buy.Text;
            string vol = txt_vol_buy.Text;
            string price = txt_price_buy.Text;
                
            var resObj = SYRequest.QureyBuy(userid, symbol , vol, price);
            if(resObj != null)
            {
                MessageBox.Show("下单成功");
            }
        }

        private void btn_sell_Click(object sender, EventArgs e)
        {
            long userid = long.Parse(txt_id_sell.Text);
            string symbol = txt_coin_sell.Text;
            string vol = txt_vol_sell.Text;
            string price = txt_price_sell.Text;

            object obj = SYRequest.QureySell(userid, symbol, vol, price);
            if(obj != null)
            {
                MessageBox.Show("下单成功");
            }
        }
    }
}
