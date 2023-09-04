using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityResturantInformation.Models;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using BCrypt.Net;
namespace UniversityResturantInformation.Controllers
{
    public class UsersController : Controller
    {
        private readonly RestaurantDB _context;

        public UsersController(RestaurantDB context)
        {
            _context = context;
        }

        // GET: Users
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var restaurantDB = _context.Users.Include(u => u.Role);
            return View(await restaurantDB.ToListAsync());
        }

        // GET: Users/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Username,RoleId,Name,Mobile,Password,Email")] User user)
        {

            if (ModelState.IsValid)
            {
                var checkUser = _context.Users.SingleOrDefault(u => u.Username == user.Username);

                if (checkUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Username already exists.");

                }
                else
                {
                    string hashpass = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    user.Password = hashpass;
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", user.RoleId);
                return View(user);
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", user.RoleId);
            return View(user);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,RoleId,Name,Mobile,Password,Email")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }



        //public async Task<IActionResult> Login(string username, string password)

        //{

        #region Login/Logout
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            try
            {
                string UserName = User.FindFirst(ClaimTypes.Name).Value;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var pass = _context.Users.Where(u => u.Username == username).SingleOrDefault();
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, pass.Password);

                var check = _context.Users.Include(R => R.Role).Where(u => u.Username == username && (isValidPassword == true || u.Password==password)).SingleOrDefault();

                if (check != null)
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, check.Username),
                    new Claim(ClaimTypes.Role, check.Role.RoleName),
                    new Claim(ClaimTypes.NameIdentifier, check.Id.ToString()),
                    new Claim(ClaimTypes.GivenName, check.Name),
                    new Claim(ClaimTypes.Email, check.Email.ToString())

                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal);


                    if (check.Role.RoleName == "Admin")
                    {
                        return RedirectToAction("Admin", "Users");
                    }

                    else if (check.Role.RoleName == "DataEntry")
                    {
                        return RedirectToAction("DataEntry", "Users");
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }

                // else if (checkS != null)
                //{
                //    var identity = new ClaimsIdentity(new[]
                //    {
                //    new Claim(ClaimTypes.Name, checkS.Username),
                //    new Claim(ClaimTypes.Role, checkS.Role.RoleName),
                //    new Claim(ClaimTypes.NameIdentifier, checkS.Id.ToString()),
                //    new Claim(ClaimTypes.GivenName, checkS.Name)

                //}, CookieAuthenticationDefaults.AuthenticationScheme);

                //    var principal = new ClaimsPrincipal(identity);

                //    await HttpContext.SignInAsync(
                //        CookieAuthenticationDefaults.AuthenticationScheme,
                //        principal);

                //    return RedirectToAction("Index", "Home");

                //}

                else
                {
                    ViewData["Login_error"] = "ERORR: Username or password is not correct";
                    return View();
                }
            }
            catch
            {
                ViewData["Login_error"] = "ERORR: Username or password is not correct";
                return View();
            }

        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index" , "Home");
        }

        

        #endregion Login/Logout









        //    var check = _context.Users.Where(d => d.Username == username && d.Password == password).SingleOrDefault();

        //    if (check == null)
        //    {
        //        ViewBag.ErrorMessage = "Username or password is not correct";
        //        return View();
        //    }


        //        return RedirectToAction("Index" , "Home");

        //}
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }
        [Authorize(Roles = "DataEntry")]
        public IActionResult DataEntry()
        {
            return View();
        }

    }


}

