using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Controllers
{
    public class ModalityController : Controller
    {
        private readonly CA_RS11_P2_2_ClaudiaSouza_DBContext _context;

        public ModalityController(CA_RS11_P2_2_ClaudiaSouza_DBContext context)
        {
            _context = context;
        }

        // GET: Modality
        public async Task<IActionResult> Index()
        {
              return _context.Modality != null ? 
                          View(await _context.Modality.ToListAsync()) :
                          Problem("Entity set 'CA_RS11_P2_2_ClaudiaSouza_DBContext.Modality'  is null.");
        }

        // GET: Modality/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modality == null)
            {
                return NotFound();
            }

            var modality = await _context.Modality
                .FirstOrDefaultAsync(m => m.ModalityId == id);
            if (modality == null)
            {
                return NotFound();
            }

            return View(modality);
        }

        // GET: Modality/Create
        public IActionResult Create()
        {
            var model = new Modality
            {
                ModalityPackage = EnumModalityPackage.OneModality // Set a default value
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SelectPackage(EnumModalityPackage modalityPackage)
        {
            return View("Create", new Modality { ModalityPackage = modalityPackage });
        }

        // POST: Modality/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModalityId,ModalityName,ModalityPackage,SecondModalityName")] Modality modality)
        {
            if (!ModelState.IsValid)
            {
                // Log or display ModelState errors
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        // You can log this error or add it to a list to display
                        Console.WriteLine(error.ErrorMessage);
                        // or if you're using a logger:
                        // _logger.LogError(error.ErrorMessage);
                    }
                }
            }
            if (ModelState.IsValid)
            {
                switch (modality.ModalityPackage)
                {
                    case EnumModalityPackage.OneModality:
                    case EnumModalityPackage.AllInclusive:
                        // Store the single modality name as a string
                        modality.ModalityName = ((EnumModalityName)Enum.Parse(typeof(EnumModalityName), modality.ModalityName)).ToString();
                        break;
                    case EnumModalityPackage.TwoModalities:
                        if (string.IsNullOrEmpty(modality.SecondModalityName))
                        {
                            ModelState.AddModelError("SecondModalityName", "Second Modality Name is required for Two Modalities package.");
                            return View(modality);
                        }
                        // Combine both modality names as strings
                        modality.ModalityName = $"{((EnumModalityName)Enum.Parse(typeof(EnumModalityName), modality.ModalityName))},{((EnumModalityName)Enum.Parse(typeof(EnumModalityName), modality.SecondModalityName))}";
                        break;
                }

                _context.Add(modality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modality);
        }

        // GET: Modality/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modality = await _context.Modality.FindAsync(id);
            if (modality == null)
            {
                return NotFound();
            }

            if (modality.ModalityPackage == EnumModalityPackage.TwoModalities)
            {
                var modalities = modality.ModalityName.Split(',');
                modality.ModalityName = modalities[0];
                modality.SecondModalityName = modalities.Length > 1 ? modalities[1] : "";
            }

            ViewData["ModalityNames"] = new SelectList(Enum.GetValues(typeof(EnumModalityName)).Cast<EnumModalityName>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = v.ToString()
            }), "Value", "Text");

            return View(modality);
        }

        // POST: Modality/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModalityId,ModalityName,ModalityPackage,SecondModalityName")] Modality modality)
        {
            if (id != modality.ModalityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (modality.ModalityPackage == EnumModalityPackage.TwoModalities)
                    {
                        if (string.IsNullOrEmpty(modality.SecondModalityName))
                        {
                            ModelState.AddModelError("SecondModalityName", "Second Modality Name is required for Two Modalities package.");
                            ViewData["ModalityNames"] = new SelectList(Enum.GetValues(typeof(EnumModalityName)).Cast<EnumModalityName>().Select(v => new SelectListItem
                            {
                                Text = v.ToString(),
                                Value = v.ToString()
                            }), "Value", "Text");
                            return View(modality);
                        }
                        modality.ModalityName = $"{modality.ModalityName},{modality.SecondModalityName}";
                    }

                    _context.Update(modality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalityExists(modality.ModalityId))
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
            ViewData["ModalityNames"] = new SelectList(Enum.GetValues(typeof(EnumModalityName)).Cast<EnumModalityName>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = v.ToString()
            }), "Value", "Text");
            return View(modality);
        }

        // GET: Modality/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modality == null)
            {
                return NotFound();
            }

            var modality = await _context.Modality
                .FirstOrDefaultAsync(m => m.ModalityId == id);
            if (modality == null)
            {
                return NotFound();
            }

            return View(modality);
        }

        // POST: Modality/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modality == null)
            {
                return Problem("Entity set 'CA_RS11_P2_2_ClaudiaSouza_DBContext.Modality'  is null.");
            }
            var modality = await _context.Modality.FindAsync(id);
            if (modality != null)
            {
                _context.Modality.Remove(modality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModalityExists(int id)
        {
          return (_context.Modality?.Any(e => e.ModalityId == id)).GetValueOrDefault();
        }
    }
}
