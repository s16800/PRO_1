using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class DodatekZamówienie
    {
        public int DodatekIdDodatek { get; set; }
        public int ZamówienieIdZamówienie { get; set; }

        public virtual Dodatek DodatekIdDodatekNavigation { get; set; }
        public virtual Zamówienie ZamówienieIdZamówienieNavigation { get; set; }
    }
}
