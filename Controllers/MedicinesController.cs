using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppMedicineTracker.Models;

namespace AppMedicineTracker.Controllers
{
    [Authorize]
    public class MedicinesController : Controller
    {
        private readonly AppMedicineTrackerContext _context;

        public MedicinesController(AppMedicineTrackerContext context)
        {
            _context = context;
        }

        // GET: Medicines
        
        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            var medicines = await _context.Medicine.Where(m => m.User == username).ToListAsync();
            return View(medicines);
        }

        public async Task<IActionResult> DaySchedule()
        {
            var username = User.Identity.Name;
            var medicines = await _context.Medicine.Where(m => m.User == username).ToListAsync();
            return View(medicines);
        }

        // GET: Medicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            var username = User.Identity.Name;
            var medicine = await _context.Medicine.FirstOrDefaultAsync(m => m.Id == id && m.User == username);
            if (medicine == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(medicine);
        }

        // GET: Medicines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Dose,Form,Condition,PrescribedBy,Frequency,StartDate,DaysOn,DaysOff,Notes,ImagePath,User,Supply,Refills,Instructions,Suspend")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            var username = User.Identity.Name;
            var medicine = await _context.Medicine.FirstOrDefaultAsync(m => m.Id == id && m.User == username);
            if (medicine == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Dose,Form,Condition,PrescribedBy,Frequency,StartDate,DaysOn,DaysOff,Notes,ImagePath,User,Supply,Refills,Instructions,Suspend")] Medicine medicine)
        {
            if (id != medicine.Id)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineExists(medicine.Id))
                    {
                        Response.StatusCode = 404;
                        return View("NotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            var username = User.Identity.Name;
            var medicine = await _context.Medicine.FirstOrDefaultAsync(m => m.Id == id && m.User == username);
            if (medicine == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicine = await _context.Medicine.FindAsync(id);
            _context.Medicine.Remove(medicine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineExists(int id)
        {
            return _context.Medicine.Any(e => e.Id == id);
        }
    }
}
