using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Sqlite;
using SFF.Models;

namespace SFF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new GlobalDbContext())
            {
                db.Add(new Movie { Title = "SomeMovie", Genre = "SomeGenre", MaxAmount = 4 });
                db.Add(new MovieStudio { Name = "Some Random Studio", City = "Ulricehamn" });
                db.SaveChanges();
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
