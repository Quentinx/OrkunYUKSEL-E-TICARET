using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Olta
    {
        public int Id { get; set; }
        
        public string Misina { get; set; }
        
        public int İlanNo { get; set; }
        public string Baslik { get; set; }
        public int Fiyat { get; set; }
        
        virtual public ICollection<OltaOzellik> Ozellikler { get; set; }
    }
}
