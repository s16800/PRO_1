using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Dodatek
    {
        public Dodatek()
        {
            DodatekZamówienie = new HashSet<DodatekZamówienie>();
        }

        public int IdDodatek { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public virtual ICollection<DodatekZamówienie> DodatekZamówienie { get; set; }
    }
}
