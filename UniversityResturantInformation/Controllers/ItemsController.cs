using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityResturantInformation.Models;

namespace UniversityResturantInformation.Controllers
{
    public class ItemsController : Controller
    {
        private readonly RestaurantDB _context;

        public ItemsController(RestaurantDB context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemCode,ItemName,Cal")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemCode,ItemName,Cal")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult MenuItem()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "ItemName");
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id");
            return View();
        }
        //public async Task<IActionResult> MenuItem([Bind("Id,ItemId,MenuId")] Menu_Item MI)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(MI);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(MIIndex));
        //    }
        //    ViewData["ItemId"] = new SelectList(_context.Menu_Items, "Id", "Id", MI.ItemId);
        //    ViewData["MenuId"] = new SelectList(_context.Menu_Items, "Id", "Id", MI.MenuId);
        //    return View(MI);
        //}
        public async Task<IActionResult> MIIndex()
        {
            return View(await _context.Menu_Items.Include(u => u.Item).ToListAsync());
        }
        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }


        public async Task<IActionResult> MenuItemEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Menu_Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "ItemName");
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id");
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MenuItemEdit(int id, [Bind("Id,ItemId, MenuId")] Menu_Item MenuItem)
        {
            if (id != MenuItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(MenuItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(MenuItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MIIndex));
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "ItemName");
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id");
            return View(MenuItem);
        }


        

    }



}
