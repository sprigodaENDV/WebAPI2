using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API2.Persistence.Entities
{
    public class LocalDBContext  :  LocalDBContextBase
    {
        public LocalDBContext(DbContextOptions<LocalDBContext> appOptions) : base(appOptions)
        {
            var seed =  new SeedingDB(this);
            seed.SeedDB();
            Database.EnsureCreated();
        }

        public DbSet<TeamEntity> Teams { get; set; }

        public DbSet<MatchEntity> Matches { get; set; }
    }
}
