using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class User
    {
        public User()
        {
            Exchanges = new HashSet<Exchange>();
            UserBooks = new HashSet<UserBook>();
        }

        public int IdUser { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Nickname { get; set; } = null!;

        public virtual ICollection<Exchange> Exchanges { get; set; }
        public virtual ICollection<UserBook> UserBooks { get; set; }
    }
}
