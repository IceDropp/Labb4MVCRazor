using Labb4MVCRazor.Models;
using Labb4MVCRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4MVCRazor.Data
{
    public class LibraryDbContext : DbContext 
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Morgan Westin", Email = "moggewestin@hotmail.com", PhoneNumber = "07564321" },
                new Customer { CustomerId = 2, Name = "Jan Carlsson", Email = "Jan_C@gmail.com", PhoneNumber = "08549731" },
                new Customer { CustomerId = 3, Name = "Alex Begntzon", Email = "alexBentzon@gmail.com", PhoneNumber = "04567785" },
                new Customer { CustomerId = 4, Name = "Johan Fredriksson", Email = "JhoanF@hotmail.com", PhoneNumber = "03215786" },
                new Customer { CustomerId = 5, Name = "Frisa Aronsson", Email = "Frida.aronsson@gmail.com", PhoneNumber = "04567891" }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien", PublicationYear = 1937 },
                new Book { BookId = 2, Title = "A Game of Thrones", Author = "George R.R. Martin", PublicationYear = 1996 },
                new Book { BookId = 3, Title = "The Name of the Wind", Author = "Patrick Rothfuss", PublicationYear = 2007 },
                new Book { BookId = 4, Title = "Mistborn: The Final Empire", Author = "Brandon Sanderson", PublicationYear = 2006 },
                new Book { BookId = 5, Title = "The Lies of Locke Lamora", Author = "Scott Lynch", PublicationYear = 2006 }
                );
            modelBuilder.Entity<Loan>().HasData(
            new Loan { LoanId = 1, CustomerId = 1, BookId = 1, LoanDate = new DateTime(2024, 09, 02), ReturnDate = new DateTime(2024, 10, 22), Returned = true },
            new Loan { LoanId = 2, CustomerId = 2, BookId = 2, LoanDate = new DateTime(2024, 09, 01), ReturnDate = new DateTime(2024, 10, 21), Returned = true },
            new Loan { LoanId = 3, CustomerId = 3, BookId = 3, LoanDate = new DateTime(2024, 09, 07), ReturnDate = new DateTime(2024, 10, 27), Returned = false },
            new Loan { LoanId = 4, CustomerId = 4, BookId = 4, LoanDate = new DateTime(2024, 09, 09), ReturnDate = new DateTime(2024, 10, 29), Returned = true },
            new Loan { LoanId = 5, CustomerId = 5, BookId = 5, LoanDate = new DateTime(2024, 09, 04), ReturnDate = new DateTime(2024, 10, 24), Returned = true }
                );
        }
    }
}
