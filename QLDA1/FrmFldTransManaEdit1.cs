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
    public partial class FrmFldTransManaEdit1 : Form
    {
        public FrmFldTransManaEdit1()
        {
            InitializeComponent();
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private void FrmFldTransManaEdit1_Load(object sender, EventArgs e)
        {
            string sql;
            functions.Connect();
            functions.FillCombo("select MaLTTQLCN from LuongTienTiepQuyLCN", comboBox5, "MaLTTQLCN", "MaLTTQLCN");
            cbbTenCN.SelectedIndex = -1;
            functions.FillCombo("SELECT * FROM ChiNhanh", cbbTenCN, "MaCN", "TenCN");
            cbbTenCN.SelectedIndex = -1;
            functions.FillCombo("SELECT * FROM ChiNhanh", comboBox1, "MaCN", "TenCN");
            comboBox1.SelectedIndex = -1;
            functions.FillCombo("SELECT * from TrangThai", cbbTrangThai, "MaTrangThai", "TenTrangThai");
            cbbTrangThai.SelectedIndex = -1;
            functions.FillCombo("SELECT * from GiaoDich", CbbCCY, "MaGiaoDich", "MaGiaoDich");
            CbbCCY.SelectedIndex = -1;
            comboBox5.Text = _message;
            sql = "select MaCNT from LuongTienTiepQuyLCN where MaLTTQLCN ='" + comboBox5.SelectedValue.ToString() + "'";
            cbbTenCN.Text = functions.GetFieldValues(sql);
            sql = "select MaCNN from LuongTienTiepQuyLCN where MaLTTQLCN ='" + comboBox5.SelectedValue + "'";
            comboBox1.Text = functions.GetFieldValues(sql);
            sql = "select TongTien from LuongTienTiepQuyLCN where MaLTTQLCN ='" + comboBox5.SelectedValue + "'";
            txtSoTien.Text = functions.GetFieldValues(sql);
            sql = "select HanMuc from LuongTienTiepQuyLCN where MaLTTQLCN ='" + comboBox5.SelectedValue + "'";
            txtHanMuc.Text = functions.GetFieldValues(sql);
            sql = "select TrangThai from LuongTienTiepQuyLCN where MaLTTQLCN ='" + comboBox5.SelectedValue + "'";
            cbbTrangThai.Text = functions.GetFieldValues(sql);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn Mã GD", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox5.Focus();
                return;
            }
            if (txtSoTien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoTien.Focus();
                return;
            }
            if (cbbTenCN.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chi nhánh gửi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbTenCN.Focus();
                return;
            }
            /*if (CbbCCY.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại tiền tệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CbbCCY.Focus();
                return;
            }*/
            if (cbbTrangThai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbTrangThai.Focus();
                return;
            }

            string sql;
            /*sql = "SELECT MaLTTQLCN  FROM LuongTienTiepQuyLCN WHERE MaLTTQLCN='" + txtMaGD.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã LTTQLCN này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaGD.Focus();
                return;
            }*/

            sql = $"update LuongTienTiepQuyLCN set MaCNT = '{cbbTenCN.Text.Trim()}',MaCNN='{comboBox1.Text.Trim()}',TongTien='{txtSoTien.Text.Trim()}',HanMuc='{txtHanMuc.Text.Trim()}',NgayYeuCau='{dateTimePicker2.Value.ToShortDateString()}',NgayKetThuc='{dateTimePicker2.Value.ToShortDateString()}',TrangThai='{cbbTrangThai.Text.Trim()}' where MaLTTQLCN='{comboBox5.Text.Trim()}'";
            functions.RunSQL(sql);
            MessageBox.Show("Cập nhật dữ liệu thành công","Thông báo");
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
