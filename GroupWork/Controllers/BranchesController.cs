using GroupWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupWork.Controllers
{
  
        public class BranchesController : Controller
        {
            private readonly DB.ApplicationDbContext _context;

            public BranchesController(DB.ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: Branches
            public async Task<IActionResult> Index()
            {
                return View(await _context.CompanyBranches.ToListAsync());
            }

            // GET: Branches/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var companyBranch = await _context.CompanyBranches
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (companyBranch == null)
                {
                    return NotFound();
                }

                return View(companyBranch);
            }

            // GET: Branches/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Branches/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,CompanyId,Name,CityId,CountryId,Address,Phone,AddedBy,AddedDate,UpdatedBy,UpdatedDate")] BranchesModel companyBranch)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(companyBranch);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(companyBranch);
            }

            // GET: Branches/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var companyBranch = await _context.CompanyBranches.FindAsync(id);
                if (companyBranch == null)
                {
                    return NotFound();
                }
                return View(companyBranch);
            }

            // POST: Branches/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,Name,CityId,CountryId,Address,Phone,AddedBy,AddedDate,UpdatedBy,UpdatedDate")] BranchesModel companyBranch)
            {
                if (id != companyBranch.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(companyBranch);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CompanyBranchExists(companyBranch.Id))
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
                return View(companyBranch);
            }

            // GET: Branches/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var companyBranch = await _context.CompanyBranches
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (companyBranch == null)
                {
                    return NotFound();
                }

                return View(companyBranch);
            }

            // POST: Branches/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var companyBranch = await _context.CompanyBranches.FindAsync(id);
                _context.CompanyBranches.Remove(companyBranch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool CompanyBranchExists(int id)
            {
                return _context.CompanyBranches.Any(e => e.Id == id);
            }
        }
    }

