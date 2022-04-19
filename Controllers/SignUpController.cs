using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pet_Store_BE.Data;
using Pet_Store_BE.Models;
using System.Text.Encodings.Web;

namespace Pet_Store_BE.Controllers
{
    public class SignUpController : Controller
    {
        private readonly Pet_Store_BEContext _context;

        public SignUpController(Pet_Store_BEContext context)
        {
            _context = context;
        }

        // GET: SignUp
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: SignUp/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: SignUp/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: SignUp/SignIn
        public IActionResult SignIn()
        {
            return View();
        }

        // POST: SignUp/Signin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(string account, string password)
        {

            var log_acc = from la in _context.Customer select la;
            if (!String.IsNullOrEmpty(account))
            {
                log_acc = log_acc.Where(a => a.Account!.Contains(account));
                if (!String.IsNullOrEmpty(password))
                {
                    log_acc = log_acc.Where(a => a.Password!.Contains(password));
                }
            }
            else return NotFound();
            //var customer = await _context.Customer.FirstOrDefaultAsync(m => m.Account == acc);


            return View();
        }

        // POST: SignUp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Account,Password,Name,PhoneNum,Email,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: SignUp/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: SignUp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Account,Password,Name,PhoneNum,Email,Address")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: SignUp/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: SignUp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
