using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Janre
    {
        public Janre()
        {
            IdBooks = new HashSet<Book>();
        }

        public int IdJanre { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> IdBooks { get; set; }
    }
}
