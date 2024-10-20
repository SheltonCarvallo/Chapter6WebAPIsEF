using Invoice.Domain.Models;
using InvoicePeople.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InvoicePeople.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        readonly IInvoice _invoice;

        public InvoiceController(IInvoice invoice)
        {
            _invoice = invoice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceModel>>> GetInvoices(InvoiceStatusModel? status, int page = 1, int pageSize = 10)
        {
            try
            {
               IEnumerable<InvoiceModel> invoices = await _invoice.GetInvoices(status, page, pageSize);

                return Ok(invoices);
            }
            catch (Exception)
            {

                throw;
            } 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceModel>> GetInvoice( Guid id)
        {
            //ActionResult<InvoiceModel> invoice2 = new InvoiceModel();
            try
            {
                /*ActionResult<InvoiceModel> invoice = await _invoice.GetInvoice(id);


                if( invoice.Value!.id == Guid.Empty)
                {
                    return NotFound();
                }
                return invoice;*/

                InvoiceModel invoice = await _invoice.GetInvoice(id);

                if (invoice.id == Guid.Empty)
                {
                    return NotFound();
                }
                return Ok(invoice);

            }
            catch (Exception)
            {

                throw;
            }
             
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceModel>>  PutInvoice([FromBody] InvoiceModel invoice)
        {
            try
            {
                await _invoice.PostInvoice(invoice);
                return CreatedAtAction("GetInvoice", new { id = invoice.id }, invoice);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutInvoice(Guid id, [FromBody] InvoiceModel invoice)
        {
            try
            {
                if (invoice.id != id)
                {
                    return BadRequest();
                }
                await _invoice.PutInvoice(id, invoice);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            try
            {
               bool wasDeleted =  await _invoice.DeleteInvoice(id);
                
               
                return (wasDeleted ? NoContent() : BadRequest());
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
