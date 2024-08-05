using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
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
                Client = new Client(),
                Membership = new Membership(),
                ContractDate = DateTime.Now,
                PaymentDate = DateTime.Now,
                PaymentBaseValue = 0,
                PaymentBaseRate = 0,
                Modality = new Modality()
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
            Console.WriteLine("Received Data:");
            Console.WriteLine(JsonSerializer.Serialize(viewModel, new JsonSerializerOptions { WriteIndented = true }));

            // Log ModelState details
            Console.WriteLine("ModelState Details:");
            foreach (var key in ModelState.Keys)
            {
                var modelStateEntry = ModelState[key];
                Console.WriteLine($"Key: {key}");
                Console.WriteLine($"  Is Valid: {modelStateEntry.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid}");
                Console.WriteLine($"  Raw Value: {modelStateEntry.RawValue}");
                foreach (var error in modelStateEntry.Errors)
                {
                    Console.WriteLine($"  Error: {error.ErrorMessage}");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingClient = await _context.Client.FirstOrDefaultAsync(c => c.NIF == viewModel.Client.NIF);
                    if (existingClient != null)
                    {
                        ModelState.AddModelError("Client.NIF", "A client with this NIF already exists.");
                        return View(viewModel);
                    }

                    _context.Client.Add(viewModel.Client);
                    await _context.SaveChangesAsync();

                    _context.Membership.Add(viewModel.Membership);
                    await _context.SaveChangesAsync();

                    var newContract = new Contract
                    {
                        ClientId = viewModel.Client.Id,
                        MembershipId = viewModel.Membership.MembershipId,
                        ContractDate = viewModel.ContractDate
                    };
                    _context.Contract.Add(newContract);
                    await _context.SaveChangesAsync();

                    var newPayment = new Payment(
                    
                        viewModel.PaymentBaseValue,
                        viewModel.PaymentBaseRate,
                        viewModel.PaymentDate)
                    {
                        ContractId = newContract.ContractId
                    };
                    _context.Payment.Add(newPayment);
                    await _context.SaveChangesAsync();

                    var newModality = new Modality
                    {
                        ModalityName = viewModel.Modality.ModalityName,
                        ModalityPackage = viewModel.Modality.ModalityPackage
                    };
                    _context.Modality.Add(newModality);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Debug.WriteLine($"An error occurred: {ex.Message}");
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            else
            {
                Console.WriteLine("ModelState is invalid");
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
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
