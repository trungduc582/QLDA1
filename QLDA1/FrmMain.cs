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
    public partial class FrmMain : Form
    {
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
    }
}
