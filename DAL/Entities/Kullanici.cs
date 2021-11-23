using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string EMail { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public KullaniciTip KullaniciTip { get; set; }
        public bool Aktiflik { get; set; }
        public Guid GuidId { get; set; }
        virtual public ICollection<Sepet> Sepetler { get; set; }

    }
}
