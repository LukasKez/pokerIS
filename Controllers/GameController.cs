using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokerIS.Models;
using PokerIS.Data;

namespace PokerIS.Controllers
{
    public class GameController : Controller
    {
        private readonly PokerISContext _context;
        public GameController(PokerISContext context)
        {
            _context = context;
        }

        public IActionResult Join(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = _context.Table.FirstOrDefault(m => m.ID == id);

            if (table == null)
            {
                return NotFound();
            }
            table.PlayerCount++;
            // table.players.add(current player)
            _context.Update(table);
            _context.SaveChanges();

            return View("Views/Game/Index.cshtml", table);
        }

        public IActionResult Leave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = _context.Table.FirstOrDefault(m => m.ID == id);

            if (table == null)
            {
                return NotFound();
            }
            table.PlayerCount--;
            _context.Update(table);
            _context.SaveChanges();

            return RedirectToAction("Index", "Table");
        }

        public IActionResult Fold(int? id) // pirmiau reik sukurti zaisti pokeri
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = _context.Table.FirstOrDefault(m => m.ID == id);

            if (table == null)
            {
                return NotFound();
            }
            // round.PlayerCount--;
            //_context.Update.table or game
            // _context.savechanges
            return View("Views/Game/Index.cshtml", table);
        }

        public IActionResult Call(int? id, float called) // pirmiau reik sukurti zaisti pokeri
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = _context.Table.FirstOrDefault(m => m.ID == id);

            if (table == null)
            {
                return NotFound();
            }
            // round.PlayerCount--;
            //_context.Update.table or game
            // _context.savechanges
            return View("Views/Game/Index.cshtml", table);
        }

        public IActionResult distributeCards(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = _context.Table.FirstOrDefault(m => m.ID == id);

            if (table == null)
            {
                return NotFound();
            }

            var players = table.Players;
            var Deck = new DeckOfCards();
            Deck.SetupDeck();
            var deck = Deck.GetDeck;
            int i = 0;
            foreach (var playerid in players)
            {
                var player = _context.Member.FirstOrDefault(m => m.ID == playerid);
                player.Cards = [deck[i], deck[i + 1]];
                i = i + 2;
            }
            return View("Views/Game/Index.cshtml", table);
        }


    }
}