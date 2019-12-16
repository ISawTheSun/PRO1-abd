using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            ListaSkladnikow = new HashSet<ListaSkladnikow>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<ListaSkladnikow> ListaSkladnikow { get; set; }
    }
}
