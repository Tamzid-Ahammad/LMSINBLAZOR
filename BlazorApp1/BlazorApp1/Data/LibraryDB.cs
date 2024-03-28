using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
	public class LibraryDB:DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Book> Books { get; set; }
		public LibraryDB(DbContextOptions options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LMSBLAZOREXAMS;Trusted_Connection=True");

	}
}
