using APILIVROS.Models;
using Microsoft.EntityFrameworkCore;

namespace APILIVROS.Data;

public class BookContext : DbContext
{
	public BookContext(DbContextOptions<BookContext> opts) : base(opts)
	{

	}

    public DbSet<Book> Books { get; set; }
}
