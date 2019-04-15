using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLAD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLAD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly CLADContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(CLADContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        // GET: Consultants/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,PhoneNumber,Password")] UserViewModel user)
        {

            if (ModelState.IsValid)
            {
                IdentityUser user2 = new IdentityUser {UserName = user.Email, Email = user.Email, PhoneNumber = user.PhoneNumber};
                var result = await _userManager.CreateAsync(user2, user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("Email", result.Errors.First().Description);

            }
            return View(user);

        }

        // GET: Consultants/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            UserViewModel user2 = new UserViewModel { Email = user.Email, PhoneNumber = user.PhoneNumber};
            if (user == null)
            {
                return NotFound();
            }
            return View(user2);
        }

        // POST: Consultants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email, PhoneNumber")] UserViewModel user)
        {
                    var stamp = "jofwiejfw";
                    IdentityUser user2 = new IdentityUser { UserName = user.Email, Email = user.Email, PhoneNumber = user.PhoneNumber, SecurityStamp = stamp};
                    var user3 = await _userManager.FindByIdAsync(id);
                    await _userManager.UpdateAsync(user2);
                
                return RedirectToAction(nameof(Index));
        }


        //// GET: Users/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userManager.Users
                .FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userManager.Users
                .FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _userManager.Users.Any(e => e.Id == id);
        }
    }
}