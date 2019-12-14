using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Napój
    {
        public Napój()
        {
            NapójZamówienie = new HashSet<NapójZamówienie>();
        }

        public int IdNapój { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public virtual ICollection<NapójZamówienie> NapójZamówienie { get; set; }
    }
}
