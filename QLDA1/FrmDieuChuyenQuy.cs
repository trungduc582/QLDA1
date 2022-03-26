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
    public partial class FrmDieuChuyenQuy : Form
    {
        public FrmDieuChuyenQuy()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmFldDieuChuyenQuy f = new FrmFldDieuChuyenQuy();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
        /*
public void LoadDataGridView()
{
string sql;
sql = $"select TranID, nv0.TenNV FUser, nv1.TenNV TUser,(a0.CDName) TranType,Amount,a1.CDName CCY, a2.CDName TranStatus, Supervisor, ValueDate ,MaKet " +
$" from DieuChuyenKho dck, Allcode a0, Allcode a1, Allcode a2,NhanVien nv0, NhanVien nv1" +
$" where dck.TranType = a0.CDVal and a0.CDType = 'TranType'" +
$" and dck.CCY = a1.CDVal and a1.CDType = 'CCY'" +
$" and dck.TranStatus = a2.CDVal and a2.CDType = 'TranStatus'" +
$" and dck.FUser = nv0.MaNV and dck.TUser = nv1.MaNV";
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

private void FrmDieuChuyenQuy_Load(object sender, EventArgs e)
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

private void btnThem_Click(object sender, EventArgs e)
{

}*/
    }
}
