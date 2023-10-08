using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2_BetancurEchavarriaDavid.DAL;
using Parcial2_BetancurEchavarriaDavid.DAL.Entities;

namespace Parcial2_BetancurEchavarriaDavid.Controllers
{
    public class NaturalPersonsController : Controller
    {
        private readonly DataBaseContext _context;

        public NaturalPersonsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: NaturalPersons
        public async Task<IActionResult> Index()
        {
            return _context.NaturalPeople != null ?
                        View(await _context.NaturalPeople.ToListAsync()) :
                        Problem("Entity set 'DataBaseContext.NaturalPeople'  is null.");
        }

        // GET: NaturalPersons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.NaturalPeople == null)
            {
                return NotFound();
            }

            var naturalPerson = await _context.NaturalPeople
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naturalPerson == null)
            {
                return NotFound();
            }

            return View(naturalPerson);
        }

        // GET: NaturalPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NaturalPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Email,BirthYear,Age,Id,CreatedDate,ModifiedDate")] NaturalPerson naturalPerson)
        {
            if (ModelState.IsValid)
            {
                naturalPerson.Id = Guid.NewGuid();
                _context.Add(naturalPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(naturalPerson);
        }

        // GET: NaturalPersons/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.NaturalPeople == null)
            {
                return NotFound();
            }

            var naturalPerson = await _context.NaturalPeople.FindAsync(id);
            if (naturalPerson == null)
            {
                return NotFound();
            }
            return View(naturalPerson);
        }

        // POST: NaturalPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FullName,Email,BirthYear,Age,Id,CreatedDate,ModifiedDate")] NaturalPerson naturalPerson)
        {
            if (id != naturalPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naturalPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaturalPersonExists(naturalPerson.Id))
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
            return View(naturalPerson);
        }

        // GET: NaturalPersons/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.NaturalPeople == null)
            {
                return NotFound();
            }

            var naturalPerson = await _context.NaturalPeople
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naturalPerson == null)
            {
                return NotFound();
            }

            return View(naturalPerson);
        }

        // POST: NaturalPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.NaturalPeople == null)
            {
                return Problem("Entity set 'DataBaseContext.NaturalPeople'  is null.");
            }
            var naturalPerson = await _context.NaturalPeople.FindAsync(id);
            if (naturalPerson != null)
            {
                _context.NaturalPeople.Remove(naturalPerson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: NaturalPersons/Search
        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString) || _context.NaturalPeople == null)
            {
                return View(new List<Parcial2_BetancurEchavarriaDavid.DAL.Entities.NaturalPerson>());
            }

            searchString = searchString.ToLower();

            var searchResults = _context.NaturalPeople
                .Where(person => person.FullName.ToLower().Contains(searchString) || person.Email.ToLower().Contains(searchString))
                .ToList();

            return View(searchResults);
        }

        private bool NaturalPersonExists(Guid id)
        {
            return (_context.NaturalPeople?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
