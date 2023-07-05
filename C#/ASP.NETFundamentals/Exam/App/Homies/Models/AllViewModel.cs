﻿using Homies.Data;
using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Type = Homies.Data.Models.Type;

namespace Homies.Models
{
    public class AllViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;
        
        public string Description { get; set; } = null!;

        public string OrganiserId { get; set; } = null!;

        public IdentityUser Organiser { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TypeId { get; set; }

        public string Type { get; set; } = null!;
    }
}