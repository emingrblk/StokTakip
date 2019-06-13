using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNStokTakipV1.Model
{
    public class stUrunKayitUst:baseEntity
    {
        public int GenelNo { get; set; }
        public int GirisKodu { get; set; }
        public int FirmaId { get; set; }
        public DateTime GirisTarih { get; set; }
        public string Aciklama { get; set; }
        [StringLength(5)]
        public string Saat { get; set; }

    }
}
