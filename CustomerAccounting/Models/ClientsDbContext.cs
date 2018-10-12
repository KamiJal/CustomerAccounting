using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerAccounting.Models
{
    public class ClientsDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ClientsDbContext()
            : base("ClientAccounting")
        {
        }

        public static ClientsDbContext Create()
        {
            return new ClientsDbContext();
        }
    }
}