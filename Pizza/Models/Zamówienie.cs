using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Zamówienie
    {
        public Zamówienie()
        {
            DodatekZamówienie = new HashSet<DodatekZamówienie>();
            NapójZamówienie = new HashSet<NapójZamówienie>();
            PizzaZamówienie = new HashSet<PizzaZamówienie>();
        }

        public int IdZamówienie { get; set; }
        public int Koszt { get; set; }
        public int KlientIdKlient { get; set; }

        public virtual Klient KlientIdKlientNavigation { get; set; }
        public virtual ICollection<DodatekZamówienie> DodatekZamówienie { get; set; }
        public virtual ICollection<NapójZamówienie> NapójZamówienie { get; set; }
        public virtual ICollection<PizzaZamówienie> PizzaZamówienie { get; set; }
    }
}
