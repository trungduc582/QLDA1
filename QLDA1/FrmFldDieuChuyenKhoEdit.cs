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
    public partial class FrmFldDieuChuyenKhoEdit : Form
    {
        public FrmFldDieuChuyenKhoEdit()
        {
            InitializeComponent();
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFldDieuChuyenKhoEdit_Load(object sender, EventArgs e)
        {
            string sql;
            functions.Connect();
            functions.FillCombo("select CDName, CDVal from Allcode where CDType='TranType'", cbbTransType, "CDVal", "CDName");
            cbbTransType.SelectedIndex = -1;
            functions.FillCombo("select * from NhanVien", F_Emp, "MaNV", "TenNV");
            F_Emp.SelectedIndex = -1;
            functions.FillCombo("select * from NhanVien", T_Emp, "MaNV", "TenNV");
            T_Emp.SelectedIndex = -1;
            functions.FillCombo("select CDName, CDVal from Allcode where CDType='CCY'", cbbccy, "CDVal", "CDName");
            txtMaGD.Text = _message;
            sql = "select a0.CDName from DieuChuyenKho dck, allcode a0 where dck.TranType = a0.CDVal and a0.CDType='TranType' and dck.TranID='" + txtMaGD.Text.Trim() + "'";
            cbbTransType.Text = functions.GetFieldValues(sql);

            sql = "select emp.TenNV from NhanVien emp, DieuChuyenKho dck where emp.MaNV = dck.FUser and dck.TranID='" + txtMaGD.Text.Trim() + "'";
            F_Emp.Text = functions.GetFieldValues(sql);

            sql = "select emp.TenNV from NhanVien emp, DieuChuyenKho dck where emp.MaNV = dck.TUser and dck.TranID='" + txtMaGD.Text.Trim() + "'";
            T_Emp.Text = functions.GetFieldValues(sql);

            sql = "select Amount from DieuChuyenKho where TranID ='" + txtMaGD.Text.Trim() + "'";
            mskAMT.Text = functions.GetFieldValues(sql);

            sql = "select a0.CDName from DieuChuyenKho dck, allcode a0 where dck.CCY = a0.CDVal and a0.CDType='CCY' and dck.TranID='" + txtMaGD.Text.Trim() + "'";
            cbbccy.Text = functions.GetFieldValues(sql);

            sql = "select ValueDate from DieuChuyenKho where TranID ='" + txtMaGD.Text.Trim() + "'";
            dtpFrom.Value = Convert.ToDateTime(functions.GetFieldValues(sql));
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaGD.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn Mã GD", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaGD.Focus();
                return;
            }
            if (mskAMT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskAMT.Focus();
                return;
            }
            if (F_Emp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập người gửi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                F_Emp.Focus();
                return;
            }
            if (cbbccy.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại tiền tệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbccy.Focus();
                return;
            }

            string sql;

            sql = $"update DieuChuyenKho set FUser='{F_Emp.SelectedValue}',TUser='{T_Emp.SelectedValue}',TranType='{cbbTransType.SelectedValue}',Amount='{mskAMT.Text.Trim()}',CCY='{cbbccy.SelectedValue}',ValueDate='{dtpFrom.Value.ToShortDateString()}' where TranID='{txtMaGD.Text.Trim()}'";
            functions.RunSQL(sql);
            MessageBox.Show("Cập nhật dữ liệu thành công","Thông báo");
            this.Close();
        }
    }
}
