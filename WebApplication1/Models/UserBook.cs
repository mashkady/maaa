using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class UserBook
    {
        public UserBook()
        {
            Exchanges = new HashSet<Exchange>();
        }

        public int IdUserBook { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime DateOfTake { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string StatusBefore { get; set; } = null!;
        public string StatusAfter { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual Book IdBookNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Exchange> Exchanges { get; set; }
    }
}
