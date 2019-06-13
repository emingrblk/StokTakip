using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLNStokTakipV1.Model;
using SLNStokTakipV1.Fonksiyonlar;
using System.Runtime.InteropServices;

namespace SLNStokTakipV1.Urun
{
    public partial class frmUrunSatis : Form
    {
        STContext db = new STContext();
        Formlar f = new Formlar();
        Mesajlar m = new Mesajlar();
        Numaralar n = new Numaralar();

        bool edit = false;
        int usatisId = -1;
        int firmaId = -1;

        public string[] MyArray { get; set; }


        public frmUrunSatis()
        {
            InitializeComponent();
        }

        private void frmUrunSatis_Load(object sender, EventArgs e)
        {
            txtSaat.Text = DateTime.Now.ToShortTimeString();
            txtFno.Text = n.FrmNo();
            Combo();
        }

        void Combo()
        {
            urncmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
            var lst = db.bgUrunGirisler.Select(item => item.UrunKodu).Distinct();
            foreach(string urun in lst)
            {
                veri.Add(urun);
                urncmb.Items.Add(urun);
            }
            urncmb.AutoCompleteCustomSource = veri;
            var dgv = urncmb.Items.Count;
            MyArray = new string[dgv];
            for(int p=0;p<dgv;p++)
            {
                MyArray[p] = urncmb.Items[p].ToString();
            }
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
            if (id > 0)
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
                lblAdres.Text = frm.FirmaAdres;                
                lblFUnvan.Text = frm.FirmaAdi;                
                txtFno.Text = frm.Fno.ToString().PadLeft(7, '0');                
                lblVd.Text = frm.Fvd;
                lblVno.Text = frm.Fvn;                
            }
            catch (Exception)
            {
                throw;
            }
        }

        [DllImport("user32.dll")]

        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void Liste_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if(Liste.CurrentCell.ColumnIndex==1 && txt!=null)
            {
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.AutoCompleteCustomSource.AddRange(MyArray);
            }
            else if(Liste.CurrentCell.ColumnIndex!=1 && txt!=null)
            {
                txt.AutoCompleteMode = AutoCompleteMode.None;
            }
        }

        private void Liste_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            if(e.ColumnIndex==1)
            {
                foreach(DataGridViewCell cell in Liste.SelectedCells)
                {
                    string a = Liste.CurrentRow.Cells[1].Value.ToString();
                    var lst = (from s in db.bgUrunGirisler
                               where s.UrunKodu == a
                               select s).First();
                    string ack = lst.UrunAciklama;
                    var uno = lst.UrunNo;

                    if(Liste.CurrentRow!=null)
                    {
                        Liste.CurrentRow.Cells[3].Value = ack;
                        Liste.CurrentRow.Cells[8].Value = uno;
                    }
                }
                
            }
            if(e.ColumnIndex==5)
            {
                int adt = int.Parse(Liste.CurrentRow.Cells[4].Value.ToString());
                int bf = int.Parse(Liste.CurrentRow.Cells[5].Value.ToString());

                if (Liste.CurrentRow.Cells[4].Value!=null && Liste.CurrentRow.Cells[5].Value != null)
                {
                    Liste.CurrentRow.Cells[6].Value = adt * bf;
                }
            }
            Topla();
        }

        void Topla()
        {
            decimal a = 0;
            for(int i=0;i<Liste.Rows.Count;i++)
            {
                if (Liste.Rows[i].Cells[6].Value!=null)
                {
                    a += decimal.Parse(Liste.Rows[i].Cells[6].Value.ToString());
                    txtAraToplam.Text = a.ToString(); 
                }
            }
        }
    }
}
