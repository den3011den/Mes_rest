using Microsoft.EntityFrameworkCore;

namespace Mes_rest_DataAccess
{

    /// <summary>
    /// DbContext
    /// </summary>
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        /// <summary>
        /// Авторы
        /// </summary>
        //public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Книги
        /// </summary>
        //public DbSet<Book> Books { get; set; }

    }

}
