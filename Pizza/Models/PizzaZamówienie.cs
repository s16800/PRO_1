using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class PizzaZamówienie
    {
        public int PizzaIdPizza { get; set; }
        public int ZamówienieIdZamówienie { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Zamówienie ZamówienieIdZamówienieNavigation { get; set; }
    }
}
