using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLNStokTakipV1.Fonksiyonlar
{
    public class Formlar
    {
        public int FirmaBul(bool secim = false)
        {
            Bilgi.frmFirmaListe bul = new Bilgi.frmFirmaListe();
            if (secim)
            {
                bul.Secim = true;
                //bul.btnAktar.Enabled = true;
                bul.ShowDialog();
            }
            else
            {
                bul.MdiParent = Form.ActiveForm;
                bul.WindowState = FormWindowState.Maximized;
                //bul.btnAktar.Enabled = false;
                bul.Show();
            }
            return frmAnaSayfa.AktarmaI;
        }

        public void UrunSatis()
        {
            Urun.frmUrunSatis frm = new Urun.frmUrunSatis();
            frm.MdiParent = Application.OpenForms["frmAnaSayfa"] as frmAnaSayfa;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
