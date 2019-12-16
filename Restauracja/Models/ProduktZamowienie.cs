using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class ProduktZamowienie
    {
        public int IdProduktZamowienie { get; set; }
        public int IdZamowienia { get; set; }
        public int IdProduktu { get; set; }

        public virtual Produkt IdProduktuNavigation { get; set; }
        public virtual Zamowienie IdZamowieniaNavigation { get; set; }
    }
}
