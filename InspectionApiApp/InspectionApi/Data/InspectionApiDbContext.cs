using InspectionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionApi.Data
{
    public class InspectionApiDbContext : DbContext 
    {
        private readonly IConfiguration _configuration;

        public InspectionApiDbContext(DbContextOptions<InspectionApiDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
        }

        public DbSet<InspectionModel> InspectionModels { get; set; }
        public DbSet<InspectionTypeModel> InspectionTypeModels { get; set; }
        public DbSet<StatusModel> StatusModels { get; set; }

    }
}
