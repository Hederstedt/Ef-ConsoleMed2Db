using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfMed2Db.Model
{
    public class Varor
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public int pris { get; set; }
        public Grupp TillhörGrupp { get; set; }
    }
}
