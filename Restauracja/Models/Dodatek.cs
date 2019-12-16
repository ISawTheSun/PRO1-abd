using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Dodatek
    {
        public int IdProduktu { get; set; }
        public string RodzajDodatku { get; set; }

        public virtual Produkt IdProduktuNavigation { get; set; }
    }
}
