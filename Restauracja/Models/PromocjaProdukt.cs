using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class PromocjaProdukt
    {
        public int IdPromocjaProdukt { get; set; }
        public int IdProduktu { get; set; }
        public int IdPromocji { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public decimal Cena { get; set; }

        public virtual Produkt IdProduktuNavigation { get; set; }
        public virtual Promocja IdPromocjiNavigation { get; set; }
    }
}
