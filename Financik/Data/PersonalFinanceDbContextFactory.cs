using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financik.Data
{
    internal class PersonalFinanceDbContextFactory : IDesignTimeDbContextFactory<PersonalFinanceDbContext>
    {
        public PersonalFinanceDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var options = new DbContextOptionsBuilder<PersonalFinanceDbContext>()
                .UseSqlServer(config.GetConnectionString("SqlClient"))
                .Options;
            return new PersonalFinanceDbContext(options);
        }
    }
}
