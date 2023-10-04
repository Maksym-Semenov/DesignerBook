using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesignerBook.Data;
using DesignerBook.Models;

namespace DesignerBook.Controllers
{
    public class TPersonsController : Controller
    {
        private readonly DesignerBookContext _context;

        public TPersonsController(DesignerBookContext context)
        {
            _context = context;
        }

        //public async Task FillViewData(TPerson APerson = null, Guid? APersonId = null)
        //{
        //    TPerson? vPerson = APersonId != null ? await _context.Persons.FindAsync(APersonId) : null;
        //    if (vPerson != null)
        //    {
        //        ViewData["Person"] = vPerson;
        //    }
        //    else
        //    {
        //        ViewData["PersonList"] = new SelectList(_context.Persons.OrderBy(t => t.LastName), "Id", "LastName");
        //    }
        //}

        // GET: TPersons
        public async Task<IActionResult> Index()
        {
            //await FillViewData();
              return _context.Persons != null ? 
                          View(await _context.Persons.ToListAsync()) :
                          Problem("Entity set 'DesignerBookContext.Persons'  is null.");
        }

        // GET: TPersons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var tPerson = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tPerson == null)
            {
                return NotFound();
            }

            return View(tPerson);
        }

        // GET: TPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName")] TPerson tPerson)
        {
            if (ModelState.IsValid)
            {
                tPerson.Id = Guid.NewGuid();
                _context.Add(tPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tPerson);
        }

        // GET: TPersons/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var tPerson = await _context.Persons.FindAsync(id);
            if (tPerson == null)
            {
                return NotFound();
            }
            return View(tPerson);
        }

        // POST: TPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,MiddleName,LastName")] TPerson tPerson)
        {
            if (id != tPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TPersonExists(tPerson.Id))
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
            return View(tPerson);
        }

        // GET: TPersons/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var tPerson = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tPerson == null)
            {
                return NotFound();
            }

            return View(tPerson);
        }

        // POST: TPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Persons == null)
            {
                return Problem("Entity set 'DesignerBookContext.Persons'  is null.");
            }
            var tPerson = await _context.Persons.FindAsync(id);
            if (tPerson != null)
            {
                _context.Persons.Remove(tPerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TPersonExists(Guid id)
        {
          return (_context.Persons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
