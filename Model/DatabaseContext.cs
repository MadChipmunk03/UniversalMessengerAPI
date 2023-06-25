using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace UniversalMessengerAPI.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Recipient> Recipients { get; set; }

        /*  https://madchipmunk03.cz/databazicka/  */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=madchipmunk03.cz;database=dbUniversalMessenger;user=sssvt;password=123456;port=3306");
        }
    }
}
