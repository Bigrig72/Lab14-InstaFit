using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaFit.Data
{
    public class InstaDbContext : DbContext
    {
       public InstaDbContext(DbContextOptions<InstaDbContext> options) : base(options)
        {

        }
    }
}
