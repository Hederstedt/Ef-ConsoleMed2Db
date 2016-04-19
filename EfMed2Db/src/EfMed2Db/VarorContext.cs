using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using EfMed2Db.Model;

namespace EfMed2Db
{
    public class VarorContext : DbContext
    {
        public VarorContext() : base() { }
        public DbSet<Varor> Varor { get; set; }
        public DbSet<Grupp> Grupp { get; set; }
    }
}
