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
using System.Net.Mail;
using UniversityResturantInformation.ViewModel;

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
            var restaurantDB = _context.Users.Include(u => u.Role).Where(u => u.IsDeleted == false);
            return View(await restaurantDB.ToListAsync());
        }

        // GET: Users/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Guid == id);
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", user.RoleId);
            if (ModelState.IsValid)
            {
                var checkUser = _context.Users.SingleOrDefault(u => u.Username == user.Username);
                var checkEmail = _context.Users.SingleOrDefault(u => u.Email == user.Email);
                try
                {
                    if (checkUser != null)
                    {
                        ModelState.AddModelError(string.Empty, "Username already exists.");
                        return View(user);

                    }
                    if(checkEmail != null)
                    {
                        ModelState.AddModelError(string.Empty, "Email already exists.");
                        return View(user);
                    }
                    else
                    {
                        string hashpass = BCrypt.Net.BCrypt.HashPassword(user.Password);
                        user.Password = hashpass;
                        user.Guid = Guid.NewGuid();
                        _context.Add(user);
                        await _context.SaveChangesAsync();
                        ViewData["Successful"] = "Adding user successfully!";
                        return View(user);
                    }
                }
                catch
                {
                    ViewData["Falied"] = "Falied";
                    return View(user);
                }
                
            }
            return View(user);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(P => P.Guid == id);
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
        public async Task<IActionResult> Edit(Guid id , string Mobile)
        {
            var check = await _context.Users.SingleOrDefaultAsync(P => P.Guid == id);

            if (id != check.Guid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                User userInfo = _context.Users.SingleOrDefault(U => U.Guid == check.Guid);

                try
                {
                    userInfo.Mobile = Mobile;
                    _context.Update(userInfo);
                    await _context.SaveChangesAsync();
                    ViewData["Successful"] = "Mobile number has been changed successfully!";

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(check.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View(userInfo);
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", check.Role.RoleName);
            return View(check);
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Guid == id);
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
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Guid == id);
            user.IsDeleted = true;
            await _context.SaveChangesAsync();
            ViewData["Successful"] = "User has been deleted successfully!";

            return View(user);
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
                var check = _context.Users.Include(R => R.Role).Where(u => u.Username == username && (isValidPassword == true)).SingleOrDefault();

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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgetPassword()
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
        public IActionResult ForgetPassword(string Email)
        {

            var emailCheck = _context.Users.Where(s => s.Email == Email).FirstOrDefault();
            // Get the email address to send the message to
            if (emailCheck == null)
            {
                ViewBag.email = "This email does not exist";
                return View();
            }
            else
            {
                try
                {
                    //// Get the student's email



                    var emailTo = Email;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("cooptraning@gmail.com"),
                        Subject = "Thank you for your request",
                        Body = "Enter This link to change your password https://localhost:44365/users/changePassword/" + emailCheck.Guid,
                        IsBodyHtml = false,
                    };

                    var MailClient = new SmtpClient("smtp.gmail.com", 587)
                    {

                        EnableSsl = true,

                        Credentials = new System.Net.NetworkCredential("cooptraning@gmail.com", "vsstbvnrhgmgshzs"),

                    };

                    mailMessage.To.Add(emailTo);
                    MailClient.Send(mailMessage);
                    ViewBag.succ = "Sent succefully";
                    return RedirectToAction("Index" , "Home");
                }
                catch
                {
                    // Handle the error
                    ViewBag.fail = "Sent Failed";

                }
            }


            return View();

        }

        public IActionResult changePassword(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.Users.Where(x => x.Guid == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> changePassword(Guid? id, string pass1, string pass2, [Bind("Id,Username,RoleId,Name,Mobile,Password,Email")] User user)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (pass1 == pass2)
            {
                try
                {
                    
                    var pass = _context.Users.Where(x => x.Guid == id).FirstOrDefault();
                    _context.Attach(pass);
                    string hashpass = BCrypt.Net.BCrypt.HashPassword(pass1);
                    user.Password = hashpass;
                    _context.Entry(pass).Property(x => x.Password).CurrentValue = hashpass;
                    await _context.SaveChangesAsync();
                    ViewBag.succ = "The password has changed succefully";
                    ViewData["Successful"] = "The password has changed successfully!";
                    return View(user);
                }
                catch
                {
                    ViewBag.fail = "Somthing wrong happend";
                    return View(user);
                }
            }
            else
            {
                ViewBag.wrong = "The passwords should be the same";
                return View(user);
            }



        }

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
            // Count users
            int userCount = _context.Users.Count(d => d.IsDeleted == false);

            // Count ratings
            int ratingCount = _context.Ratings.Count();

            // Count votes
            int voteCount = _context.Votes.Count();

            // Count items
            int itemCount = _context.Items.Count(d => d.IsDeleted == false);

            // Count menus
            int menuCount = _context.Menus.Count(d =>d.IsDeleted==false);

            int complaint = _context.Complaints.Count();

            // Now, you have the counts for each entity

            return View(new CountsViewModels
            {
                user = userCount,
                rating = ratingCount,
                vote = voteCount,
                item = itemCount,
                menu = menuCount,
                complaint = complaint
            });
        }
                   
        [Authorize(Roles = "DataEntry")]
        public IActionResult DataEntry()
        {
            return View();
        }

    }


}

