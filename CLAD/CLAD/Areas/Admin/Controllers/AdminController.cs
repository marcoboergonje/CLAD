using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLAD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CLAD.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly CLADContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(CLADContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_userManager.Users);
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

        // GET: Consultants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consultants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,Password,Role")] IdentityUser User)
        {
       
            if (ModelState.IsValid)
            {
                await _userManager.UpdateAsync(User);
                return RedirectToAction(nameof(Index));

            }
            

            if (ModelState.IsValid)
            {
                await _userManager.UpdateAsync(User);
     
                return RedirectToAction(nameof(Index));

            }
            return View(User);
        }

        // GET: Consultants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultant.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }
            return View(consultant);
        }

        //// post: consultants/edit/5
        //// to protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?linkid=317598.
        //[httppost]
        //[validateantiforgerytoken]
        //public async task<iactionresult> edit(int id, [bind("id,description,displayname,imgname")] consultant consultant)
        //{
        //    if (id != consultant.id)
        //    {
        //        return notfound();
        //    }

        //    if (modelstate.isvalid)
        //    {
        //        try
        //        {
        //            _context.update(consultant);
        //            await _context.savechangesasync();
        //        }
        //        catch (dbupdateconcurrencyexception)
        //        {
        //            if (!consultantexists(consultant.id))
        //            {
        //                return notfound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return redirecttoaction(nameof(index));
        //    }
        //    return view(consultant);
        //}

         // GET: Users/Delete/5
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
