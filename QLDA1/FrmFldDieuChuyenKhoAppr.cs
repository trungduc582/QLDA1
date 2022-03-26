using QLDA1.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDA1
{
    public partial class FrmFldDieuChuyenKhoAppr : Form
    {
        public FrmFldDieuChuyenKhoAppr()
        {
            InitializeComponent();
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        string sql;

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            double amt, amt_change, amt_limit, amt_new ;
            sql = "SELECT MaKet, SoTien,HanMuc FROM Ket WHERE MaKet = '" + textBox1.Text.Trim() + "'";
            DataTable tblHang = functions.GetDataToTable(sql);
            amt = Convert.ToDouble(tblHang.Rows[0][1].ToString());
            amt_limit= Convert.ToDouble(tblHang.Rows[0][2].ToString());
            amt_change = Convert.ToDouble(textBox3.Text);
            amt_new = amt + amt_change;
            if(amt_new > amt_limit)
            {
                MessageBox.Show($"Số tiền vượt quá hạn mức, hạn mức còn lại là: {(amt_limit-amt)}" , "Thông báo");
                return;
            }
            else
            {
                sql = $"update DieuChuyenKho set TranStatus='A' where TranID='{txtMaGD.Text.Trim()}'";
                functions.RunSQL(sql);
                sql = $"update ket set SoTien={amt_new} where MaKet = '{textBox1.Text.Trim()}'";
                functions.RunSQL(sql);
                MessageBox.Show("Duyệt dữ liệu thành công", "Thông báo");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = $"update DieuChuyenKho set TranStatus='P' where TranID='{txtMaGD.Text.Trim()}'";
            functions.RunSQL(sql);
            MessageBox.Show("Submit dữ liệu thành công", "Thông báo");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql = $"update DieuChuyenKho set TranStatus='R' where TranID='{txtMaGD.Text.Trim()}'";
            functions.RunSQL(sql);
            MessageBox.Show("Hủy giao dịch thành công", "Thông báo");
            this.Close();
        }

        private void FrmFldDieuChuyenKhoAppr_Load_1(object sender, EventArgs e)
        {
            functions.Connect();
            txtMaGD.Text = _message;
            sql = "select a0.CDName from DieuChuyenKho dck, allcode a0 where dck.TranType = a0.CDVal and a0.CDType='TranType' and dck.TranID='" + txtMaGD.Text.Trim() + "'";
            txtTranType.Text = functions.GetFieldValues(sql);

            sql = "select emp.TenNV from NhanVien emp, DieuChuyenKho dck where emp.MaNV = dck.FUser and dck.TranID='" + txtMaGD.Text.Trim() + "'";
            textBox2.Text = functions.GetFieldValues(sql);

            sql = "select emp.TenNV from NhanVien emp, DieuChuyenKho dck where emp.MaNV = dck.TUser and dck.TranID='" + txtMaGD.Text.Trim() + "'";
            textBox5.Text = functions.GetFieldValues(sql);

            sql = "select Amount from DieuChuyenKho where TranID ='" + txtMaGD.Text.Trim() + "'";
            textBox3.Text = functions.GetFieldValues(sql);

            sql = "select a0.CDName from DieuChuyenKho dck, allcode a0 where dck.CCY = a0.CDVal and a0.CDType='CCY' and dck.TranID='" + txtMaGD.Text.Trim() + "'";
            textBox4.Text = functions.GetFieldValues(sql);

            sql = "select MaKet from DieuChuyenKho where TranID='" + txtMaGD.Text.Trim() + "'";
            textBox1.Text = functions.GetFieldValues(sql);


            sql = "select ValueDate from DieuChuyenKho where TranID ='" + txtMaGD.Text.Trim() + "'";
            dtpFrom.Value = Convert.ToDateTime(functions.GetFieldValues(sql));
        }
    }
}
