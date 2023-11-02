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
    public class BookCategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public BookCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BookCategories
        public async Task<IActionResult> Index()
        {
              return _context.BookCategories != null ? 
                          View(await _context.BookCategories.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.BookCategories'  is null.");
        }

        // GET: BookCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }

            var eBookCategory = await _context.BookCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eBookCategory == null)
            {
                return NotFound();
            }

            return View(eBookCategory);
        }

        // GET: BookCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name")] EBookCategory eBookCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eBookCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eBookCategory);
        }

        // GET: BookCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }

            var eBookCategory = await _context.BookCategories.FindAsync(id);
            if (eBookCategory == null)
            {
                return NotFound();
            }
            return View(eBookCategory);
        }

        // POST: BookCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name")] EBookCategory eBookCategory)
        {
            if (id != eBookCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eBookCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EBookCategoryExists(eBookCategory.Id))
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
            return View(eBookCategory);
        }

        // GET: BookCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }

            var eBookCategory = await _context.BookCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eBookCategory == null)
            {
                return NotFound();
            }

            return View(eBookCategory);
        }

        // POST: BookCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookCategories == null)
            {
                return Problem("Entity set 'AppDbContext.BookCategories'  is null.");
            }
            var eBookCategory = await _context.BookCategories.FindAsync(id);
            if (eBookCategory != null)
            {
                _context.BookCategories.Remove(eBookCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EBookCategoryExists(int id)
        {
          return (_context.BookCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
