namespace QLDA1
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuTrans = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDieuChuyenQuy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDieuChuyenKho = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNopRut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCanTien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHachToan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrans,
            this.mnuDieuChuyenQuy,
            this.mnuDieuChuyenKho,
            this.mnuNopRut,
            this.mnuCanTien,
            this.mnuHachToan});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1286, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // mnuTrans
            // 
            this.mnuTrans.Name = "mnuTrans";
            this.mnuTrans.Size = new System.Drawing.Size(246, 32);
            this.mnuTrans.Text = "Tiếp quỹ liên chi nhánh";
            this.mnuTrans.Click += new System.EventHandler(this.mnuTrans_Click);
            // 
            // mnuDieuChuyenQuy
            // 
            this.mnuDieuChuyenQuy.Name = "mnuDieuChuyenQuy";
            this.mnuDieuChuyenQuy.Size = new System.Drawing.Size(183, 32);
            this.mnuDieuChuyenQuy.Text = "Điều chuyển quỹ";
            this.mnuDieuChuyenQuy.Click += new System.EventHandler(this.mnuDieuChuyenQuy_Click);
            // 
            // mnuDieuChuyenKho
            // 
            this.mnuDieuChuyenKho.Name = "mnuDieuChuyenKho";
            this.mnuDieuChuyenKho.Size = new System.Drawing.Size(226, 32);
            this.mnuDieuChuyenKho.Text = "Điều chuyển tiền kho";
            this.mnuDieuChuyenKho.Click += new System.EventHandler(this.mnuDieuChuyenKho_Click);
            // 
            // mnuNopRut
            // 
            this.mnuNopRut.Name = "mnuNopRut";
            this.mnuNopRut.Size = new System.Drawing.Size(144, 32);
            this.mnuNopRut.Text = "Nộp/rút tiền";
            this.mnuNopRut.Click += new System.EventHandler(this.mnuNopRut_Click);
            // 
            // mnuCanTien
            // 
            this.mnuCanTien.Name = "mnuCanTien";
            this.mnuCanTien.Size = new System.Drawing.Size(212, 32);
            this.mnuCanTien.Text = "Cân tiền trong ngày";
            this.mnuCanTien.Click += new System.EventHandler(this.mnuCanTien_Click);
            // 
            // mnuHachToan
            // 
            this.mnuHachToan.Name = "mnuHachToan";
            this.mnuHachToan.Size = new System.Drawing.Size(267, 32);
            this.mnuHachToan.Text = "Hạch toán thừa thiếu quỹ";
            this.mnuHachToan.Click += new System.EventHandler(this.mnuHachToan_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::QLDA1.Properties.Resources.mau_background_dep1;
            this.ClientSize = new System.Drawing.Size(1572, 505);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Quản lý tiền mặt";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuTrans;
        private System.Windows.Forms.ToolStripMenuItem mnuDieuChuyenQuy;
        private System.Windows.Forms.ToolStripMenuItem mnuDieuChuyenKho;
        private System.Windows.Forms.ToolStripMenuItem mnuNopRut;
        private System.Windows.Forms.ToolStripMenuItem mnuCanTien;
        private System.Windows.Forms.ToolStripMenuItem mnuHachToan;
    }
}