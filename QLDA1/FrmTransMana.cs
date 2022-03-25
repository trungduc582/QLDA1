using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLDA1.Class;

namespace QLDA1
{
    public partial class FrmTransMana : Form
    {
        public FrmTransMana()
        {
            InitializeComponent();
        }

        DataTable tblTQLCN;

        public void LoadDataGridView()
        {

            string sql;
            sql = "select * from LuongTienTiepQuyLCN";
            tblTQLCN = functions.GetDataToTable(sql);
            GV1.DataSource = tblTQLCN;
            GV1.Columns[0].HeaderText = "Mã LTTQ LCN";
            GV1.Columns[1].HeaderText = "Chi nhánh tiếp";
            GV1.Columns[2].HeaderText = "Chi nhánh nhận";
            GV1.Columns[3].HeaderText = "Tổng tiền";
            GV1.Columns[4].HeaderText = "Hạn mức";
            GV1.Columns[5].HeaderText = "Ngày yêu cầu";
            GV1.Columns[6].HeaderText = "Ngày kết thúc";
            GV1.Columns[7].HeaderText = "Trạng thái";
            GV1.Columns[0].Width = 100;
            GV1.Columns[1].Width = 70;
            GV1.Columns[2].Width = 70;
            GV1.Columns[3].Width = 80;
            GV1.Columns[4].Width = 90;
            GV1.Columns[5].Width = 100;
            GV1.Columns[6].Width = 100;
            GV1.Columns[7].Width = 100;
            GV1.AllowUserToAddRows = false;
            GV1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmFldTransManaAdd f = new FrmFldTransManaAdd();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
            LoadDataGridView();
        }



        private void FrmTransMana_Load(object sender, EventArgs e)
        {
            functions.Connect();
            functions.FillCombo("SELECT * FROM ChiNhanh", cbbTenCN, "MaCN", "TenCN");
            cbbTenCN.SelectedIndex = -1;
            functions.FillCombo("SELECT * FROM ChiNhanh", comboBox1, "MaCN", "TenCN");
            comboBox1.SelectedIndex = -1;
            functions.FillCombo("SELECT * from TrangThai", cbbTrangThai, "MaTrangThai", "TenTrangThai");
            cbbTrangThai.SelectedIndex = -1;
            functions.FillCombo("SELECT * from GiaoDich", comboBox2, "MaGiaoDich", "MaGiaoDich");
            LoadDataGridView();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearVal()
        {
            if (cbbTenCN.Text == "%")
            {
                cbbTenCN.Text = null;
            }
            if (comboBox1.Text == "%")
            {
                comboBox1.Text = null;
            }
            if (comboBox2.Text == "%")
            {
                comboBox2.Text = null;
            }
            if (cbbTrangThai.Text == "%")
            {
                cbbTrangThai.Text = null;
            }
        }

        private void btnTk_Click(object sender, EventArgs e)
        {
            string where = "%";
            if(cbbTenCN.Text.Trim().Length==0)
            {
                cbbTenCN.Text = where;
            }
            if (comboBox1.Text.Trim().Length == 0)
            {
                comboBox1.Text = where;
            }
            if (comboBox2.Text.Trim().Length == 0)
            {
                comboBox2.Text = where;
            }
            if (cbbTrangThai.Text.Trim().Length == 0)
            {
                cbbTrangThai.Text = where;
            }

            string sql;
            sql = "select * from LuongTienTiepQuyLCN where MaCNT like '" + cbbTenCN.Text + "' and MaCNN like '" + comboBox1.Text + "' and MaLTTQLCN like '" + comboBox2.Text + "' and TrangThai like '" + cbbTrangThai.Text + "' and convert(date,NgayYeuCau,103) = convert(date,'" + dateTimePicker2.Value+ "',103) and convert(date,NgayKetThuc,103) = convert(date,'" + dateTimePicker1.Value+"',103)";
            tblTQLCN = functions.GetDataToTable(sql);
            GV1.DataSource = tblTQLCN;
            ClearVal();
        }

        private void GV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbTenCN.Text = GV1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = GV1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = GV1.CurrentRow.Cells[0].Value.ToString();
            cbbTrangThai.Text = GV1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker2.Text = GV1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Text = GV1.CurrentRow.Cells[6].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaHangxoa, sql;
            if (tblTQLCN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                MaHangxoa = GV1.CurrentRow.Cells[0].Value.ToString();
                sql = "delete LuongTienTiepQuyLCN where MaLTTQLCN=N'" + comboBox2.Text + "'";
                functions.RunSQL(sql);
                
                cbbTenCN.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                cbbTrangThai.Text = "";
                LoadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FrmFldTransManaEdit1 f = new FrmFldTransManaEdit1();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Message = comboBox2.Text;
            f.ShowDialog();
            LoadDataGridView();
        }
    }
}
