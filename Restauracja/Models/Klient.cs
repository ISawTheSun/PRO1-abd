using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int OsobaIdOsoba { get; set; }

        public virtual Osoba OsobaIdOsobaNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
