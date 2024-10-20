    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Invoice.Domain.Models
{
    public class InvoiceItemModel
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public Guid InvoiceId { get; set; } //Foreign key

        //Reference navigation property

        [JsonIgnore]
        public InvoiceModel? Invoice { get; set; }
        //the Invoice property of the InvoiceItem class is a reference navigation property.
    }
}
