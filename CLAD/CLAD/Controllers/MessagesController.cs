using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLAD.Data;
using CLAD.Models;
using System.Net.Mail;

namespace CLAD.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(await _context.Message.ToListAsync());
            }
            else
            {
                return View("NoAuth");
            }
        }

        public async Task<IActionResult> FAQ()
        {
             return View(await _context.Message.ToListAsync());
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Message
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Beantwoorden(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Message
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }


            //MailMessage msg = new MailMessage();
            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //try
            //{
            //    msg.Subject = "Reactie van CeeLearnAndDo";
            //    msg.Body = "Add Email Body Part";
            //    msg.From = new MailAddress("fixitgroep@gmail.com");
            //    msg.To.Add(message.Email);
            //    msg.IsBodyHtml = true;
            //    client.Host = "smtp.gmail.com";
            //    System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("fixitgroep@gmail.com", "Welkom123!");
            //    client.Port = int.Parse("587");
            //    client.EnableSsl = true;
            //    client.UseDefaultCredentials = false;
            //    client.Credentials = basicauthenticationinfo;
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    client.Send(msg);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            return View(message);
        }

        public async Task<IActionResult> Stuuremail(int id, [Bind("Email,Name,Answer")] Message message)
        {
            Console.WriteLine("IN DE FUNCTIE");
            MailMessage msg = new MailMessage();
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            
                Console.WriteLine("IN DE Debug");
                Console.WriteLine("Content : " + message.Content);
                Console.WriteLine("Date : " + message.Date);
                Console.WriteLine("Email : " + message.Email);
                Console.WriteLine("Id : " + message.Id);
                Console.WriteLine("Name : " + message.Name);
                Console.WriteLine("Phone number :" + message.PhoneNumber);
                Console.WriteLine("Answer :" + message.Answer);

                msg.Subject = "Reactie van CeeLearnAndDo";
                msg.Body = message.Answer;
                msg.From = new MailAddress("fixitgroep@gmail.com");
                msg.To.Add(message.Email);
                msg.IsBodyHtml = true;
                Console.WriteLine("Na html");
                client.Host = "smtp.gmail.com";
                System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("fixitgroep@gmail.com", "Welkom123!");
                client.Port = int.Parse("587");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicauthenticationinfo;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                Console.WriteLine("Voor einde");
                client.Send(msg);
            return View("Succes");
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,Date,Email,Id,Name,PhoneNumber,Answer")] Message message)
        {
            //ModelState["message"].Errors.Clear();
            Console.WriteLine("In de functie");
            message.Date = DateTime.Today;
            message.Answer = "";
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return View("Succes");
            }
            return View(message);
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Content,Date,Email,Id,Name,PhoneNumber")] Message message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
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
            return View(message);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Message
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var message = await _context.Message.FindAsync(id);
            _context.Message.Remove(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id)
        {
            return _context.Message.Any(e => e.Id == id);
        }
    }
}
