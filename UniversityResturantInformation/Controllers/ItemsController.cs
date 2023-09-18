using System.Collections.Generic;
using System.IO;
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
        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
        [Authorize(Roles = "Admin, DataEntry")]
        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.Where(u => u.IsDeleted == false).ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,ItemCode,ItemName,Cal,UploadedImage")] Item item)
        {
            if (ModelState.IsValid)
            {
                if (item.UploadedImage != null && item.UploadedImage.ContentType.StartsWith("image/"))
                {
                    // Get the image path
                    var imagePath = Path.Combine("wwwroot", "img", "items", item.UploadedImage.FileName);

                    // Save the file to the wwwroot\images\items\ directory
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await item.UploadedImage.CopyToAsync(stream);
                    }

                    // Get the relative path of the image file
                    var relativeImagePath = Path.GetRelativePath("wwwroot", imagePath);

                    // Save the relative path of the image file into the Image field
                    item.File = "\\" + relativeImagePath;
                }
                var checkItemCode = _context.Items.SingleOrDefault(u => u.ItemCode == item.ItemCode);
                var checkItemName = _context.Items.SingleOrDefault(u => u.ItemName == item.ItemName);

                if (checkItemCode != null)
                {
                    ModelState.AddModelError(string.Empty, "Item Code already exists.");

                }
                else if(checkItemName != null)
                {
                    ModelState.AddModelError(string.Empty, "Item Name already exists.");
                }
                else
                {
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

               
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemCode,ItemName,Cal,UploadedImage")] Item items)
        {
             try
            {
                
                    if (items.UploadedImage != null && items.UploadedImage.ContentType.StartsWith("image/"))
                    {
                        // Get the image path
                        var imagePath = Path.Combine("wwwroot", "img", "items", items.UploadedImage.FileName);

                        // Save the file to the wwwroot\images\items\ directory
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await items.UploadedImage.CopyToAsync(stream);
                        }

                        // Get the relative path of the image file
                        var relativeImagePath = Path.GetRelativePath("wwwroot", imagePath);

                        // Update the Image field of the items object
                        items.File = '/' + relativeImagePath.Replace('\\', '/');
                    }

                    // Retrieve the existing entity from the context
                    var existingItem = await _context.Items.FindAsync(items.Id);

                    if (existingItem == null)
                    {
                        return NotFound();
                    }

                    existingItem.ItemName = items.ItemName;
                    existingItem.ItemCode = items.ItemCode;
                    existingItem.Cal = items.Cal;
                    existingItem.IsDeleted = items.IsDeleted;
                    if (items.File == null)
                    {
                        var image = _context.Items.Find(items.Id);
                        existingItem.File=image.File;
                }
                else
                {
                    existingItem.File = items.File;

                }

                // Save the changes
                await _context.SaveChangesAsync();
        }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemsExists(items.Id))
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
            //if (id != items.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        if (items.UploadedImage != null && items.UploadedImage.ContentType.StartsWith("img/"))
            //        {
            //            // Get the image path
            //            var imagePath = Path.Combine("wwwroot", "img", "items", items.UploadedImage.FileName);

            //            // Save the file to the wwwroot\images\items\ directory
            //            using (var stream = new FileStream(imagePath, FileMode.Create))
            //            {
            //                await items.UploadedImage.CopyToAsync(stream);
            //            }

            //            // Get the relative path of the image file
            //            var relativeImagePath = Path.GetRelativePath("wwwroot", imagePath);

            //            // Update the Image field of the items object
            //            items.File = '/' + relativeImagePath.Replace('\\', '/');
            //        }
            //        _context.Update(items);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ItemExists(items.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(items);}

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
            item.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin, DataEntry")]
        public IActionResult MenuItem()
        {
            ViewBag.Item = _context.Items.Where(u => u.IsDeleted == false);
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

                ViewData["Successful"] = " The menu has been created successfully!";
                ViewBag.Item = _context.Items.Where(u => u.IsDeleted == false);
                return View();
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
            return View(await _context.Menu_Items.Include(u => u.Item).Include(u => u.Menu).ToListAsync());

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

        [Authorize(Roles = "Admin, DataEntry")]
        public async Task<IActionResult> MIDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Menu_Items.Include(x=>x.Menu).Include(y=>y.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("MIDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MIDeleteConfirmed(int id)
        {
            var item = await _context.Menu_Items.FindAsync(id);
            item.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MIIndex));
        }

        [Authorize(Roles = "Admin, DataEntry")]
        // GET: Items/Details/5
        public async Task<IActionResult> MIDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Menu_Items.Include(x=>x.Item).Include(y=>y.Menu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
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