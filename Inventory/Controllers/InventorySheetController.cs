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
            // Получаем ID залогиненного пользователя
            string userGuidString = _userManager.GetUserId(HttpContext.User);
            Guid userGuid = new Guid(userGuidString);

            List<InventorySheet> sheets = await _db.InventorySheets
                .Where(s => s.UserId == userGuid)
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
            return View();
        }

        // POST: 
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InventorySheet _inventorySheet)
        {
            try
            {
                // TODO: Add insert logic here
                string userGuidString = _userManager.GetUserId(HttpContext.User);
                _inventorySheet.UserId = new Guid(userGuidString);

                _db.InventorySheets.Add(_inventorySheet);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "InventorySheet");
            }
            catch
            {
                return View();
            }
        }

        // GET: 
        [Route("edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            InventorySheet inventorySheet = await _db.InventorySheets
                .FirstOrDefaultAsync(s => s.Id == id);

            return View(inventorySheet);
        }

        // POST:
        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, InventorySheet _inventorySheet)
        {
            try
            {
                // TODO: Add update logic here
                InventorySheet inventorySheet = await _db.InventorySheets
                    .FirstOrDefaultAsync(s => s.Id == id);
                inventorySheet.AccountNumber = _inventorySheet.AccountNumber;
                _db.InventorySheets.Update(inventorySheet);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "InventorySheet");
            }
            catch
            {
                return View();
            }
        }

        // GET: 
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                InventorySheet inventorySheet = await _db.InventorySheets
                    .FirstOrDefaultAsync(s => s.Id == id);
                _db.InventorySheets.Remove(inventorySheet);
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