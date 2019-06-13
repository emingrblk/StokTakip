using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNStokTakipV1.Fonksiyonlar
{
    class Numaralar
    {
        Model.STContext db = new Model.STContext();

        public string FrmNo()
        {
            try
            {
                double numara = double.Parse(
                        (from s in db.bgFirmalar
                         orderby s.Id descending
                         select s).First().Fno.ToString());
                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;
            }
            catch (Exception)
            {
                return "0000001";
            }
        }
    }
}
