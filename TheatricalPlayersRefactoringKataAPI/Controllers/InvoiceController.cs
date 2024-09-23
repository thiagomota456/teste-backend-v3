using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKataAPI.Model;
using TheatricalPlayersRefactoringKataAPI.Services;

namespace TheatricalPlayersRefactoringKataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IEntityServices<Invoice> _invoiceService;
        private readonly IEntityServices<Performance> _performanceService;

        public InvoiceController(IEntityServices<Invoice> invoiceService, IEntityServices<Performance> performanceService)
        {
            _invoiceService = invoiceService;
            _performanceService = performanceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return await _invoiceService.GetAllAsync();
        }

        [HttpPost("savedPerformance")]
        public async Task<ActionResult<Invoice>> CreateInvoiceWithSavedPerformance(SavedPerformance invoiceList)
        {
            var performances = await _performanceService.GetAllAsync();
            var matchedPerformances = performances.Where(p => invoiceList.performanceIds.Contains(p.Id)).ToList();

            if (matchedPerformances.Count != invoiceList.performanceIds.Length)
            {
                return BadRequest("Um ou mais IDs de Performance não foram encontrados.");
            }

            var invoice = new Invoice
            {
                Customer = invoiceList.customer,
                Performances = matchedPerformances
            };

            await _invoiceService.CreateAsync(invoice);

            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _invoiceService.GetByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        
        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice)
        {
            await _invoiceService.CreateAsync(invoice);
            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _invoiceService.GetByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            await _invoiceService.DeleteAsync(invoice);
            return NoContent();
        }
    }
}
