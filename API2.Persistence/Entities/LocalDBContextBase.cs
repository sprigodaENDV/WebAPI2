using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API2.Persistence.Entities
{
    public abstract class LocalDBContextBase : DbContext
    {
        protected LocalDBContextBase(DbContextOptions appOptions) : base(appOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseInMemoryDatabase("hh");
        }
    }
}
