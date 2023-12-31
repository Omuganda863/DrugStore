﻿namespace DrugStore.Controllers.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public Drugs drug { get; set; } = default!;
        List <Drugs> drugs = new List<Drugs> ();
    }
}
