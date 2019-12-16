using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            ProduktZamowienie = new HashSet<ProduktZamowienie>();
        }

        public int IdZamowienia { get; set; }
        public DateTime DataZamowienia { get; set; }
        public string StanZamowienia { get; set; }
        public decimal Cena { get; set; }
        public int Klient { get; set; }
        public int Dostawca { get; set; }

        public virtual Dostawca DostawcaNavigation { get; set; }
        public virtual Klient KlientNavigation { get; set; }
        public virtual ICollection<ProduktZamowienie> ProduktZamowienie { get; set; }
    }
}
