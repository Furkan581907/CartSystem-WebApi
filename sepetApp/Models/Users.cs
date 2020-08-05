using System;
using System.Collections.Generic;

namespace sepetApp.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}
