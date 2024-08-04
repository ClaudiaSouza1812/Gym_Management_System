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
    public class ClientController : Controller
    {
        private readonly CA_RS11_P2_2_ClaudiaSouza_DBContext _context;

        public ClientController(CA_RS11_P2_2_ClaudiaSouza_DBContext context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
              return _context.Client != null ? 
                          View(await _context.Client.ToListAsync()) :
                          Problem("Entity set 'CA_RS11_P2_2_ClaudiaSouza_DBContext.Client'  is null.");
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            var viewModel = new CreateClientViewModel
            {
                MembershipOptions = _context.Membership.ToList(),
                ModalityOptions = _context.Modality.ToList()
            };
            return View(viewModel);
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newClient = new Client
                {
                    FirstName = viewModel.Client.FirstName,
                    LastName = viewModel.Client.LastName,
                    NIF = viewModel.Client.NIF,
                    BirthDate = viewModel.Client.BirthDate,
                    Email = viewModel.Client.Email,
                    PhoneNumber = viewModel.Client.PhoneNumber,
                    Address = viewModel.Client.Address,
                    PostalCode = viewModel.Client.PostalCode,
                    City = viewModel.Client.City,
                    Country = viewModel.Client.Country,
                    Status = viewModel.Client.Status,
                    PaymentType = viewModel.Client.PaymentType,
                    Loyal = viewModel.Client.Loyal
                };
                _context.Client.Add(newClient);
                await _context.SaveChangesAsync();

                foreach (var contractViewModel in viewModel.Contract)
                {
                    var newMembership = new Membership
                    {
                        Discount = contractViewModel.Membership.Discount,
                        StartDate = contractViewModel.Membership.StartDate,
                    };
                    _context.Add(newMembership);

                    var newContract = new Contract
                    {
                        ClientId = newClient.Id,
                        MembershipId = newMembership.MembershipId,
                        ContractDate = contractViewModel.ContractDate
                    };
                    _context.Add(newContract);

                    foreach (var paymentViewModel in viewModel.Payment)
                    {
                        var newPayment = new Payment
                        {
                            ContractId = newContract.ContractId,
                            PaymentDate = paymentViewModel.PaymentDate,
                        };
                        _context.Add(newPayment);
                    }
                }

                foreach (var modalityViewModel in viewModel.ModalityOptions)
                {
                    var newModality = new Modality
                    {
                        ModalityName = modalityViewModel.ModalityName,
                        ModalityPackage = modalityViewModel.ModalityPackage,
                    };
                    _context.Add(newModality);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View(viewModel);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Status,PaymentType,Loyal,Id,FirstName,LastName,NIF,BirthDate,Email,PhoneNumber,Address,PostalCode,City,Country,CreatedAt,UpdatedAt")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Client == null)
            {
                return Problem("Entity set 'CA_RS11_P2_2_ClaudiaSouza_DBContext.Client'  is null.");
            }
            var client = await _context.Client.FindAsync(id);
            if (client != null)
            {
                _context.Client.Remove(client);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
          return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
