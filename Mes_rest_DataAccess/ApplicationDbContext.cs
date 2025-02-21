using Mes_rest_DataAccess.DataModels;
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
        /// Тэги
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Значения тэгов
        /// </summary>
        public DbSet<TagValue> TagValues { get; set; }

    }

}
