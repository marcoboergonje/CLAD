using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CLAD.Data;
using CLAD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CLAD.Areas.Admin.Controllers
{
    public class RegisterModel : Controller
    {
        private readonly CLADContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal.RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(CLADContext context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal.RegisterModel> logger,
            IEmailSender emailSender)
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
