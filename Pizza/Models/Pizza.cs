using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaZamówienie = new HashSet<PizzaZamówienie>();
            SkładikNaPizzy = new HashSet<SkładikNaPizzy>();
        }

        public int PizzaBazaIdPizza { get; set; }
        public int IdPizza { get; set; }
        public int CiastoPizzaIdCiasto { get; set; }

        public virtual CiastoPizza CiastoPizzaIdCiastoNavigation { get; set; }
        public virtual PizzaBaza PizzaBazaIdPizzaNavigation { get; set; }
        public virtual ICollection<PizzaZamówienie> PizzaZamówienie { get; set; }
        public virtual ICollection<SkładikNaPizzy> SkładikNaPizzy { get; set; }
    }
}
