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
    public partial class FrmDieuChuyenTienKho : Form
    {
        public FrmDieuChuyenTienKho()
        {
            InitializeComponent();
        }

        DataTable tblTQLCN;

        public void LoadDataGridView()
        {
            string sql;
            sql = $"select TranID, nv0.TenNV FUser, nv1.TenNV TUser,(a0.CDName) TranType,Amount,a1.CDName CCY, a2.CDName TranStatus, Supervisor, ValueDate ,MaKet " +
                $" from DieuChuyenKho dck, Allcode a0, Allcode a1, Allcode a2,NhanVien nv0, NhanVien nv1" +
                $" where dck.TranType = a0.CDVal and a0.CDType = 'TranType'" +
                $" and dck.CCY = a1.CDVal and a1.CDType = 'CCY'" +
                $" and dck.TranStatus = a2.CDVal and a2.CDType = 'TranStatus'" +
                $" and dck.FUser = nv0.MaNV and dck.TUser = nv1.MaNV" ;
            tblTQLCN = functions.GetDataToTable(sql);
            GV2.DataSource = tblTQLCN;
            GV2.Columns[0].HeaderText = "Mã giao dịch";
            GV2.Columns[1].HeaderText = "Người gửi";
            GV2.Columns[2].HeaderText = "Người nhận";
            GV2.Columns[3].HeaderText = "Loại giao dịch";
            GV2.Columns[4].HeaderText = "Số tiền";
            GV2.Columns[5].HeaderText = "CCY";
            GV2.Columns[6].HeaderText = "Trạng thái";
            GV2.Columns[7].HeaderText = "Người duyệt";
            GV2.Columns[8].HeaderText = "Ngày thực hiện";
            GV2.Columns[9].HeaderText = "Mã két";
            GV2.Columns[0].Width = 130;
            GV2.Columns[1].Width = 90;
            GV2.Columns[2].Width = 70;
            GV2.Columns[3].Width = 80;
            GV2.Columns[4].Width = 80;
            GV2.Columns[5].Width = 50;
            GV2.Columns[6].Width = 80;
            GV2.Columns[7].Width = 90;
            GV2.Columns[8].Width = 100;
            GV2.Columns[8].Width = 60;
            GV2.AllowUserToAddRows = false;
            GV2.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.GV2.DefaultCellStyle.Font = new Font("arial", 9);
            this.GV2.DefaultCellStyle.SelectionBackColor = Color.Brown;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmFldDieuChuyenKho f = new FrmFldDieuChuyenKho();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
            LoadDataGridView();
        }

        private void FrmDieuChuyenTienKho_Load(object sender, EventArgs e)
        {
            functions.Connect();
            functions.FillCombo("select 'ALL' CDName, '%' TranType union all select distinct( a0.CDName) CDName, a0.CDVal TranType from DieuChuyenKho dck, allcode a0 where dck.TranType = a0.CDVal and a0.CDType='TranType'", cbbTransType, "TranType", "CDName");
            cbbTransType.SelectedIndex = -1;
            cbbTransType.Text = "ALL";
            functions.FillCombo("select 'ALL' CDName, '%' CCY union all select distinct(a0.CDName) CDName, a0.CDVal CCY from DieuChuyenKho dck, allcode a0 where dck.CCY = a0.CDVal and a0.CDType = 'CCY' ", cbbCCY, "CCY", "CDName");
            cbbCCY.SelectedIndex = -1;
            cbbCCY.Text = "ALL";
            functions.FillCombo("select 'ALL' CDName, '%' TranID union all select TranID CDName, TranID TranID from DieuChuyenKho", cBBTranID, "TranID", "CDName");
            cBBTranID.SelectedIndex = -1;
            cBBTranID.Text = "ALL";
            functions.FillCombo("select 'ALL' CDName, '%' TranStatus union all select distinct( a0.CDName), a0.CDVal TranStatus from DieuChuyenKho dck, allcode a0 where dck.TranStatus = a0.CDVal and a0.CDType='TranStatus' ", cbbSTT, "TranStatus", "CDName");
            cbbSTT.Text = "ALL";
            LoadDataGridView();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void ClearVal()
        {
            if (cbbTransType.Text.Trim().Length == 0 || cbbTransType.Text == "%")
            {
                cbbTransType.Text = "ALL";
            }
            if (cbbCCY.Text.Trim().Length == 0 || cbbCCY.Text == "%")
            {
                cbbCCY.Text = "ALL";
            }
            if (cBBTranID.Text.Trim().Length == 0 || cBBTranID.Text == "%")
            {
                cBBTranID.Text = "ALL";
            }
            if (cbbSTT.Text.Trim().Length == 0 || cbbSTT.Text == "%")
            {
                cbbSTT.Text = "ALL";
            }
        }

        private void btnTk_Click(object sender, EventArgs e)
        {
            /*string where = "%";
            if ((cbbTransType.Text.Trim().Length == 0) || (cbbTransType.Text == "ALL"))
            {
                cbbTransType.Text = where;
            }
            if (cbbCCY.Text.Trim().Length == 0 || (cbbCCY.Text == "ALL"))
            {
                cbbCCY.Text = where;
            }
            if (cBBTranID.Text.Trim().Length == 0 || (cBBTranID.Text == "ALL"))
            {
                cBBTranID.Text = where;
            }
            if (cbbSTT.Text.Trim().Length == 0 || (cbbSTT.Text == "ALL"))
            {
                cbbSTT.Text = where;
            }*/

            string sql;
            sql = $"select TranID, nv0.TenNV FUser, nv1.TenNV TUser,(a0.CDName) TranType,Amount,a1.CDName CCY, a2.CDName TranStatus, Supervisor, ValueDate,Maket  " +
                $" from DieuChuyenKho dck, Allcode a0, Allcode a1, Allcode a2,NhanVien nv0, NhanVien nv1" +
                $" where dck.TranType = a0.CDVal and a0.CDType = 'TranType'" +
                $" and dck.CCY = a1.CDVal and a1.CDType = 'CCY'" +
                $" and dck.TranStatus = a2.CDVal and a2.CDType = 'TranStatus'" +
                $" and dck.FUser = nv0.MaNV and dck.TUser = nv1.MaNV" +
                $" and dck.TranType like '" + cbbTransType.SelectedValue + "' " +
                $" and dck.CCY like '" + cbbCCY.SelectedValue + "'" +
                $" and dck.TranID like '" + cBBTranID.SelectedValue + "'" +
                $" and dck.TranStatus like '" + cbbSTT.SelectedValue + "'" + 
                $" and dck.ValueDate between convert(date,'" + dtpFrom.Value + "',103) and convert(date,'" + dtpTo.Value + "',103)";
            tblTQLCN = functions.GetDataToTable(sql);
            GV2.DataSource = tblTQLCN;
            ClearVal();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cBBTranID.Text = GV2.CurrentRow.Cells[0].Value.ToString();
            cbbTransType.Text = GV2.CurrentRow.Cells[3].Value.ToString();
            cbbCCY.Text = GV2.CurrentRow.Cells[5].Value.ToString();
            cbbSTT.Text = GV2.CurrentRow.Cells[6].Value.ToString();
            dtpFrom.Text = GV2.CurrentRow.Cells[8].Value.ToString();
            dtpTo.Text = GV2.CurrentRow.Cells[8].Value.ToString();
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
                MaHangxoa = GV2.CurrentRow.Cells[0].Value.ToString();
                sql = "delete DieuChuyenKho where TranID='" + cBBTranID.SelectedValue + "'";
                functions.RunSQL(sql);

                cBBTranID.Text = "";
                cbbTransType.Text = "";
                cbbCCY.Text = "";
                cbbSTT.Text = "";
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                LoadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FrmFldDieuChuyenKhoEdit f = new FrmFldDieuChuyenKhoEdit();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Message = cBBTranID.Text.Trim();
            f.ShowDialog();
            LoadDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            cbbTransType.Text = "ALL";
            cbbCCY.Text = "ALL";
            cbbSTT.Text = "ALL";
            cBBTranID.Text = "ALL";
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
        }
    }
}
