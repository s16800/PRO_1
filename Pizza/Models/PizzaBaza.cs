using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class PizzaBaza
    {
        public PizzaBaza()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
