using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNStokTakipV1.Model
{
    public class baseEntity
    {
        public int Id { get; set; }
        public int saveUser { get; set; }
        public DateTime saveDate { get; set; }
        public int updateUser { get; set; }
        public DateTime updateDate { get; set; }
    }
}
