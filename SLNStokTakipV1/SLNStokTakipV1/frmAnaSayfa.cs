using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLNStokTakipV1
{
    public partial class frmAnaSayfa : Form
    {
        Fonksiyonlar.Formlar f = new Fonksiyonlar.Formlar();

        public static int AktarmaI;
        public static string AktarmaS;
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void btnFirmaGiris_Click(object sender, EventArgs e)
        {
            Bilgi.frmFirma frm = new Bilgi.frmFirma();
            frm.MdiParent = Application.OpenForms["frmAnaSayfa"] as frmAnaSayfa;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnBir_Click(object sender, EventArgs e)
        {
            pnl1.Visible = true;
            pnl2.Visible = false;
            pnl3.Visible = false;
            gbSol.ForeColor = Color.DarkGreen;
            gbSol.Text = "Ürün İşlemleri";
        }

        private void btnIki_Click(object sender, EventArgs e)
        {
            pnl1.Visible = false;
            pnl2.Visible = true;
            pnl3.Visible = false;
            gbSol.ForeColor = Color.DarkRed;
            gbSol.Text = "Bilgi Giriş";
        }

        private void btnUc_Click(object sender, EventArgs e)
        {
            pnl1.Visible = false;
            pnl2.Visible = false;
            pnl3.Visible = true;
            gbSol.ForeColor = Color.DarkBlue;
            gbSol.Text = "Üç";
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            pnl1.Visible = true;
            pnl2.Visible = false;
            pnl3.Visible = false;
            gbSol.ForeColor = Color.DarkGreen;
            gbSol.Text = "Ürün İşlemleri";
        }

        private void btnFirmaBul_Click(object sender, EventArgs e)
        {
            f.FirmaBul();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUrunSatis_Click(object sender, EventArgs e)
        {
            f.UrunSatis();
        }
    }
}
