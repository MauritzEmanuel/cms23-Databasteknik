using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_DbTeknik.Contexts
{
    internal class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Databasteknik\Inlämningsuppgift_DbTeknik\Inlämningsuppgift_DbTeknik\Contexts\Assignment_Db.mdf;Integrated Security=True;Connect Timeout=30");
            return new DataContext(optionsBuilder.Options);
        }
    }
}