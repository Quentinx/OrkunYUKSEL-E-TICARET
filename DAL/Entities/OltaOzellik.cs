using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OltaOzellik
    {
        public int Id { get; set; }
        public int OltaId { get; set; }
        public Olta Olta { get; set; }
        public int? YapimYili { get; set; }
        public OltaTipi? OltaTipi { get; set; }
    }
}
