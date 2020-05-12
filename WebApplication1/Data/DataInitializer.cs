using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataInitializer
    {
        public static void Initialize(TableContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Tables.Any())
            {
                return;   // DB has been seeded
            }

            var tables = new Table[]
            {
                new Table{ID=0, Seats=8, StartingBet=50}
            };

            foreach (Table t in tables)
            {
                context.Tables.Add(t);
            }
            context.SaveChanges();
        }
    }
}
