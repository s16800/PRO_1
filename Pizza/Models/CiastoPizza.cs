using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class CiastoPizza
    {
        public CiastoPizza()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdCiasto { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
