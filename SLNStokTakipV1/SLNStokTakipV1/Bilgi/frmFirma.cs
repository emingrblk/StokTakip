using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLNStokTakipV1.Model;

namespace SLNStokTakipV1.Bilgi
{
    public partial class frmFirma : Form
    {
        Model.STContext db = new Model.STContext();
        Fonksiyonlar.Formlar f = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar m = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numaralar n = new Fonksiyonlar.Numaralar();

        bool edit = false;
        int firmaId = -1;
        public frmFirma()
        {
            InitializeComponent();
        }       

        private void frmFirma_Load(object sender, EventArgs e)
        {
            txtFtipi.DataSource = db.bgFirmaTipleri.ToList();
            txtFtipi.DisplayMember = "Ftipi";
            txtFtipi.ValueMember = "Id";
            txtFno.Text = n.FrmNo();
        }
        void Temizle()
        {
            foreach(Control ct in splitContainer1.Panel1.Controls)
            {
                if(ct is TextBox || ct is ComboBox)
                {
                    ct.Text = "";
                }
            }
            txtFno.Text = n.FrmNo();
        }

        void YeniKaydet()
        {
            try
            {
                bgFirma frm = new bgFirma();
                frm.Departman = txtDeparman.Text;
                frm.Email = txtEmail.Text;
                frm.FirmaAdi = txtFadi.Text;
                frm.FirmaAdres = txtAdres.Text;
                frm.FirmaFaks = txtFaks.Text;
                frm.FirmaGsm = txtGsm.Text;
                frm.FirmaTel = txtTelefon.Text;
                frm.Fno = int.Parse(txtFno.Text);
                frm.FtipiId = db.bgFirmaTipleri.First(x => x.Ftipi == (txtFtipi.Text)).Id;
                frm.Fvd = txtVd.Text;
                frm.Fvn = txtVn.Text;
                frm.Web = txtWeb.Text;
                frm.Yetkili = txtYetkili.Text;
                frm.saveDate = DateTime.Now;
                frm.saveUser = -1;
                frm.updateDate = DateTime.Now;
                frm.updateUser = -1;

                db.bgFirmalar.Add(frm);
                db.SaveChanges();
                Temizle();
            }
            catch (Exception)
            {

                throw;
            }
        }

        void Guncelle()
        {
            try
            {
                bgFirma frm = db.bgFirmalar.First(x => x.Fno == firmaId);
                frm.Departman = txtDeparman.Text;
                frm.Email = txtEmail.Text;
                frm.FirmaAdi = txtFadi.Text;
                frm.FirmaAdres = txtAdres.Text;
                frm.FirmaFaks = txtFaks.Text;
                frm.FirmaGsm = txtGsm.Text;
                frm.FirmaTel = txtTelefon.Text;
                frm.Fno = int.Parse(txtFno.Text);
                frm.FtipiId = db.bgFirmaTipleri.First(x => x.Ftipi == (txtFtipi.Text)).Id;
                frm.Fvd = txtVd.Text;
                frm.Fvn = txtVn.Text;
                frm.Web = txtWeb.Text;
                frm.Yetkili = txtYetkili.Text;
                frm.saveDate = DateTime.Now;
                frm.saveUser = -1;
                frm.updateDate = DateTime.Now;
                frm.updateUser = -1;
                
                db.SaveChanges();
                Temizle();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (edit && firmaId > 0 && m.Guncelle() == DialogResult.Yes) Guncelle();
            else if (edit==false)YeniKaydet();
        }
        protected override void OnLoad(EventArgs e)
        {
            var btnFno = new Button();
            btnFno.Size = new Size(25, txtFno.ClientSize.Height + 2);
            btnFno.Location = new Point(txtFno.ClientSize.Width - btnFno.Width, -1);
            btnFno.Cursor = Cursors.Default;
            txtFno.Controls.Add(btnFno);
            SendMessage(txtFno.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnFno.Width << 16));
            btnFno.Anchor = (AnchorStyles.Top | AnchorStyles.Right);            

            base.OnLoad(e);

            btnFno.Click += btnFno_Click;
            
        }

        private void btnFno_Click(object sender, EventArgs e)
        {
            int id = f.FirmaBul(true);
            if(id>0)
            {
                FirmaAc(id);
            }
            frmAnaSayfa.AktarmaI = -1;
        }

        private void FirmaAc(int id)
        {
            try
            {
                edit = true;
                firmaId = id;
                bgFirma frm = db.bgFirmalar.First(s => s.Fno == firmaId);
                txtAdres.Text = frm.FirmaAdres;
                txtDeparman.Text = frm.Departman;
                txtEmail.Text = frm.Email;
                txtFadi.Text = frm.FirmaAdi;
                txtFaks.Text = frm.FirmaFaks;
                txtFno.Text = frm.Fno.ToString().PadLeft(7,'0');
                txtFtipi.Text = frm.bgFirmaTipleri.Ftipi;
                txtGsm.Text = frm.FirmaGsm;
                txtTelefon.Text = frm.FirmaTel;
                txtVd.Text = frm.Fvd;
                txtVn.Text = frm.Fvn;
                txtWeb.Text = frm.Web;
                txtYetkili.Text = frm.Yetkili;
            }
            catch (Exception)
            {
                throw;
			}
        }

        [DllImport("user32.dll")]

        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Raporlar.frmPrint frm = new Raporlar.frmPrint();
            frm.HangiListe = "Firma";
            frm.txtbox.Text = txtFno.Text;
            frm.Show();
        }
    }
}
