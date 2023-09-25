using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityResturantInformation.Models;

namespace UniversityResturantInformation.Controllers
{
    public class VotesController : Controller
    {
        private readonly RestaurantDB _context;

        public VotesController(RestaurantDB context)
        {
            _context = context;
        }

        // GET: Votes
        public async Task<IActionResult> Index()
        {
            var restaurantDB = _context.Votes.Include(v => v.Menu).Include(v => v.User);
            return View(await restaurantDB.ToListAsync());
        }

        // GET: Votes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Votes
                .Include(v => v.Menu)
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // GET: Votes/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,MenuId,Date,IsFinished")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", vote.MenuId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vote.UserId);
            return View(vote);
        }

        // GET: Votes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Votes.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", vote.MenuId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vote.UserId);
            return View(vote);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,MenuId,Date,IsFinished")] Vote vote)
        {
            if (id != vote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoteExists(vote.Id))
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
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", vote.MenuId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", vote.UserId);
            return View(vote);
        }

        // GET: Votes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Votes
                .Include(v => v.Menu)
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vote = await _context.Votes.FindAsync(id);
            _context.Votes.Remove(vote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoteExists(int id)
        {
            return _context.Votes.Any(e => e.Id == id);
        }
      
        [Authorize(Roles = "User")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> vote()
        {
            try
            {


                ViewBag.BreakfastMenus = await _context.Menus
                    .Where(mx => mx.IsVoteable == true && mx.Meal == 1)
                    .ToListAsync();

                ViewBag.LunchMenus = await _context.Menus
                    .Where(mx => mx.IsVoteable == true && mx.Meal == 2)
                    .ToListAsync();

                ViewBag.DinnerMenus = await _context.Menus
                    .Where(mx => mx.IsVoteable == true && mx.Meal == 3)
                    .ToListAsync();



                ViewBag.Breakfast = await _context.Menu_Items.Include(d => d.Item)
                               .Include(m => m.Menu).Where(mx => mx.Menu.IsVoteable == true && mx.Menu.Meal == 1)
                               .ToListAsync();

                ViewBag.Lunch = await _context.Menu_Items.Include(d => d.Item)
                    .Include(m => m.Menu).Where(mx => mx.Menu.IsVoteable == true && mx.Menu.Meal == 2)
                    .ToListAsync();

                ViewBag.Dinner = await _context.Menu_Items.Include(d => d.Item)
                    .Include(m => m.Menu).Where(mx => mx.Menu.IsVoteable == true && mx.Menu.Meal == 3)
                    .ToListAsync();

                ViewBag.BreakfastSubmit = _context.Votes.Where(mx => mx.Menu.Meal == 1 && int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == mx.UserId).Count();

                ViewBag.LunchSubmit = _context.Votes.Where(mx => mx.Menu.Meal == 2 && int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == mx.UserId).Count();

                ViewBag.DinnerSubmit = _context.Votes.Where(mx => mx.Menu.Meal == 3 && int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == mx.UserId).Count();



                return View();
            }
            catch
            {
                return View();

            }
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> vote(int menuM)
        {
            try
            {
                ViewBag.BreakfastMenus = await _context.Menus
                    .Where(mx => mx.IsVoteable == true && mx.Meal == 1)
                    .ToListAsync();

                ViewBag.LunchMenus = await _context.Menus
                    .Where(mx => mx.IsVoteable == true && mx.Meal == 2)
                    .ToListAsync();

                ViewBag.DinnerMenus = await _context.Menus
                    .Where(mx => mx.IsVoteable == true && mx.Meal == 3)
                    .ToListAsync();



                ViewBag.Breakfast = await _context.Menu_Items.Include(d => d.Item)
                               .Include(m => m.Menu).Where(mx => mx.Menu.IsVoteable == true && mx.Menu.Meal == 1)
                               .ToListAsync();

                ViewBag.Lunch = await _context.Menu_Items.Include(d => d.Item)
                    .Include(m => m.Menu).Where(mx => mx.Menu.IsVoteable == true && mx.Menu.Meal == 2)
                    .ToListAsync();

                ViewBag.Dinner = await _context.Menu_Items.Include(d => d.Item)
                    .Include(m => m.Menu).Where(mx => mx.Menu.IsVoteable == true && mx.Menu.Meal == 3)
                    .ToListAsync();

                ViewBag.BreakfastSubmit = _context.Votes.Where(mx => mx.Menu.Meal == 1 && int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == mx.UserId).Count();

                ViewBag.LunchSubmit = _context.Votes.Where(mx => mx.Menu.Meal == 2 && int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == mx.UserId).Count();

                ViewBag.DinnerSubmit = _context.Votes.Where(mx => mx.Menu.Meal == 3 && int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == mx.UserId).Count();


                Vote vote = new Vote();
                vote.MenuId = menuM;
                vote.Date = DateTime.Now;
                vote.IsFinished = false;
                vote.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                _context.Votes.Add(vote);

                var m = _context.Menus.Find(menuM);
                m.TotalVotes = m.TotalVotes + 1;

                await _context.SaveChangesAsync();
                ViewData["Successful"] = "Your vote has been sent successfully!";

                return View();
            }
            catch 
            {
                return View();
            }
           
           

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> VoteResult()
        {
           

            ViewBag.BreakfastMenus = await _context.Menus
                .Where(mx => mx.IsVoteable == true && mx.Meal == 1)
                .ToListAsync();

            ViewBag.LunchMenus = await _context.Menus
                .Where(mx => mx.IsVoteable == true && mx.Meal == 2)
                .ToListAsync();

            ViewBag.DinnerMenus = await _context.Menus
                .Where(mx => mx.IsVoteable == true && mx.Meal == 3)
                .ToListAsync();



            ViewBag.Breakfast = await _context.Menu_Items.Include(d => d.Item)
                           .Include(m => m.Menu).Where(mx => mx.Menu.IsVoteable == true && mx.Menu.Meal == 1)
                           .ToListAsync();

            ViewBag.Lunch = await _context.Menu_Items.Include(d => d.Item)
                .Include(m => m.Menu).Where(mx => mx.Menu.IsVoteable == true && mx.Menu.Meal == 2)
                .ToListAsync();

            ViewBag.Dinner = await _context.Menu_Items.Include(d => d.Item)
                .Include(m => m.Menu).Where(mx => mx.Menu.IsVoteable == true && mx.Menu.Meal == 3)
                .ToListAsync();

            ViewBag.BreakfastSubmit = _context.Votes.Where(mx => mx.Menu.Meal == 1 && int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == mx.UserId).Count();

            ViewBag.LunchSubmit = _context.Votes.Where(mx => mx.Menu.Meal == 2 && int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == mx.UserId).Count();

            ViewBag.DinnerSubmit = _context.Votes.Where(mx => mx.Menu.Meal == 3 && int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == mx.UserId).Count();

            return View();
         
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VoteResult(int menuM)
        {
            var m = _context.Menus.Find(menuM);
            var n = _context.Menus.ToList().Where(mx => mx.IsActive == true && mx.Meal == m.Meal);
            foreach(var menu in n)
            {
                menu.IsActive = false;
                menu.IsVoteable = true;
                await _context.SaveChangesAsync();
            }
            m.IsVoteable = false;
            m.IsActive = true;

            await _context.SaveChangesAsync();
            return View();

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Archive(int meal , int menuM)
        {
            try {
                var m = _context.Menus.Find(menuM);
                var MI = _context.Menus.ToList().Where(mx => mx.IsActive == true && mx.Meal == m.Meal);
                foreach (var menu in MI)
                {
                    menu.IsActive = false;
                    menu.IsVoteable = true;
                    await _context.SaveChangesAsync();
                }
                m.IsVoteable = false;
                m.IsActive = true;

                await _context.SaveChangesAsync();
                var n = _context.Votes.Where(m => m.Menu.Meal == meal)
                    .ToList();

                foreach (var vote in n)
                {
                    var MArchive = _context.Menus.Find(vote.MenuId);
                    Archive archive = new Archive();
                    archive.MenuCode = vote.MenuId;
                    archive.Date = vote.Date;
                    archive.Record = m.TotalVotes;
                    _context.Archives.Add(archive);
                    m.TotalVotes = 0;
                    await _context.SaveChangesAsync();
                }
                var menuitem = _context.Menus
                    .Where(m => m.Meal == meal).ToList();

                foreach (var item in n)
                {
                    _context.Votes.Remove(item);
                }

                foreach (var item in menuitem)
                {
                    item.IsVoteable = false;
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Admin", "Users");

            }
            catch
            {
                return RedirectToAction("VoteResult", "Votes");
            }
            }

    }
}
