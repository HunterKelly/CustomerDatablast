using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomerDatabast3.Data
{
    public class CustomerDatabast3Context : DbContext
    {
        public CustomerDatabast3Context (DbContextOptions<CustomerDatabast3Context> options)
            : base(options)
        {
        }

        public DbSet<CustomerDatabast3.Data.clientProperties>? clientProperties { get; set; }
    }
}
