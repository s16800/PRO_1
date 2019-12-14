using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamówienie = new HashSet<Zamówienie>();
        }

        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string AdresDostawy { get; set; }

        public virtual ICollection<Zamówienie> Zamówienie { get; set; }
    }
}
