using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Osoba
    {
        public int IdOsoba { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }

        public virtual Dostawca Dostawca { get; set; }
        public virtual Klient Klient { get; set; }
    }
}
