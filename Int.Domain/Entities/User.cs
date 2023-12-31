﻿using Core.Persistence.Repositories;

namespace Int.Domain.Entities
{
    public class User : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
