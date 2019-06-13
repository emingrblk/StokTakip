using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLNStokTakipV1.Fonksiyonlar
{
    class Mesajlar
    {
        public void YeniKayit(string mesaj)
        {
            MessageBox.Show(mesaj, "Yeni Kayıt Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public DialogResult Guncelle()
        {
            return MessageBox.Show("Seçili olan kayıt güncellenecektir\n Güncelleme işlemini onaylıyormusunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public DialogResult Kayit()
        {
            return MessageBox.Show("Aynı kaydı tekrar kaydetmek istiyormusunuz?", "Kayıt Uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public DialogResult Sil()
        {
            return MessageBox.Show("Tüm Kayıtlar Kalıcı Olarak Silinecektir.\n Silme İşlemini Onaylıyormusunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public void Guncelle(bool guncelleme)
        {
            MessageBox.Show("Kayıt güncellenmiştir.", "Kayıt Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Hata(Exception hata)
        {
            MessageBox.Show(hata.Message, "Hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public DialogResult Yazdir()
        {
            return MessageBox.Show("Kaydı yazdırmak istiyormusunuz?", "Yazdırma işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
