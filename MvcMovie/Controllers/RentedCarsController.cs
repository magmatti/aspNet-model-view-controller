using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class RentedCarsController : Controller
    {
        private readonly MvcMovieContext _context;

        public RentedCarsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: RentedCars
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.RentedCar.Include(r => r.Client).Include(r => r.car);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: RentedCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedCar = await _context.RentedCar
                .Include(r => r.Client)
                .Include(r => r.car)
                .FirstOrDefaultAsync(m => m.RentID == id);
            if (rentedCar == null)
            {
                return NotFound();
            }

            return View(rentedCar);
        }

        // GET: RentedCars/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Email");
            ViewData["CarID"] = new SelectList(_context.Car, "CarID", "CarID");
            return View();
        }

        // POST: RentedCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentID,ClientID,CarID,RentDate,ReturnDate,Cost")] RentedCar rentedCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentedCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Email", rentedCar.ClientID);
            ViewData["CarID"] = new SelectList(_context.Car, "CarID", "CarID", rentedCar.CarID);
            return View(rentedCar);
        }

        // GET: RentedCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedCar = await _context.RentedCar.FindAsync(id);
            if (rentedCar == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Email", rentedCar.ClientID);
            ViewData["CarID"] = new SelectList(_context.Car, "CarID", "CarID", rentedCar.CarID);
            return View(rentedCar);
        }

        // POST: RentedCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentID,ClientID,CarID,RentDate,ReturnDate,Cost")] RentedCar rentedCar)
        {
            if (id != rentedCar.RentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentedCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentedCarExists(rentedCar.RentID))
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
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Email", rentedCar.ClientID);
            ViewData["CarID"] = new SelectList(_context.Car, "CarID", "CarID", rentedCar.CarID);
            return View(rentedCar);
        }

        // GET: RentedCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedCar = await _context.RentedCar
                .Include(r => r.Client)
                .Include(r => r.car)
                .FirstOrDefaultAsync(m => m.RentID == id);
            if (rentedCar == null)
            {
                return NotFound();
            }

            return View(rentedCar);
        }

        // POST: RentedCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentedCar = await _context.RentedCar.FindAsync(id);
            if (rentedCar != null)
            {
                _context.RentedCar.Remove(rentedCar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentedCarExists(int id)
        {
            return _context.RentedCar.Any(e => e.RentID == id);
        }
    }
}
