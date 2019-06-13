using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLNStokTakipV1.Bilgi
{
    public partial class frmFirmaListe : Form
    {
        Model.STContext db = new Model.STContext();

        public bool Secim;
        int secimId = -1;
        public frmFirmaListe()
        {
            InitializeComponent();
        }

        private void frmFirmaListe_Load(object sender, EventArgs e)
        {
            Listele();
        }
        private void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var bul = (from s in db.bgFirmalar
                       where s.FirmaAdi.Contains(txtFirmaAdi.Text) 
                       select s).ToList();
            foreach (var k in bul)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.Fno;
                Liste.Rows[i].Cells[2].Value = k.FirmaAdi;
                Liste.Rows[i].Cells[3].Value = k.FirmaTel;
                Liste.Rows[i].Cells[4].Value = k.Yetkili;
                Liste.Rows[i].Cells[5].Value = k.FirmaGsm;
                i++;
            }
            Liste.AllowUserToAddRows = false;
            Liste.AllowUserToDeleteRows = false;
        }

        void Sec()
        {
            try
            {
                if (Liste.CurrentRow != null) secimId = int.Parse(Liste.CurrentRow.Cells[1].Value.ToString());
            }
            catch (Exception)
            {

                secimId = -1;
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if(Secim&&secimId>0)
            {
                frmAnaSayfa.AktarmaI = secimId;
                Close();
            }
        }
    }
}
