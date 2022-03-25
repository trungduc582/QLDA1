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
            functions.FillCombo("select CDName, CDVal from Allcode where CDType='CCY'", cbbccy, "CDVal", "CDName");
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

            string sql;
            sql = "SELECT TranID  FROM DieuChuyenKho WHERE TranID='" + txtMaGD.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã điều chuyển kho này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaGD.Focus();
                return;
            }

            sql = "insert into DieuChuyenKho( TranID, FUser,TUser,TranType,Amount,CCY, TranStatus,Supervisor,ValueDate)" +
                   " values ('" + txtMaGD.Text.Trim() + "','" + F_Emp.SelectedValue.ToString() + "','" + T_Emp.SelectedValue.ToString() + "','" + cbbTransType.SelectedValue.ToString() + "','" + mskAMT.Text.Trim() + "'," +
                "'" + cbbccy.SelectedValue.ToString() + "','N','','" + dtpFrom.Value.ToShortDateString() + "')";
            functions.RunSQL(sql);
            MessageBox.Show("Thêm dữ liệu thành công", "Thông báo");
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
