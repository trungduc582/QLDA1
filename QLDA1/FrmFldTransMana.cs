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
    public partial class FrmFldTransManaEdit : Form
    {
        public FrmFldTransManaEdit()
        {
            InitializeComponent();
        }
        

        private void FrmFldTransMana_Load(object sender, EventArgs e)
        {
            
            functions.Connect();
            functions.FillCombo("SELECT * FROM ChiNhanh", cbbTenCN, "MaCN", "TenCN");
            cbbTenCN.SelectedIndex = -1;
            functions.FillCombo("SELECT * FROM ChiNhanh", comboBox1, "MaCN", "TenCN");
            comboBox1.SelectedIndex = -1;
            functions.FillCombo("SELECT * from TrangThai", cbbTrangThai, "MaTrangThai", "TenTrangThai");
            cbbTrangThai.SelectedIndex = -1;
            functions.FillCombo("SELECT * from GiaoDich", comboBox2, "MaGiaoDich", "MaGiaoDich");
            comboBox2.SelectedIndex = -1;
            
        }
        private void TBNhapDayDu()
        {
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaGD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã giao dịch phải khác null", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaGD.Focus();
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
            if (comboBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chi nhánh nhận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox2.Focus();
                return;
            }
            if (cbbTrangThai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbTrangThai.Focus();
                return;
            }

            string sql;
            sql = "SELECT MaLTTQLCN  FROM LuongTienTiepQuyLCN WHERE MaLTTQLCN='" + txtMaGD.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã LTTQLCN này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaGD.Focus();
                return;
            }

            sql = "insert into LuongTienTiepQuyLCN( MaLTTQLCN,MaCNT,MaCNN,TongTien,HanMuc,NgayYeuCau,NgayKetThuc,TrangThai)"+
                   " values ('" + txtMaGD.Text.Trim() + "','" + cbbTenCN.SelectedValue.ToString() + "','" + comboBox1.SelectedValue.ToString() + "','" + txtSoTien.Text.Trim() + "','"  + txtHanMuc.Text.Trim() + "'," +
                "'" + dateTimePicker2.Value.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "'," +
                "'" + cbbTrangThai.SelectedValue.ToString() + "')";
            functions.RunSQL(sql);
            MessageBox.Show("Thêm dữ liệu thành công","Thông báo");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaGD.Text = functions.CreateKey("LTTQLCN_");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
