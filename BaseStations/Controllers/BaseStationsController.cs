using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaseStations.Context;
using BaseStations.Models;

namespace BaseStations.Controllers
{
    public class BaseStationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseStationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BaseStations
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseStations.ToListAsync());
        }

        public async Task<IActionResult> Search(string searchString)
        {
            var baseStations = from bs in _context.BaseStations
                               select bs;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();

                baseStations = baseStations.Where(bs => bs.Number.ToLower().Contains(searchString)
                                                    || bs.Operator.ToLower().Contains(searchString)
                                                    || bs.Address.ToLower().Contains(searchString)
                                                    || bs.Frequency.ToLower().Contains(searchString)
                                                    || bs.Coordinates.ToLower().Contains(searchString));
            }

            return View("Index", await baseStations.ToListAsync());
        }


        // GET: BaseStations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseStation = await _context.BaseStations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseStation == null)
            {
                return NotFound();
            }

            return View(baseStation);
        }

        // GET: BaseStations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseStations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Frequency,Coordinates,Address,Operator")] BaseStation baseStation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseStation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseStation);
        }

        // GET: BaseStations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseStation = await _context.BaseStations.FindAsync(id);
            if (baseStation == null)
            {
                return NotFound();
            }
            return View(baseStation);
        }

        // POST: BaseStations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Frequency,Coordinates,Address,Operator")] BaseStation baseStation)
        {
            if (id != baseStation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseStation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseStationExists(baseStation.Id))
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
            return View(baseStation);
        }

        // GET: BaseStations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseStation = await _context.BaseStations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseStation == null)
            {
                return NotFound();
            }

            return View(baseStation);
        }

        // POST: BaseStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseStation = await _context.BaseStations.FindAsync(id);
            if (baseStation != null)
            {
                _context.BaseStations.Remove(baseStation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Calculator()
        {
            return View();
        }


        private bool BaseStationExists(int id)
        {
            return _context.BaseStations.Any(e => e.Id == id);
        }
    }
}
