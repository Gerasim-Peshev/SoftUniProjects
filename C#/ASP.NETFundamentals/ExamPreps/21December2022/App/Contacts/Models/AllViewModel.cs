﻿using Contacts.Data;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class AllViewModel
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }
    }
}
