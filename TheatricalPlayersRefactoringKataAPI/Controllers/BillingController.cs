using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TheatricalPlayersRefactoringKata.Presentation;
using TheatricalPlayersRefactoringKataAPI.Data;
using TheatricalPlayersRefactoringKataAPI.Model;

namespace TheatricalPlayersRefactoringKataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BillingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("calculate")]
        public async Task<ActionResult<string>> CalculateInvoice(CalculateInput input)
        {
            var distinctPlayIds = input.Plays.Distinct().ToArray();

            // Obtém a fatura a partir do banco de dados.
            var invoice = await _context.Invoices
                .Include(i => i.Performances)
                .FirstOrDefaultAsync(i => i.Id == input.InvoceToCalculate);

            if (invoice == null)
            {
                return NotFound("Invoice not found.");
            }

            // Obtém as peças (Plays) baseadas nos IDs fornecidos.
            var plays = await _context.Plays
                .Where(p => distinctPlayIds.Contains(p.Id))
                .ToDictionaryAsync(p => p.Id, p => p);

            if (plays.Count != distinctPlayIds.Length)
            {
                return BadRequest("One or more Plays were not found.");
            }

            // Cria uma instância de StatementPrinter com as informações necessárias.
            var statementPrinter = new StatementPrinter(invoice, plays, new CultureInfo(input.CultureInfo));

            // Usa o StatementPrinter para calcular e formatar a saída com base no PrintType.
            var result = statementPrinter.Print(input.PrintType);

            // Retorna a string formatada no tipo desejado (TXT, JSON, ou XML).
            return Ok(result);
        }
    }
}
