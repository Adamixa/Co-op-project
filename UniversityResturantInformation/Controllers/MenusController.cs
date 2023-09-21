using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityResturantInformation.Models;

namespace UniversityResturantInformation.Controllers
{
    public class MenusController : Controller
    {
        private readonly RestaurantDB _context;

        public MenusController(RestaurantDB context)
        {
            _context = context;
        }

        // GET: Menus
        [Authorize(Roles = "Admin, DataEntry")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menus.Where(u => u.IsDeleted == false).ToListAsync());
        }

        // GET: Menus/Details/5
        [Authorize(Roles = "Admin, DataEntry")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            ViewBag.items = await _context.Menu_Items.Include(d => d.Item)
                           .Include(m => m.Menu).Where(mx => mx.Menu.Id == id)
                           .ToListAsync();
            return View(menu);
        }

        // GET: Menus/Create
        [Authorize(Roles = "Admin, DataEntry")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsActive,Meal")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menus/Edit/5
        [Authorize(Roles = "Admin, DataEntry")]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.meal = new List<SelectListItem>{
             new SelectListItem{
                Text="Please Select Meal",
                Value = "0"
            },
            new SelectListItem{
                Text="Breakfast",
                Value = "1"
            },
            new SelectListItem{
                Text="Lunch",
                Value = "2"
            },
            new SelectListItem{
                Text="Dinner",
                Value = "3"
            } };

            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Id,IsActive,Meal,IsVoteable")] Menu menu)
        {
            ViewBag.meal = new List<SelectListItem>{
            new SelectListItem{
                Text="Please Select Meal",
                Value = "0"
            },
            new SelectListItem{
                Text="Breakfast",
                Value = "1"
            },
            new SelectListItem{
                Text="Lunch",
                Value = "2"
            },
            new SelectListItem{
                Text="Dinner",
                Value = "3"
            } };
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var x = await _context.Menus.FindAsync(id);
                    x.IsActive = menu.IsActive;
                    x.IsVoteable = menu.IsVoteable;
                    if(menu.Meal != 0)
                    {
                        x.Meal = menu.Meal;
                    }
                    _context.Update(x);
                    await _context.SaveChangesAsync();
                    if (menu.IsActive)
                    {
                        foreach (var item in _context.Menus.Where(m => m.Meal == menu.Meal).ToList())
                        {
                            item.IsActive = false;
                        }
                        menu.IsActive = true;
                        await _context.SaveChangesAsync();
                    }
                    

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            
            return View(menu);
        }

        // GET: Menus/Delete/5
        [Authorize(Roles = "Admin, DataEntry")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewBag.items = await _context.Menu_Items.Include(d => d.Item)
                           .Include(m => m.Menu).Where(mx => mx.Menu.Id == id)
                           .ToListAsync();
            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            menu.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}
