using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class NapójZamówienie
    {
        public int NapójIdNapój { get; set; }
        public int ZamówienieIdZamówienie { get; set; }

        public virtual Napój NapójIdNapójNavigation { get; set; }
        public virtual Zamówienie ZamówienieIdZamówienieNavigation { get; set; }
    }
}
