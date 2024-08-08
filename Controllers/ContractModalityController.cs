using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Controllers
{
    public class ContractModalityController : Controller
    {
        private readonly CA_RS11_P2_2_ClaudiaSouza_DBContext _context;

        public ContractModalityController(CA_RS11_P2_2_ClaudiaSouza_DBContext context)
        {
            _context = context;
        }

        // GET: ContractModality
        public async Task<IActionResult> Index()
        {
            var cA_RS11_P2_2_ClaudiaSouza_DBContext = _context.ContractModality.Include(c => c.Contract).Include(c => c.Modality);
            return View(await cA_RS11_P2_2_ClaudiaSouza_DBContext.ToListAsync());
        }

        // GET: ContractModality/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContractModality == null)
            {
                return NotFound();
            }

            var contractModality = await _context.ContractModality
                .Include(c => c.Contract)
                .Include(c => c.Modality)
                .FirstOrDefaultAsync(m => m.ContractId == id);
            if (contractModality == null)
            {
                return NotFound();
            }

            return View(contractModality);
        }

        // GET: ContractModality/Create
        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contract, "ContractId", "ContractId");
            ViewData["ModalityId"] = new SelectList(_context.Modality, "ModalityId", "ModalityId");
            return View();
        }

        // POST: ContractModality/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractId,ModalityId")] ContractModality contractModality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractModality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractId"] = new SelectList(_context.Contract, "ContractId", "ContractId", contractModality.ContractId);
            ViewData["ModalityId"] = new SelectList(_context.Modality, "ModalityId", "ModalityId", contractModality.ModalityId);
            return View(contractModality);
        }

        // GET: ContractModality/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContractModality == null)
            {
                return NotFound();
            }

            var contractModality = await _context.ContractModality.FindAsync(id);
            if (contractModality == null)
            {
                return NotFound();
            }
            ViewData["ContractId"] = new SelectList(_context.Contract, "ContractId", "ContractId", contractModality.ContractId);
            ViewData["ModalityId"] = new SelectList(_context.Modality, "ModalityId", "ModalityId", contractModality.ModalityId);
            return View(contractModality);
        }

        // POST: ContractModality/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractId,ModalityId")] ContractModality contractModality)
        {
            if (id != contractModality.ContractId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractModality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractModalityExists(contractModality.ContractId))
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
            ViewData["ContractId"] = new SelectList(_context.Contract, "ContractId", "ContractId", contractModality.ContractId);
            ViewData["ModalityId"] = new SelectList(_context.Modality, "ModalityId", "ModalityId", contractModality.ModalityId);
            return View(contractModality);
        }

        // GET: ContractModality/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContractModality == null)
            {
                return NotFound();
            }

            var contractModality = await _context.ContractModality
                .Include(c => c.Contract)
                .Include(c => c.Modality)
                .FirstOrDefaultAsync(m => m.ContractId == id);
            if (contractModality == null)
            {
                return NotFound();
            }

            return View(contractModality);
        }

        // POST: ContractModality/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContractModality == null)
            {
                return Problem("Entity set 'CA_RS11_P2_2_ClaudiaSouza_DBContext.ContractModality'  is null.");
            }
            var contractModality = await _context.ContractModality.FindAsync(id);
            if (contractModality != null)
            {
                _context.ContractModality.Remove(contractModality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractModalityExists(int id)
        {
          return (_context.ContractModality?.Any(e => e.ContractId == id)).GetValueOrDefault();
        }
    }
}
