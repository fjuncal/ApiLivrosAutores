using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Comum.Repository
{
    public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
            optionsBuilder.UseNpgsql("Server=127.0.0.1; port=5432; user id = postgres; password = admin; database=LivroApi; pooling = true");

            return new ApiDbContext(optionsBuilder.Options);
        }
    }
}