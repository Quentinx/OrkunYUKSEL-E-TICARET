using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Yorum
    {
        public int Id { get; set; }
        public int? KullaniciId { get; set; }
        public string AdiSoyadi { get; set; }
        public string Email { get; set; }
        public Kullanici Kullanici { get; set; }
        public Olta Olta { get; set; }
    }
}
