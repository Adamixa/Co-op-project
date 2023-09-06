using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UniversityResturantInformation.Models;
using UniversityResturantInformation.ViewModel;

namespace UniversityResturantInformation.Controllers
{
    public class ItemsController : Controller
    {
        private readonly RestaurantDB _context;

        public ItemsController(RestaurantDB context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin, DataEntry")]
        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        [Authorize(Roles = "Admin, DataEntry")]
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
        [Authorize(Roles = "Admin, DataEntry")]
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
        [Authorize(Roles = "Admin, DataEntry")]
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
        [Authorize(Roles = "Admin, DataEntry")]
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
        [Authorize(Roles = "Admin, DataEntry")]
        public IActionResult MenuItem()
        {
            ViewBag.Item = _context.Items;
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "ItemName");
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id");
            ViewBag.meal = new List<SelectListItem>{ 
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MenuItem(string tableInfo, int meal)
        {
            //if (ModelState.IsValid)

            Menu menue = new Menu();
            menue.IsActive = false;
            menue.IsVoteable = true;
            menue.Meal = meal;
            _context.Add(menue);
            _context.SaveChanges();
            var itemInfo = JsonConvert.DeserializeObject<List<MenuItemViewModel>>(tableInfo);
            try
            {
                // To Add Into List Table
                //
                // To Add Into Item Table
                foreach (var item in itemInfo)
                {
                    Menu_Item menu_Item = new Menu_Item();
                    menu_Item.ItemId = item.ItemId;
                    menu_Item.MenuId = menue.Id;
                    _context.Add(menu_Item);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(MIIndex));
            }
            catch
            {
                return RedirectToAction(nameof(MIIndex));
            }
        }
        //await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(MIIndex));
        //}
        //ViewData["ItemId"] = new SelectList(_context.Menu_Items, "Id", "Id", MI.ItemId);
        //ViewData["MenuId"] = new SelectList(_context.Menu_Items, "Id", "Id", MI.MenuId);
        //return View(MI);
        [Authorize(Roles = "Admin, DataEntry")]
        public async Task<IActionResult> MIIndex()
        {
            return View(await _context.Menu_Items.Include(u => u.Item).ToListAsync());

        }
        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
        [Authorize(Roles = "Admin, DataEntry")]
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, DataEntry")]
        public IActionResult Vote()
        {

            return View();
        }
    }

}