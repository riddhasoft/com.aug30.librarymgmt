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
    public class MemberInformationsController : Controller
    {
        private readonly AppDbContext _context;

        public MemberInformationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MemberInformations
        public async Task<IActionResult> Index()
        {
              return _context.MemberInformations != null ? 
                          View(await _context.MemberInformations.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.MemberInformations'  is null.");
        }

        // GET: MemberInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MemberInformations == null)
            {
                return NotFound();
            }

            var eMemberInformation = await _context.MemberInformations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eMemberInformation == null)
            {
                return NotFound();
            }

            return View(eMemberInformation);
        }

        // GET: MemberInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MemberInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,ContactNo,Address,IsActive")] EMemberInformation eMemberInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eMemberInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eMemberInformation);
        }

        // GET: MemberInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MemberInformations == null)
            {
                return NotFound();
            }

            var eMemberInformation = await _context.MemberInformations.FindAsync(id);
            if (eMemberInformation == null)
            {
                return NotFound();
            }
            return View(eMemberInformation);
        }

        // POST: MemberInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ContactNo,Address,IsActive")] EMemberInformation eMemberInformation)
        {
            if (id != eMemberInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eMemberInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EMemberInformationExists(eMemberInformation.Id))
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
            return View(eMemberInformation);
        }

        // GET: MemberInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MemberInformations == null)
            {
                return NotFound();
            }

            var eMemberInformation = await _context.MemberInformations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eMemberInformation == null)
            {
                return NotFound();
            }

            return View(eMemberInformation);
        }

        // POST: MemberInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MemberInformations == null)
            {
                return Problem("Entity set 'AppDbContext.MemberInformations'  is null.");
            }
            var eMemberInformation = await _context.MemberInformations.FindAsync(id);
            if (eMemberInformation != null)
            {
                _context.MemberInformations.Remove(eMemberInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EMemberInformationExists(int id)
        {
          return (_context.MemberInformations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
