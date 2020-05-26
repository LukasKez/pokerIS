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
        [HttpGet]
        public IActionResult Game()
        {
            DealCards dc = new DealCards();
            dc.Deal(500, 5000);

            Game data = new Game();
            data.result = dc.result;
            data.playerHand = dc.RenameHands(dc.FirstPlayerHand);
            data.cpuHand = dc.RenameHands(dc.FirstComputerHand);
            data.flop = dc.RenameHands(dc.FlopHand);
            data.playerWallet = dc.playerWallet;
            data.cpuWallet = dc.cpuWallet;
            data.playerResult = Convert.ToString(dc.winningPlayerHand);
            data.cpuResult = Convert.ToString(dc.winningCpuHand);

            return View("Views/Game/GameScreen.cshtml", data);
        }

        [HttpPost]
        public IActionResult Game(string i, string j)
        {
            //logic for checking each wallet (if new game or continue)
            double player = Convert.ToDouble(i);
            double cpu = Convert.ToDouble(j);
            DealCards dc = new DealCards();
            if (player == 0)
            {
                dc.Deal(500, cpu);
            }
            else if (cpu <= 0)
            {
                dc.Deal(player, 10000);
            }
            else
                dc.Deal(player, cpu);

            //again mapping object to model to pass to view
            Game data = new Game();
            data.result = dc.result;
            data.playerHand = dc.RenameHands(dc.FirstPlayerHand);
            data.cpuHand = dc.RenameHands(dc.FirstComputerHand);
            data.flop = dc.RenameHands(dc.FlopHand);
            data.playerWallet = dc.playerWallet;
            data.cpuWallet = dc.cpuWallet;
            data.playerResult = Convert.ToString(dc.winningPlayerHand);
            data.cpuResult = Convert.ToString(dc.winningCpuHand);

            return View("Views/Game/GameScreen.cshtml", data);
        }
    }
}