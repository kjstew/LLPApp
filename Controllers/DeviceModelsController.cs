using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LLPApp.Data;
using LLPApp.Models;

namespace LLPApp.Controllers
{
    public class DeviceModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeviceModels.ToListAsync());
        }

        // GET: DeviceModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DeviceModel = await _context.DeviceModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (DeviceModel == null)
            {
                return NotFound();
            }

            return View(DeviceModel);
        }

        // GET: DeviceModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeviceModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Brand,ModelName,ModelNum")] DeviceModel DeviceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(DeviceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(DeviceModel);
        }

        // GET: DeviceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DeviceModel = await _context.DeviceModels.FindAsync(id);
            if (DeviceModel == null)
            {
                return NotFound();
            }
            return View(DeviceModel);
        }

        // POST: DeviceModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Brand,ModelName,ModelNum")] DeviceModel DeviceModel)
        {
            if (id != DeviceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(DeviceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceModelExists(DeviceModel.Id))
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
            return View(DeviceModel);
        }

        // GET: DeviceModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DeviceModel = await _context.DeviceModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (DeviceModel == null)
            {
                return NotFound();
            }

            return View(DeviceModel);
        }

        // POST: DeviceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var DeviceModel = await _context.DeviceModels.FindAsync(id);
            _context.DeviceModels.Remove(DeviceModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceModelExists(int id)
        {
            return _context.DeviceModels.Any(e => e.Id == id);
        }
    }
}
