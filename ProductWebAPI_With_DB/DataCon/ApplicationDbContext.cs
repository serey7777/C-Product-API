using Microsoft.EntityFrameworkCore;
using ProductWebAPI_With_DB.models;

namespace ProductWebAPI_With_DB.DataCon
{
    // This class represents the database context used by Entity Framework Core.
    // It manages the connection to the database and the entity sets (tables).
    public class ApplicationDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions.
        // This is used for configuring the context (e.g., connection string) via dependency injection.
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // Protected parameterless constructor.
        // This can be used for testing, proxy creation, or when options are configured elsewhere.
        protected ApplicationDbContext()
        {
        }

        // This property represents the Products table in the database.
        // Each Product object corresponds to a row in the Products table.
        public DbSet<Product> Products { get; set; }
    }

}
