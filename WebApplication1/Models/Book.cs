using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Book
    {
        public Book()
        {
            UserBooks = new HashSet<UserBook>();
            IdJanres = new HashSet<Janre>();
        }

        public int IdBook { get; set; }
        public int IdAuthor { get; set; }
        public string Name { get; set; } = null!;
        public string Library { get; set; } = null!;

        public virtual Author IdAuthorNavigation { get; set; } = null!;
        public virtual ICollection<UserBook> UserBooks { get; set; }

        public virtual ICollection<Janre> IdJanres { get; set; }
    }
}
