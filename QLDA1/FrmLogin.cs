using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDA1.Class;

namespace QLDA1
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        DataTable login;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql;
            functions.Connect();
            if(txttk.Text.Trim().Length==0 || txtpw.Text.Trim().Length == 0)
            {
                MessageBox.Show("vui long nhap du thong tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = $"select count(1) c from userlogin where username = '{txttk.Text.Trim()}' and pwd = '{txtpw.Text.Trim()}'";
            
            if (functions.GetFieldValues(sql)=="0")
            {
                MessageBox.Show("sai tai khoan hoac mat khau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                FrmMain f = new FrmMain();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
