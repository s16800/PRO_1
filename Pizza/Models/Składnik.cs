using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Składnik
    {
        public Składnik()
        {
            SkładikNaPizzy = new HashSet<SkładikNaPizzy>();
        }

        public int IdSkładnik { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public virtual ICollection<SkładikNaPizzy> SkładikNaPizzy { get; set; }
    }
}
