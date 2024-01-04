using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Domain.Models.TransferLog> TransferLogs { get; set; } 
    }
}
