using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pet_Store_BE.Data;
using Pet_Store_BE.Models;

namespace Pet_Store_BE.Controllers
{
    public class PetsController : Controller
    {
        private readonly Pet_Store_BEContext _context;

        public PetsController(Pet_Store_BEContext context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index(string s)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from p in _context.Pet orderby p.Purebred select p.Purebred;
            var pets = from p in _context.Pet select p;
            if (!String.IsNullOrEmpty(s))
                pets = pets.Where(str => str.Species!.Contains(s));
            var petPureVM = new PetPureViewModel
            {
                Purebred = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Pets = await pets.ToListAsync()
            };
            return View(petPureVM);
            ///*f7*/return View(await pets.ToListAsync());
            ///*First*/return View(await _context.Pet.ToListAsync());
        }

        public async Task<IActionResult> Index_admin(string s)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from p in _context.Pet orderby p.Purebred select p.Purebred;
            var pets = from p in _context.Pet select p;
            if (!String.IsNullOrEmpty(s))
                pets = pets.Where(str => str.Species!.Contains(s));
            var petPureVM = new PetPureViewModel
            {
                Purebred = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Pets = await pets.ToListAsync()
            };
            return View(petPureVM);
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Img,Species,Purebred,Origin,Amount,Price")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Img,Species,Purebred,Origin,Amount,Price")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
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
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pet = await _context.Pet.FindAsync(id);
            _context.Pet.Remove(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(string id)
        {
            return _context.Pet.Any(e => e.Id == id);
        }
    }
}
