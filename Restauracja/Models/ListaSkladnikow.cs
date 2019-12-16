using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class ListaSkladnikow
    {
        public int IdListySkladniokow { get; set; }
        public int SkladnikIdSkladnik { get; set; }
        public int IdProduktu { get; set; }

        public virtual Pizza IdProduktuNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
    }
}
