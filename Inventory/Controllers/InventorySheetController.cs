using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
    [Route("inventory")]
    public class InventorySheetController : Controller
    {
        public ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public InventorySheetController(ApplicationDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            List<InventorySheet> sheets = await _db.InventorySheets
                .Include(s => s.InventoryItems)
                .ToListAsync();

            return View(sheets);
        }

        [Route("{id}")]
        public async Task<IActionResult> InventorySheet(int id)
        {
            List<InventoryItem> items = await _db.InventoryItems.Where(i => i.InventorySheetId == id).ToListAsync();

            return View(items);
        }

        [Route("create")]
        // GET: 
        public ActionResult Create()
        {
            var userGuid = _userManager.GetUserId(HttpContext.User);
            ViewBag.userGuid = userGuid;

            return View();
        }

        // POST: 
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InventorySheet inventorySheet)
        {
            try
            {
                // TODO: Add insert logic here
                var userGuid = _userManager.GetUserId(HttpContext.User);
                inventorySheet.UserId = new Guid(userGuid);

                _db.InventorySheets.Add(inventorySheet);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "InventorySheet");
            }
            catch
            {
                return View();
            }
        }

    }
}