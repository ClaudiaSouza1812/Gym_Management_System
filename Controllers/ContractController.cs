using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Controllers
{
    public class ContractController : Controller
    {
        private readonly CA_RS11_P2_2_ClaudiaSouza_DBContext _context;
        private readonly IContractService _contractService;

        public ContractController(CA_RS11_P2_2_ClaudiaSouza_DBContext context, IContractService contractService)
        {
            _context = context;
            _contractService = contractService;
        }

        // GET: Contract
        public async Task<IActionResult> Index()
        {
            var cA_RS11_P2_2_ClaudiaSouza_DBContext = _context.Contract.Include(c => c.Client).Include(c => c.Membership);
            return View(await cA_RS11_P2_2_ClaudiaSouza_DBContext.ToListAsync());
        }

        // GET: Contract/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contract == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .Include(c => c.Client)
                .Include(c => c.Membership)
                .FirstOrDefaultAsync(m => m.ContractId == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contract/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "FullName");
            ViewData["MembershipId"] = new SelectList(_context.Membership, "MembershipId", "MembershipType");
            return View();
        }

        // POST: Contract/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractId,ClientId,MembershipId,StartDate,EndDate")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                if (await _contractService.CheckExistingContract(contract.ClientId))
                {
                    if (await _contractService.CheckContractValidity(contract.ClientId, contract.StartDate))
                    {
                        ModelState.AddModelError("ClientId", "There is a contract still in force with this customer ID");

                        ViewData["ClientId"] = new SelectList(_context.Client, "Id", "FullName", contract.ClientId);
                        ViewData["MembershipId"] = new SelectList(_context.Membership, "MembershipId", "MembershipType", contract.MembershipId);
                        return View(contract);
                    }
                }

                await _contractService.CreateContract(contract);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "FullName", contract.ClientId);
            ViewData["MembershipId"] = new SelectList(_context.Membership, "MembershipId", "MembershipType", contract.MembershipId);

            return View(contract);
        }

        // GET: Contract/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contract == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Email", contract.ClientId);
            ViewData["MembershipId"] = new SelectList(_context.Membership, "MembershipId", "MembershipId", contract.MembershipId);
            return View(contract);
        }

        // POST: Contract/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractId,ClientId,MembershipId,StartDate,EndDate")] Contract contract)
        {
            if (id != contract.ContractId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.ContractId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Email", contract.ClientId);
            ViewData["MembershipId"] = new SelectList(_context.Membership, "MembershipId", "MembershipId", contract.MembershipId);
            return View(contract);
        }

        // GET: Contract/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contract == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .Include(c => c.Client)
                .Include(c => c.Membership)
                .FirstOrDefaultAsync(m => m.ContractId == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contract == null)
            {
                return Problem("Entity set 'CA_RS11_P2_2_ClaudiaSouza_DBContext.Contract'  is null.");
            }
            var contract = await _context.Contract.FindAsync(id);
            if (contract != null)
            {
                _context.Contract.Remove(contract);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
          return (_context.Contract?.Any(e => e.ContractId == id)).GetValueOrDefault();
        }
    }
}
