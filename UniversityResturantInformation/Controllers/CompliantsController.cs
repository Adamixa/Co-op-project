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
    public class CompliantsController : Controller
    {
        private readonly RestaurantDB _context;

        public CompliantsController(RestaurantDB context)
        {
            _context = context;
        }

        // GET: Compliants
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var restaurantDB = _context.Complaints.Include(c => c.User);
            return View(await restaurantDB.ToListAsync());
        }

        // GET: Compliants/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compliant = await _context.Complaints
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compliant == null)
            {
                return NotFound();
            }

            return View(compliant);
        }

        // GET: Compliants/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Compliants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Title,Description,Category,Date")] Compliant compliant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compliant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", compliant.UserId);
            return View(compliant);
        }

        // GET: Compliants/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compliant = await _context.Complaints.FindAsync(id);
            if (compliant == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", compliant.UserId);
            return View(compliant);
        }

        // POST: Compliants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Title,Description,Category,Date")] Compliant compliant)
        {
            if (id != compliant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compliant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompliantExists(compliant.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", compliant.UserId);
            return View(compliant);
        }

        // GET: Compliants/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compliant = await _context.Complaints
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compliant == null)
            {
                return NotFound();
            }

            return View(compliant);
        }

        // POST: Compliants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compliant = await _context.Complaints.FindAsync(id);
            _context.Complaints.Remove(compliant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CompliantExists(int id)
        {
            return _context.Complaints.Any(e => e.Id == id);
        }
    }
}
