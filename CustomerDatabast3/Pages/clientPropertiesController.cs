using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerDatabast3.Data;

namespace CustomerDatabast3.Pages
{
    public class clientPropertiesController : Controller
    {
        private readonly CustomerDatabast3Context _context;

        public clientPropertiesController(CustomerDatabast3Context context)
        {
            _context = context;
        }

        // GET: clientProperties
        public async Task<IActionResult> Index()
        {
              return _context.clientProperties != null ? 
                          View(await _context.clientProperties.ToListAsync()) :
                          Problem("Entity set 'CustomerDatabast3Context.clientProperties'  is null.");
        }

        // GET: clientProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.clientProperties == null)
            {
                return NotFound();
            }

            var clientProperties = await _context.clientProperties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientProperties == null)
            {
                return NotFound();
            }

            return View(clientProperties);
        }

        // GET: clientProperties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: clientProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName,email,phoneNumber")] clientProperties clientProperties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientProperties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientProperties);
        }

        // GET: clientProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.clientProperties == null)
            {
                return NotFound();
            }

            var clientProperties = await _context.clientProperties.FindAsync(id);
            if (clientProperties == null)
            {
                return NotFound();
            }
            return View(clientProperties);
        }

        // POST: clientProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,firstName,lastName,email,phoneNumber")] clientProperties clientProperties)
        {
            if (id != clientProperties.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientProperties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!clientPropertiesExists(clientProperties.Id))
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
            return View(clientProperties);
        }

        // GET: clientProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.clientProperties == null)
            {
                return NotFound();
            }

            var clientProperties = await _context.clientProperties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientProperties == null)
            {
                return NotFound();
            }

            return View(clientProperties);
        }

        // POST: clientProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.clientProperties == null)
            {
                return Problem("Entity set 'CustomerDatabast3Context.clientProperties'  is null.");
            }
            var clientProperties = await _context.clientProperties.FindAsync(id);
            if (clientProperties != null)
            {
                _context.clientProperties.Remove(clientProperties);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool clientPropertiesExists(int id)
        {
          return (_context.clientProperties?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
