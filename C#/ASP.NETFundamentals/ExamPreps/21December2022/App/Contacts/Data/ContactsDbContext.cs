using Contacts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<Contact>()
               .HasData(new Contact()
                {
                    Id = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    PhoneNumber = "+359881223344",
                    Address = "Gotham City",
                    Email = "imbatman@batman.com",
                    Website = "www.batman.com"
                });

            builder.Entity<ApplicationUserContact>()
                   .HasKey(k => new {k.ApplicationUserId, k.ContactId});

            builder.Entity<ApplicationUserContact>()
                   .HasOne(uc => uc.ApplicationUser)
                   .WithMany(a => a.ApplicationUsersContacts)
                   .HasForeignKey(uc => uc.ApplicationUserId);

            builder.Entity<ApplicationUserContact>()
                   .HasOne(uc => uc.Contact)
                   .WithMany(c => c.ApplicationUsersContacts)
                   .HasForeignKey(uc => uc.ContactId);

            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; }
    }
}