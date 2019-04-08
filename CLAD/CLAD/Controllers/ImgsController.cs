using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLAD.Models;
using CLAD.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CLAD.Controllers
{
    public class ImgsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public ImgsController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Imgs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Img.ToListAsync());
        }

        // GET: Imgs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var img = await _context.Img
                .FirstOrDefaultAsync(m => m.Id == id);
            if (img == null)
            {
                return NotFound();
            }

            return View(img);
        }

        // GET: Imgs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imgs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImgName")] Img img, IFormFile file)
        {
            UploadFile(file, _env);
            img.ImgName = file.FileName;

            if (ModelState.IsValid)
            {
                _context.Add(img);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(img);
        }

        private void UploadFile(IFormFile file, IHostingEnvironment env)
        {

            var fileName = file.FileName;
            var path = Path.Combine(env.WebRootPath + "/img/Uploads/" + fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }

        // GET: Imgs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var img = await _context.Img.FindAsync(id);
            if (img == null)
            {
                return NotFound();
            }
            return View(img);
        }

        // POST: Imgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImgName")] Img img)
        {
            if (id != img.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(img);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImgExists(img.Id))
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
            return View(img);
        }

        // GET: Imgs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var img = await _context.Img
                .FirstOrDefaultAsync(m => m.Id == id);
            if (img == null)
            {
                return NotFound();
            }

            return View(img);
        }

        // POST: Imgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var img = await _context.Img.FindAsync(id);
            _context.Img.Remove(img);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImgExists(int id)
        {
            return _context.Img.Any(e => e.Id == id);
        }
    }
}
