using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Exchange
    {
        public int Addresse { get; set; }
        public int? IdUserBook { get; set; }
        public DateTime DateOfExchange { get; set; }
        public int IdExchange { get; set; }

        public virtual User AddresseNavigation { get; set; } = null!;
        public virtual UserBook? IdUserBookNavigation { get; set; }
    }
}
