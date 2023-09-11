using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityResturantInformation.Models;
using System.Security.Claims;
using System.Collections.Generic;
using UniversityResturantInformation.ViewModel;
using System.Reflection;
using System;

namespace UniversityResturantInformation.Controllers
{
    public class RatingsController : Controller
    {
        private readonly RestaurantDB _context;

        public RatingsController(RestaurantDB context)
        {
            _context = context;
        }

        // GET: Ratings
        public async Task<IActionResult> Index()
        {
            var restaurantDB = _context.Ratings.Include(r => r.Item).Include(r => r.User);
            return View(await restaurantDB.ToListAsync());
        }

        [Authorize(Roles = "User")] 
        public /*async*/ IActionResult Rate()
        {
            var  Item = _context.Items.ToList();
            var Item2 = _context.Items.ToList();
            var Ratings = _context.Ratings.Where(R => R.UserId == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            foreach(var i in Item)
            {
                foreach(var j in Ratings)
                {
                    if (i.Id == j.ItemId)
                    {
                        Item2.Remove(i);
                    }
                }
                }
            //ViewBag.Rate = await _context.Menu_Items.Include(d => d)
            //    .Include(m => m.Menu).Where(mx => mx.Menu.IsActive == true)
            //    .ToListAsync();
            return View(Item2);
        }
        [Authorize (Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rate(int RateItem , int Item)
        {
            //ViewBag.RateSubmit = _context.Ratings.Where(mx => mx.UserId == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)).Count();
            try
            {

                var UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var CountItem = _context.Ratings.Where(I => I.ItemId == Item).Count();
                var it = _context.Items.Where(t => t.Id == Item).SingleOrDefault();
                Rating rating = new Rating();
                decimal average = 0.0m;

                if (CountItem == 0)
                {
                    rating.total = RateItem;
                    rating.Rate = RateItem;
                    rating.ItemId = Item;
                    rating.UserId = UserId;
                    _context.Ratings.Add(rating);
                    await _context.SaveChangesAsync();

                }
                else
                {

                   
                    rating.Rate = RateItem;
                    rating.ItemId = Item;
                    rating.UserId = UserId;
                    rating.total = RateItem;
                    _context.Ratings.Add(rating);
                    await _context.SaveChangesAsync();

                }
                var total = _context.Ratings.Count(r => r.ItemId == Item);
                var fivestar = _context.Ratings.Where(s5 => s5.Rate == 5 && s5.ItemId == Item).Count();
                var fourestar = _context.Ratings.Where(s4 => s4.Rate == 4 && s4.ItemId == Item).Count();
                var threestar = _context.Ratings.Where(s3 => s3.Rate == 3 && s3.ItemId == Item).Count();
                var twostar = _context.Ratings.Where(s2 => s2.Rate == 2 && s2.ItemId == Item).Count();
                var onestar = _context.Ratings.Where(s1 => s1.Rate == 1 && s1.ItemId == Item).Count();
                average = (decimal)((float)(onestar + (twostar * 2) + (threestar * 3) + (fourestar * 4) + (fivestar * 5)) / (total));
                it.NumberOfRating = onestar + twostar + threestar + fourestar + fivestar;
                it.Total = (float)Math.Round(average, 2);
                _context.Update(it);
                await _context.SaveChangesAsync();

                ViewData["Successful"] = "Rating submitted successfully!";
           
                //ViewBag.ItemSubmit = _context.Ratings.Where(us => us.UserId == UserId && Item == userRating.ItemId).Count();

                var Item1 = _context.Items;
                return View(Item1);
            }
            catch
            {
                ViewData["Falied"] = "Falied";
                var Item1 = _context.Items;
                return View(Item1);
            }

            // Use SweetAlert to display the success message
        }

        public async Task<IActionResult> RatingResult()
        {
            return View(await _context.Items.Where(u => u.IsDeleted == false).ToListAsync());
        }



        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Ratings
                .Include(r => r.Item)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ItemId,Rate")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id", rating.ItemId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rating.UserId);
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id", rating.ItemId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rating.UserId);
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ItemId,Rate")] Rating rating)
        {
            if (id != rating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.Id))
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
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id", rating.ItemId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rating.UserId);
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Ratings
                .Include(r => r.Item)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(int id)
        {
            return _context.Ratings.Any(e => e.Id == id);
        }
    }
}
