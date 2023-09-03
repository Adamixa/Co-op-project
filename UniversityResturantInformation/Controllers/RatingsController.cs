using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityResturantInformation.Models;
using System.Security.Claims;


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

        [Authorize(Roles = "Student")] 
        public /*async*/ IActionResult Rate()
        {
            var Item = _context.Items;
            //ViewBag.Rate = await _context.Menu_Items.Include(d => d)
            //    .Include(m => m.Menu).Where(mx => mx.Menu.IsActive == true)
            //    .ToListAsync();
            return View(Item);
        }
        [Authorize (Roles = "Student")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rate(int[] RateItem , int[] Item)
        {
            ViewBag.RateSubmit = _context.Ratings.Where(mx => mx.UserId == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)).Count();

            var UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            for ( var j = 0; j < Item.Length; j++)
            {
                Rating rating = new Rating();
                rating.Rate = RateItem[j];
                rating.ItemId = Item[j];
                rating.UserId = UserId;
                _context.Ratings.Add(rating);
            }

            await _context.SaveChangesAsync();
            //var item = _context.Items.Include(i => i.Id);

            return RedirectToAction("Index" , "Home");
        }

        public async Task<IActionResult> RatingResult()
        {

            var result = _context.Ratings
                .Include(i =>i.Item)
                .Include(u =>u.User);
            return View(result);
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
