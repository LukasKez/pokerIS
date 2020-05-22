using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PokerIS.Data;
using System;
using System.Linq;

namespace PokerIS.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PokerISContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PokerISContext>>()))
            {
                // Look for any tables.
                if (context.Table.Any())
                {
                    return;   // DB has been seeded
                }

                context.Table.AddRange(
                    new Table
                    {
                        Seats = 8,
                        StartingBet = 50
                    }
                );
                context.SaveChanges();
            }
        }
    }
}