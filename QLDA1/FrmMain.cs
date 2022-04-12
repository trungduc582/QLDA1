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
    public partial class FrmMain : Form
    {
        DataTable tblTQLCN;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void mnuTrans_Click(object sender, EventArgs e)
        {
            FrmTransMana f = new FrmTransMana();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }


        private void mnuDieuChuyenQuy_Click(object sender, EventArgs e)
        {
            FrmDieuChuyenQuy f = new FrmDieuChuyenQuy();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuDieuChuyenKho_Click(object sender, EventArgs e)
        {
            FrmDieuChuyenTienKho f = new FrmDieuChuyenTienKho();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNopRut_Click(object sender, EventArgs e)
        {
            FrmNopRut f = new FrmNopRut();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuCanTien_Click(object sender, EventArgs e)
        {
            FrmCanTien f = new FrmCanTien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuHachToan_Click(object sender, EventArgs e)
        {
            FrmHachToan f = new FrmHachToan();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            string sql;
            sql = $"select * from ket";
            tblTQLCN = functions.GetDataToTable(sql);
            GV2.DataSource = tblTQLCN;
            GV2.Columns[0].HeaderText = "Mã két";
            GV2.Columns[1].HeaderText = "Mã Chi nhánh";
            GV2.Columns[2].HeaderText = "Số tiền";
            GV2.Columns[3].HeaderText = "Hạn mức";

            GV2.AllowUserToAddRows = false;
            GV2.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.GV2.DefaultCellStyle.Font = new Font("arial", 9);
            this.GV2.DefaultCellStyle.SelectionBackColor = Color.Brown;
        }
    }
}
