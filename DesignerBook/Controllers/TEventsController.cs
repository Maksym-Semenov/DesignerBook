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
    public class TEventsController : Controller
    {
        private readonly DesignerBookContext _context;

        public TEventsController(DesignerBookContext context)
        {
            _context = context;
        }

       

        // GET: TEvents
        public async Task<IActionResult> Index()
        {
              return _context.Events != null ? 
                          View(await _context.Events.ToListAsync()) :
                          Problem("Entity set 'DesignerBookContext.Events'  is null.");
        }

        // GET: TEvents/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var tEvent = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tEvent == null)
            {
                return NotFound();
            }

            return View(tEvent);
        }

        // GET: TEvents/Create
        public async Task<IActionResult> Create(Guid? APersonId)
        {
            return View();
        }

        // POST: TEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventSerialNumber,EventDateRegister,NextDateCommunication,Comment")] TEvent tEvent)
        {
            if (ModelState.IsValid)
            {
                tEvent.Id = Guid.NewGuid();
                _context.Add(tEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tEvent);
        }

        // GET: TEvents/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var tEvent = await _context.Events.FindAsync(id);
            if (tEvent == null)
            {
                return NotFound();
            }
            return View(tEvent);
        }

        // POST: TEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,EventSerialNumber,EventDateRegister,NextDateCommunication,Comment")] TEvent tEvent)
        {
            if (id != tEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TEventExists(tEvent.Id))
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
            return View(tEvent);
        }

        // GET: TEvents/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var tEvent = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tEvent == null)
            {
                return NotFound();
            }

            return View(tEvent);
        }

        // POST: TEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'DesignerBookContext.Events'  is null.");
            }
            var tEvent = await _context.Events.FindAsync(id);
            if (tEvent != null)
            {
                _context.Events.Remove(tEvent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TEventExists(Guid id)
        {
          return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
