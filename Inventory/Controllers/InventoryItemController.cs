using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Views.InventorySheet
{
    [Authorize]
    [Route("inventory")]
    public class InventoryItemController : Controller
    {
        public ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public InventoryItemController(ApplicationDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // GET: InventoryItem/Details/5
        [Route("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            InventoryItem item = await _db.InventoryItems.FirstOrDefaultAsync(i => i.Id == id);

            return View(item);
        }

        [Route("item/create/{id}")]
        // GET: InventoryItem/Create
        public ActionResult Create(int id)
        {
            // id - это индентификатор ведомости InventorySheet
            ViewBag.SheetId = id;

            return View();
        }

        // POST: InventoryItem/Create
        [HttpPost]
        [Route("item/create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InventoryItem _inventoryItem)
        {
            try
            {
                // TODO: Add insert logic here
                _db.InventoryItems.Add(_inventoryItem);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "InventorySheet");
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryItem/Edit/5
        [Route("item/edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            InventoryItem inventoryItem = await _db.InventoryItems.FirstOrDefaultAsync(i => i.Id == id);
            ViewBag.SheetId = inventoryItem.InventorySheetId;

            return View("Create", inventoryItem);
        }

        // POST: InventoryItem/Edit/5
        [HttpPost]
        [Route("item/edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(InventoryItem _inventoryItem)
        {
            try
            {
                // TODO: Add update logic here
                _db.InventoryItems.Update(_inventoryItem);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "InventorySheet");
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryItem/Delete/5
        [Route("item/delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                InventoryItem inventoryItem = await _db.InventoryItems
                    .FirstOrDefaultAsync(s => s.Id == id);
                _db.InventoryItems.Remove(inventoryItem);
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