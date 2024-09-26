using MediatedAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace MediatedAPI.Data;

class ContactsContext(DbContextOptions<ContactsContext> options) : DbContext(options)
{
  public DbSet<Contact> Contacts { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Contact>().HasData(
      new Contact { Id = 1, FirstName = "John", LastName = "Doe" },
      new Contact { Id = 2, FirstName = "Jane", LastName = "Smith" }
    );
  }
}