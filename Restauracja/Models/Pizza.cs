using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            ListaSkladnikow = new HashSet<ListaSkladnikow>();
        }

        public int IdProduktu { get; set; }
        public byte[] RodzajPizzy { get; set; }

        public virtual Produkt IdProduktuNavigation { get; set; }
        public virtual ICollection<ListaSkladnikow> ListaSkladnikow { get; set; }
    }
}
