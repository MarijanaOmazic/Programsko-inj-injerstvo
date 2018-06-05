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
    public class PartnersController : Controller
    {
        private readonly DataContext _context;
        private readonly AppSettings appData;

        public PartnersController(DataContext context, IOptionsSnapshot<AppSettings> options)
        {
            _context = context;
            appData = options.Value;
        }

        // GET: Partners
        public async Task<IActionResult> Index(int page = 1, int sort = 1, bool ascending = true)
        {
            int pagesize = appData.PageSize;


            var query = _context.Partner.Include(p => p.PartnerTipovi).AsNoTracking();

            int count = query.Count();
            
            Expression<Func<Partner, object>> orderSelector = null;
            switch (sort)
            {
                case 1:
                    orderSelector = d => d.Id;
                    break;
                case 2:
                    orderSelector = d => d.Naziv;
                    break;
                case 3:
                    orderSelector = d => d.Adresa;
                    break;
                case 4:
                    orderSelector = d => d.PartnerTipovi.Naziv;
                    break;
            }
            if (orderSelector != null)
            {
                query = ascending ? query.OrderBy(orderSelector) : query.OrderByDescending(orderSelector);

                //if (ascending)
                //    query.OrderBy(orderSelector);
                //else
                //    query.OrderByDescending(orderSelector);
            }


            var viewModel = new PartneriViewModel();

            viewModel.Partneri = await query.ToListAsync();

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

        // GET: Partners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partner
                .Include(p => p.PartnerTipovi)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // GET: Partners/Create
        public IActionResult Create()
        {
            ViewData["PartnerTipoviId"] = new SelectList(_context.TipPartera, "Id", "Id");
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PartnerTipoviId,Naziv,Adresa")] Partner partner)
        {
            if (partner.Naziv == null)
                ModelState.AddModelError("Naziv", "niste unijeli naziv!!!");
            if (partner.Adresa == null)
                ModelState.AddModelError("Adresa", "niste unijeli adresu!!!");

            if (ModelState.IsValid)
            {
                _context.Add(partner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartnerTipoviId"] = new SelectList(_context.TipPartera, "Id", "Id", partner.PartnerTipoviId);
            return View(partner);
        }

        // GET: Partners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partner.SingleOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }
            ViewData["PartnerTipoviId"] = new SelectList(_context.TipPartera, "Id", "Id", partner.PartnerTipoviId);
            return View(partner);
        }

        // POST: Partners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PartnerTipoviId,Naziv,Adresa")] Partner partner)
        {
            if (id != partner.Id)
            {
                return NotFound();
            }

            if (partner.Naziv == null)
                ModelState.AddModelError("Naziv", "niste unijeli naziv!!!");
            if (partner.Adresa == null)
                ModelState.AddModelError("Adresa", "niste unijeli adresu!!!");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerExists(partner.Id))
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
            ViewData["PartnerTipoviId"] = new SelectList(_context.TipPartera, "Id", "Id", partner.PartnerTipoviId);
            return View(partner);
        }

        // GET: Partners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partner
                .Include(p => p.PartnerTipovi)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partner = await _context.Partner.SingleOrDefaultAsync(m => m.Id == id);
            _context.Partner.Remove(partner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(int id)
        {
            return _context.Partner.Any(e => e.Id == id);
        }
    }
}
