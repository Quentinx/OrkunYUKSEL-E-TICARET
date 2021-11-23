using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class VTOrkunProje : DbContext
    {
        public DbSet<Olta> Oltas { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<OltaOzellik> OltaOzelliks { get; set; }
    }
}
