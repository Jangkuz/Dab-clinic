using DabClinicRepo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinic.EntityFramework.Context
{
    public class DabClinicDbContextFactory : IDesignTimeDbContextFactory<DabClinicContext>
    {
        public DabClinicContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<DabClinicContext>();
            options.UseSqlServer("server =(local); database=Dab_clinic; uid=sa; pwd=12345; TrustServerCertificate=True");
            //options.UseSqlServer(GetConnectionString());

            return new DabClinicContext(options.Options);
        }


        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

            return strConn;
        }

    }
}
