using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Library.Models.ApplicationContext
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options) { }
       public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(a => a.Category).WithMany(a => a.Books)
                .HasForeignKey(a => a.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BorrowRecord>().HasOne(a => a.Book).WithMany(a => a.BorrowRecords).HasForeignKey(a => a.BookId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BorrowRecord>().HasOne(a => a.Member).WithMany(a => a.BorrowRecords).HasForeignKey(a => a.MemberId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Category>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<Member>().HasIndex(a=>a.Email).IsUnique();

            //data seeding
            modelBuilder.Entity<Category>().HasData
                (
                new Category { CategoryId = 1, Name = "programing" },
                new Category { CategoryId = 2, Name = "life" },
                 new Category { CategoryId = 3, Name = "cars" }

                );
            modelBuilder.Entity<Member>().HasData
                (

                new Member { MemberId = 1, FullName = "Ahmed Abdullah", PhoneNumber = "01129566806", Email = "elldeegahmag@gmail.com" },
                new Member { MemberId = 2, FullName = "Ahmed Ali", PhoneNumber = "01129566896", Email = "Ali@gmail.com" },
                new Member { MemberId = 3, FullName = "Ahmed mohamed", PhoneNumber = "01189566806", Email = "mohamed@gmail.com" }


            );
            modelBuilder.Entity<Book>().HasData(

                new Book { BookId = 1, Title = "lifetag", Author = "ahemd", Price = 1000, PublishedYear = 2006, AvailableCopies = 3, CategoryId = 2 },
                new Book { BookId = 2, Title = "undercoast", Author = "ali", Price = 100, PublishedYear = 2008, AvailableCopies = 3, CategoryId = 3 },
                                new Book { BookId = 3, Title = "fuck", Author = "mohamed", Price = 800, PublishedYear = 2001, AvailableCopies = 2, CategoryId = 2 }

                );
            modelBuilder.Entity<BorrowRecord>().HasData(

                new BorrowRecord { Id = 1, MemberId = 1, BookId = 1 },
                            new BorrowRecord { Id = 2, MemberId = 2, BookId = 2 },
                                            new BorrowRecord { Id = 3, MemberId = 3, BookId = 3 }

            );
        }
    }
}
