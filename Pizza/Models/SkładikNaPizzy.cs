using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class SkładikNaPizzy
    {
        public int SkładnikIdSkładnik { get; set; }
        public int PizzaIdPizza { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Składnik SkładnikIdSkładnikNavigation { get; set; }
    }
}
