using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Models
{
    public class InvoiceModel
    {
        public Guid id{ get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public InvoiceStatusModel Status { get; set; }

        //Collection navigation property    
        public List<InvoiceItemModel> InvoiceItems { get; set; } = new List<InvoiceItemModel>(); //Here we are declaring that an Invoice object has a collection of InvoiceItems
        
        //The InvoiceItems property of the Invoice class is a collection navigation property.
    }
}
