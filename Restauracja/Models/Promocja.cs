using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            PromocjaProdukt = new HashSet<PromocjaProdukt>();
        }

        public int IdPromocji { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<PromocjaProdukt> PromocjaProdukt { get; set; }
    }
}
