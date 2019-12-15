using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Models
{
    public partial class PizzaBaza
    {
        public PizzaBaza()
        {
            Pizza = new HashSet<Pizza>();
        }
        
        [Required]
        public int IdPizza { get; set; }
        [Required(ErrorMessage = "Nazwa musi zostać podana!")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage ="Cena musi zostać podana!")]
        public int Cena { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
