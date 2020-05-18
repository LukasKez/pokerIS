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
    }
}