using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UniversityResturantInformation.Models;

namespace UniversityResturantInformation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RestaurantDB _context;

        public HomeController(ILogger<HomeController> logger, RestaurantDB context)
        {
            _logger = logger;
            _context = context; 
        }
        //[Authorize(Roles = "admin , student")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Lunch = await _context.Menu_Items.Include(d => d.Item)
                .Include(m => m.Menu).Where(mx => mx.Menu.IsActive == true && mx.Menu.Meal == 2)
                .ToListAsync();
            ViewBag.Breakfast = await _context.Menu_Items.Include(d => d.Item)
                .Include(m => m.Menu).Where(mx => mx.Menu.IsActive == true && mx.Menu.Meal == 1)
                .ToListAsync();
            ViewBag.Dinner = await _context.Menu_Items.Include(d => d.Item)
                .Include(m => m.Menu).Where(mx => mx.Menu.IsActive == true && mx.Menu.Meal == 3)
                .ToListAsync();

            
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Complaint(Compliant compliant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Complaints.Add(compliant);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Username", "Id", compliant.UserId);
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> complaint(int Id, int UserId, string Title, string Description, int Catagory, DateTime Date)
        {
            if (ModelState.IsValid)
            {
                Compliant cm = new Compliant();
                cm.Id = Id;
                cm.User.Id = UserId;
                cm.Title = Title;
                cm.Description = Description;
                cm.Category = Catagory;
                cm.Date = Date;



                _context.Complaints.Add(cm);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", compliant.UserId);
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
