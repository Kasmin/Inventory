using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Views.InventorySheet
{
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
            ViewBag.SheetId = id;

            return View();
        }

        // POST: InventoryItem/Create
        [HttpPost]
        [Route("item/create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index", "InventorySheet");
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryItem/Edit/5
        [Route("item/edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryItem/Edit/5
        [HttpPost]
        [Route("item/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index", "InventorySheet");
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryItem/Delete/5
        [Route("item/delete/{id}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryItem/Delete/5
        [HttpPost]
        [Route("item/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index", "InventorySheet");
            }
            catch
            {
                return View();
            }
        }
    }
}