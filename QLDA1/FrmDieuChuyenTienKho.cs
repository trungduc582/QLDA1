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
using COMExcel = Microsoft.Office.Interop.Excel;

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
            GV2.Columns[9].Width = 60;

            GV2.AllowUserToAddRows = false;
            GV2.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.GV2.DefaultCellStyle.Font = new Font("arial", 9);
            this.GV2.DefaultCellStyle.SelectionBackColor = Color.Brown;
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmFldDieuChuyenKho f = new FrmFldDieuChuyenKho();
            f.ShowDialog();
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
            button2.Enabled = false;
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
            button2.Enabled = false;
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
            if (cbbSTT.SelectedValue.ToString() == "N" )
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                button2.Enabled = true;
            }
            else if (cbbSTT.SelectedValue.ToString() == "P")
            {
                btnXoa.Enabled = true;
                button2.Enabled = true;
            }
            else if (cbbSTT.SelectedValue.ToString() == "R")
            {
                btnXoa.Enabled = true;
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                button2.Enabled = false;
            }
            
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
                button2.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FrmFldDieuChuyenKhoEdit f = new FrmFldDieuChuyenKhoEdit();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Message = cBBTranID.Text.Trim();
            f.ShowDialog();
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
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            button2.Enabled = false;
            cbbTransType.Text = "ALL";
            cbbCCY.Text = "ALL";
            cbbSTT.Text = "ALL";
            cBBTranID.Text = "ALL";
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmFldDieuChuyenKhoAppr f = new FrmFldDieuChuyenKhoAppr();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Message = cBBTranID.Text.Trim();
            f.ShowDialog();
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
            button2.Enabled = false;
        }

        private void btnExpt_Click(object sender, EventArgs e)
        {
            if (tblTQLCN.Rows.Count <=0 )
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            int phong = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 12;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 15;
            exRange.Range["B1:B1"].ColumnWidth = 7;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "NGÂN HÀNG VIB";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (036)113541";
            exRange.Range["D2:K4"].Font.Size = 16;
            exRange.Range["D2:K4"].Font.Bold = true;
            exRange.Range["D2:K4"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["D2:K4"].MergeCells = true;
            exRange.Range["D2:K4"].WrapText = true;
            exRange.Range["D2:K4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D2:K4"].Value = "BÁO CÁO GIAO DỊCH CHUYỂN TIỀN TRONG - NGOÀI KHO" ;
            exRange.Range["D5:K5"].Font.Size = 14;
            exRange.Range["D5:K5"].Font.Italic = true;
            exRange.Range["D5:K5"].MergeCells = true;
            exRange.Range["D5:K5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D5:K5"].Value = $"Từ ngày: {dtpFrom.Value.ToShortDateString()} đến ngày: {dtpTo.Value.ToShortDateString()}";
            //Tạo dòng tiêu đề bảng
            exRange.Range["B7:K7"].Font.Bold = true;
            exRange.Range["B7:K7"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C7:C7"].ColumnWidth = 21;
            exRange.Range["D7:k300"].ColumnWidth = 15;
            exRange.Range["H7:I300"].ColumnWidth = 10;
            exRange.Range["f:f"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["h:i"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["k:K"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B7:B7"].Value = "STT";
            exRange.Range["C7:C7"].Value = "Mã giao dịch";
            exRange.Range["D7:D7"].Value = "Người gửi";
            exRange.Range["E7:E7"].Value = "Người nhận";
            exRange.Range["F7:F7"].Value = "Loại giao dịch";
            exRange.Range["G7:G7"].Value = "Số tiền";
            exRange.Range["H7:H7"].Value = "Loại tiền";
            exRange.Range["I7:I7"].Value = "Trạng thái";
            exRange.Range["J7:J7"].Value = "Người duyệt";
            exRange.Range["K7:K7"].Value = "Ngày thực hiện";
            for (phong = 0; phong < tblTQLCN.Rows.Count-1; phong++)
            {
                exSheet.Cells[2][phong + 8] = phong + 1;
                for (cot = 0; cot < tblTQLCN.Columns.Count-1; cot++)
                {
                    exSheet.Cells[cot + 3][phong + 8] = tblTQLCN.Rows[phong][cot].ToString();
                }
            }

            exRange = exSheet.Cells[5][tblTQLCN.Rows.Count + 10]; //Ô A1 
            exRange.Range["D1:F1"].MergeCells = true;
            exRange.Range["D1:F1"].Font.Italic = true;
            exRange.Range["D1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(DateTime.Now);
            exRange.Range["D1:F1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["D2:F2"].MergeCells = true;
            exRange.Range["D2:F2"].Font.Italic = true;
            exRange.Range["D2:F2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D2:F2"].Value = "Ký Tên";
            exRange.Range["D6:F6"].MergeCells = true;
            exRange.Range["D6:F6"].Font.Italic = true;
            exRange.Range["D6:F6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exApp.Visible = true;
        }
    }
}
