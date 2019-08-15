using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LLPApp.Data;
using LLPApp.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;

namespace LLPApp.Controllers
{
    public class DeviceModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;


        // MAPPING
        private readonly IMapper _mapper;

        // then use use _mapper.Map or _mapper.ProjectTo



        public DeviceModelsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment, IMapper mapper)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;

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
        public async Task<IActionResult> Create([Bind("Type,Brand,ModelName,ModelNum,Image")] DeviceModelCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (vm.Image != null)
                {
                    // create path string
                    string path = Path.Combine(_hostingEnvironment.WebRootPath, "img\\devicemodel");
                    // create file name from GUID and existing file name
                    fileName = Guid.NewGuid().ToString() + "_" + vm.Image.FileName;
                    // concatenate
                    string pathFileName = Path.Combine(path, fileName);
                    // copy IFormFile image from view model to location on server
                    vm.Image.CopyTo(new FileStream(pathFileName, FileMode.Create));
                } else
                {
                    // no image selected, use default noimage.jpg
                    fileName = "noimage.jpg";
                }

                _context.Add(_mapper.Map(vm, new DeviceModel { ImagePath = fileName },typeof(DeviceModelCreateViewModel), typeof(DeviceModel)));

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: DeviceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // check if id itself is null
            if (id == null)
            {
                return NotFound();
            }

            // check if the id's related DeviceModel is null
            var dm = await _context.DeviceModels.FindAsync(id);
            if (dm == null)
            {
                return NotFound();
            }


            // TODO any way to concatonate /img/devicemodel/ here???
            DeviceModelEditViewModel vm = _mapper.Map<DeviceModelEditViewModel>(dm);

            return View(vm);
        }

        // POST: DeviceModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Brand,ModelName,ModelNum,Image,ImagePath")] DeviceModelEditViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                DeviceModel dm = _mapper.Map<DeviceModel>(vm);

                string fileName = null;
                if (vm.Image != null)
                {
                    string uploadFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "img\\devicemodel");
                    fileName = Guid.NewGuid().ToString() + "_" + vm.Image.FileName;
                    string completeFilePath = Path.Combine(uploadFolderPath, fileName);
                    vm.Image.CopyTo(new FileStream(completeFilePath, FileMode.Create));

                    // add final property to new DeviceModel
                    dm.ImagePath = fileName;
                }
                // othewise no image is uploaded, existing filename was passed on during mapping (required hidden input in view)
                try
                {   
                    _context.Update(dm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceModelExists(dm.Id))
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
            return View();
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
