using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wes
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if(nullString(new string[] { txt_coinSymbol.Text, txt_password.Text, txt_uid.Text, txt_username.Text }))
            {
                MessageBox.Show("值不能为空");
                return;
            }
            bool nub = System.Text.RegularExpressions.Regex.IsMatch(txt_uid.Text, "^[0-9]*$");
            if(!nub)
            {
                MessageBox.Show("uid,只能是数字");
                return;
            }

            SqLiteHelper sqlHelp = new SqLiteHelper();
            try
            {
                sqlHelp.SqliteOpen();
                SQLiteDataReader reader = null;

                string sqluid = "SELECT * FROM user WHERE uid=" + txt_uid.Text + " or username='" +
                    txt_username.Text + "' or coinSymbol='" + txt_coinSymbol.Text + "'";
                reader = sqlHelp.Execute(sqluid);
                if (reader.Read())
                {
                    MessageBox.Show("uid,账户,产品编码,不能重复插入");
                    sqlHelp.SqliteClose();
                    return;
                }
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sqlHelp.InsertValuesNoKey("user", new string[] { txt_uid.Text, txt_username.Text ,
                        txt_password.Text, txt_coinSymbol.Text, txtRemarks.Text, time});

                string[] vaes = new string[] { txt_uid.Text, "1", "1", "0.01", "1", "30", "30", "80", "80", "100", time, time };
                sqlHelp.InsertValuesNoKey("attrbute", vaes);
                sqlHelp.SqliteClose();

                Close();
            }
            catch (Exception ex)
            {
                sqlHelp.SqliteClose();
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            this.Location = (Point)new Size(Control.MousePosition.X - 250, Control.MousePosition.Y + 4);
        }

        bool nullString(string[] values)
        {
            foreach(string v in values)
            {
                if(v == null || v == "")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
