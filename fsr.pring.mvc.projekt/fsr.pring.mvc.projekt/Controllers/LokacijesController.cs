using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fsr.pring.mvc.projekt.Models;
using fsr.pring.mvc.projekt.ViewModels;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace fsr.pring.mvc.projekt.Controllers
{
    public class LokacijesController : Controller
    {
        private readonly DataContext _context;
        private readonly AppSettings appData;

        public LokacijesController(DataContext context, IOptionsSnapshot<AppSettings> option)
        {
            _context = context;
            appData = option.Value;
        }

        // GET: Lokacijes
        public async Task<IActionResult> Index(int page = 1, int sort = 1, bool ascending = true)
        {
            int pagesize = appData.PageSize;

            var query = _context.Lokacije
                .Include(p => p.LokacijaTip)
                .Include(p => p.Partner)
                .AsNoTracking();

            int count = query.Count();

            Expression<Func<Lokacije, object>> orderSelector = null;
            switch (sort)
            {
                case 1:
                    orderSelector = d => d.Id;
                    break;
                case 2:
                    orderSelector = d => d.LokacijaTip.Naziv;
                    break;
                case 3:
                    orderSelector = d => d.Partner.Naziv;

                    break;
            }

            if (orderSelector != null)
            {
                query = ascending ? query.OrderBy(orderSelector) : query.OrderByDescending(orderSelector);
            }
            var viewModel = new LokacijeViewModel();

            viewModel.Lokacijes = await query.ToListAsync();

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                Sort = sort,
                Ascending = ascending,
                ItemsPerPage = pagesize,
                TotalItems = count
            };

            viewModel.PagingInfo = pagingInfo;


            return View(viewModel);
        }

        // GET: Lokacijes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacije = await _context.Lokacije
                .Include(l => l.LokacijaTip)
                .Include(l => l.Partner)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lokacije == null)
            {
                return NotFound();
            }

            return View(lokacije);
        }

        // GET: Lokacijes/Create
        public IActionResult Create()
        {
            ViewData["LokacijaTipId"] = new SelectList(_context.LokacijaTip, "Id", "Id");
            ViewData["PartnerId"] = new SelectList(_context.Partner, "Id", "Id");
            return View();
        }

        // POST: Lokacijes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LokacijaTipId,PartnerId,Koordinate, GPS, LokacijaKategorijaId")] Lokacije lokacije)
        {
            if (lokacije.LokacijaKategorija== null)
                ModelState.AddModelError("Koordinate", "niste unijeli koordinate!!!");

            if (ModelState.IsValid)
            {
                _context.Add(lokacije);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LokacijaTipId"] = new SelectList(_context.LokacijaTip, "Id", "Id", lokacije.LokacijaTipId);
            ViewData["PartnerId"] = new SelectList(_context.Partner, "Id", "Id", lokacije.PartnerId);
            return View(lokacije);
        }

        // GET: Lokacijes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacije = await _context.Lokacije.SingleOrDefaultAsync(m => m.Id == id);
            if (lokacije == null)
            {
                return NotFound();
            }
            ViewData["LokacijaTipId"] = new SelectList(_context.LokacijaTip, "Id", "Id", lokacije.LokacijaTipId);
            ViewData["PartnerId"] = new SelectList(_context.Partner, "Id", "Id", lokacije.PartnerId);
            return View(lokacije);
        }

        // POST: Lokacijes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LokacijaTipId,PartnerId,Koordinate, GPS, LokacijaKategorijaId")] Lokacije lokacije)
        {
            if (id != lokacije.Id)
            {
                return NotFound();
            }

            if (lokacije.LokacijaKategorija == null)
                ModelState.AddModelError("Koordinate", "niste unijeli koordinate!!!");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokacije);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokacijeExists(lokacije.Id))
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
            ViewData["LokacijaTipId"] = new SelectList(_context.LokacijaTip, "Id", "Id", lokacije.LokacijaTipId);
            ViewData["PartnerId"] = new SelectList(_context.Partner, "Id", "Id", lokacije.PartnerId);
            return View(lokacije);
        }

        // GET: Lokacijes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacije = await _context.Lokacije
                .Include(l => l.LokacijaTip)
                .Include(l => l.Partner)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lokacije == null)
            {
                return NotFound();
            }

            return View(lokacije);
        }

        // POST: Lokacijes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lokacije = await _context.Lokacije.SingleOrDefaultAsync(m => m.Id == id);
            _context.Lokacije.Remove(lokacije);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokacijeExists(int id)
        {
            return _context.Lokacije.Any(e => e.Id == id);
        }
    }
}
