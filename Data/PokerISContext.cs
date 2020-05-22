using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokerIS.Models;

namespace PokerIS.Data
{
    public class PokerISContext : DbContext
    {
        public PokerISContext(DbContextOptions<PokerISContext> options)
            : base(options)
        {
        }

        public DbSet<Table> Table { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<DeckOfCards> Deck { get; set; }
    }
}
