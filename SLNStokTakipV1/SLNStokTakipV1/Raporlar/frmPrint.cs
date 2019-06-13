using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLNStokTakipV1.Raporlar
{
    public partial class frmPrint : Form
    {
        Model.STContext db = new Model.STContext();
        public string HangiListe;
        public frmPrint()
        {
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            switch(HangiListe)
            {
                case "Firma":
                    Firma();
                    break;
            }
        }

        private void Firma()
        {
            Bilgi.frmFirma frm=Application.OpenForms["frmFirma"]as Bilgi.frmFirma;
            crFirma cr = new crFirma();

            int a = int.Parse(txtbox.Text);

            //var lst = db.bgFirmalar.First(x => x.Fno == a);
            var lst = (from s in db.bgFirmalar                       
                       where s.Fno==a
                       select new { s.FirmaAdi,s.FirmaAdres,s.FirmaFaks,s.bgFirmaTipleri.Ftipi}).ToList();
            if(lst!=null)
            {
                Fonksiyonlar.PrintYardim ch = new Fonksiyonlar.PrintYardim();
                DataTable dt = ch.ConvertTo(lst);
                cr.SetDataSource(dt);
                crPrint.ReportSource = cr;
            }
        }
    }
}
