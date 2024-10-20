using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Models
{
    public enum InvoiceStatusModel
    {
        Draft,
        AwaitPayment,
        Paid,
        Overdue,
        Cancelled
    }
}
