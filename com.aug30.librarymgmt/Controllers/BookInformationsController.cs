using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using com.aug30.librarymgmt.Data;
using com.aug30.librarymgmt.Models;

namespace com.aug30.librarymgmt.Controllers
{
    public class BookInformationsController : Controller
    {
        private readonly AppDbContext _context;

        public BookInformationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BookInformations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BookInformations.Include(e => e.BookCategory);
            return View(await appDbContext.ToListAsync());
        }

        // GET: BookInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookInformations == null)
            {
                return NotFound();
            }

            var eBookInformation = await _context.BookInformations
                .Include(e => e.BookCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eBookInformation == null)
            {
                return NotFound();
            }

            return View(eBookInformation);
        }

        // GET: BookInformations/Create
        public IActionResult Create()
        {
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategories, "Id", "Name");
            return View();
        }

        // POST: BookInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Publication,ISBN,Barcode,Author,Edition,BookCategoryId")] EBookInformation eBookInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eBookInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategories, "Id", "Name", eBookInformation.BookCategoryId);
            return View(eBookInformation);
        }

        // GET: BookInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookInformations == null)
            {
                return NotFound();
            }

            var eBookInformation = await _context.BookInformations.FindAsync(id);
            if (eBookInformation == null)
            {
                return NotFound();
            }
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategories, "Id", "Name", eBookInformation.BookCategoryId);
            return View(eBookInformation);
        }

        // POST: BookInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Publication,ISBN,Barcode,Author,Edition,BookCategoryId")] EBookInformation eBookInformation)
        {
            if (id != eBookInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eBookInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EBookInformationExists(eBookInformation.Id))
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
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategories, "Id", "Name", eBookInformation.BookCategoryId);
            return View(eBookInformation);
        }

        // GET: BookInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookInformations == null)
            {
                return NotFound();
            }

            var eBookInformation = await _context.BookInformations
                .Include(e => e.BookCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eBookInformation == null)
            {
                return NotFound();
            }

            return View(eBookInformation);
        }

        // POST: BookInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookInformations == null)
            {
                return Problem("Entity set 'AppDbContext.BookInformations'  is null.");
            }
            var eBookInformation = await _context.BookInformations.FindAsync(id);
            if (eBookInformation != null)
            {
                _context.BookInformations.Remove(eBookInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EBookInformationExists(int id)
        {
          return (_context.BookInformations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
