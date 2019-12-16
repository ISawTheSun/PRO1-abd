using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restauracja.Models
{
    public partial class Produkt
    {
        public Produkt()
        {
            ProduktZamowienie = new HashSet<ProduktZamowienie>();
            PromocjaProdukt = new HashSet<PromocjaProdukt>();
        }

        [Required(ErrorMessage = "IdProduktu jest wymagane")]
        public int IdProduktu { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MinLength (3, ErrorMessage = "Nazwa jest zbyt krotka")]

        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]

        public decimal Cena { get; set; }

        public virtual Dodatek Dodatek { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual ICollection<ProduktZamowienie> ProduktZamowienie { get; set; }
        public virtual ICollection<PromocjaProdukt> PromocjaProdukt { get; set; }
    }
}
