using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Models
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public Guid ContactId { get; set; } //foreign key as you can see is defined in the Address class, which implies that the Address class in the dependent entity
        public ContactModel? Contact { get; set; }
    }
}
