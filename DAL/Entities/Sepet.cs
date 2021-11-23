using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Sepet
    {
        public int Id { get; set; }
        public int OltaId { get; set; }
        public int KullaniciId { get; set; }
        public int Adet { get; set; }
        virtual public Olta Olta { get; set; }
        virtual public Kullanici Kullanici { get; set; }
    }
}
