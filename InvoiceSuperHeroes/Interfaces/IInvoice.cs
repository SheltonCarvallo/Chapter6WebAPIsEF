using Invoice.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoicePeople.Interfaces
{
    public interface IInvoice
    {
        //public Task<ActionResult<IEnumerable<InvoiceModel>>> GetInvoices(InvoiceStatusModel? status);
        public Task<IEnumerable<InvoiceModel>> GetInvoices(InvoiceStatusModel? status, int page = 1, int pageSize = 10);

        public Task<InvoiceModel> GetInvoice(Guid id);

        public Task PostInvoice(InvoiceModel invoice);

        public Task PutInvoice(Guid id, InvoiceModel invoice);
        public Task<bool> DeleteInvoice(Guid id);
       
    }
}
