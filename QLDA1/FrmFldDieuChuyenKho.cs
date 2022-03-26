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
    public partial class FrmFldDieuChuyenKho : Form
    {
        public FrmFldDieuChuyenKho()
        {
            InitializeComponent();
        }

        private void FrmFldDieuChuyenKho_Load(object sender, EventArgs e)
        {
            functions.Connect();
            txtMaGD.Text = functions.CreateKey("DCK_");
            functions.FillCombo("select CDName, CDVal from Allcode where CDType='TranType'", cbbTransType, "CDVal", "CDName");
            cbbTransType.SelectedIndex = -1;
            functions.FillCombo("select * from NhanVien", F_Emp, "MaNV", "TenNV");
            F_Emp.SelectedIndex = -1;
            functions.FillCombo("select * from NhanVien", T_Emp, "MaNV", "TenNV");
            T_Emp.SelectedIndex = -1;
            functions.FillCombo("select * from ket", cbbket, "MaKet", "MaKet");
            cbbket.SelectedIndex = -1;
            functions.FillCombo("select CDName, CDVal from Allcode where CDType='CCY'", cbbccy, "CDVal", "CDName");
            maskedTextBox7.Text = "0";
            maskedTextBox8.Text = "0";
            maskedTextBox9.Text = "0";
            maskedTextBox10.Text = "0";
            maskedTextBox11.Text = "0";
            maskedTextBox12.Text = "0";
            mskAMT.Text = "0";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaGD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã giao dịch phải khác null", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaGD.Focus();
                return;
            }
            if (cbbTransType.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbTransType.Focus();
                return;
            }
            if (mskAMT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskAMT.Focus();
                return;
            }
            if (F_Emp.Text.Trim().Length == 0 )
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                F_Emp.Focus();
                return;
            }
            if (T_Emp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                T_Emp.Focus();
                return;
            }
            if (cbbccy.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbccy.Focus();
                return;
            }
            if (cbbket.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbket.Focus();
                return;
            }
            if (maskedTextBox1.Text.Trim().Length == 0)
            {
                maskedTextBox7.Text = "0";
                return;
            }
            if (textBox1.Text.Trim().Length == 0)
            {
                maskedTextBox8.Text = "0";
                return;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                maskedTextBox9.Text = "0";
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                maskedTextBox10.Text = "0";
                return;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                maskedTextBox11.Text = "0";
                return;
            }
            if (textBox5.Text.Trim().Length == 0)
            {
                maskedTextBox12.Text = "0";
                return;
            }
            if (mskAMT.Text == "0")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskedTextBox1.Focus();
                return;
            }

            string sql;
            sql = "SELECT TranID  FROM DieuChuyenKho WHERE TranID='" + txtMaGD.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã điều chuyển kho này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaGD.Focus();
                return;
            }

            sql = "insert into DieuChuyenKho( TranID,MaKet, FUser,TUser,TranType,Amount,CCY, TranStatus,Supervisor,ValueDate)" +
                   " values ('" + txtMaGD.Text.Trim() + "','" + cbbket.SelectedValue.ToString() + "','" + F_Emp.SelectedValue.ToString() + "','" + T_Emp.SelectedValue.ToString() + "','" + cbbTransType.SelectedValue.ToString() + "','" + mskAMT.Text.Trim() + "'," +
                "'" + cbbccy.SelectedValue.ToString() + "','N','','" + dtpFrom.Value.ToShortDateString() + "')";
            functions.RunSQL(sql);
            MessageBox.Show("Thêm dữ liệu thành công", "Thông báo");
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        double tt ;

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            amtcalcu();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            amtcalcu();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            amtcalcu();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            amtcalcu();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            amtcalcu();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void amtcalcu()
        {
            double a1, a2, a3, a4, a5, a6;
            double b1, b2, b3, b4, b5, b6;
            if (maskedTextBox1.Text.Trim().Length == 0)
            {
                maskedTextBox1.Text = "0";
                maskedTextBox7.Text = "0";
            }
            if (textBox1.Text.Trim().Length == 0)
            {
                textBox1.Text = "0";
                maskedTextBox8.Text = "0";
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                textBox2.Text = "0";
                maskedTextBox9.Text = "0";
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                textBox3.Text = "0";
                maskedTextBox10.Text = "0";
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                textBox4.Text = "0";
                maskedTextBox11.Text = "0";
            }
            if (textBox5.Text.Trim().Length == 0)
            {
                textBox5.Text = "0";
                maskedTextBox12.Text = "0";
            }
            a1 = Convert.ToDouble(maskedTextBox1.Text.Trim());
            b1 = a1 * 10;
            maskedTextBox7.Text = b1.ToString();
            a2 = Convert.ToDouble(textBox1.Text.Trim());
            b2 = a2 * 20;
            maskedTextBox8.Text = b2.ToString();
            a3 = Convert.ToDouble(textBox2.Text.Trim());
            b3 = a3 * 50;
            maskedTextBox9.Text = b3.ToString();
            a4 = Convert.ToDouble(textBox3.Text.Trim());
            b4 = a4 * 100;
            maskedTextBox10.Text = b4.ToString();
            a5 = Convert.ToDouble(textBox4.Text.Trim());
            b5 = a5 * 200;
            maskedTextBox11.Text = b5.ToString();
            a6 = Convert.ToDouble(textBox5.Text.Trim());
            b6 = a6 * 500;
            maskedTextBox12.Text = b6.ToString();

            
            tt = b1 + b2 + b3 + b4 + b5 + b6;
            mskAMT.Text = tt.ToString();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            amtcalcu();
        }
    }
}
