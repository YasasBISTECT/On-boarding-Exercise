using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Models
{
    public class ShippingAddress
    {
        public int ShippingId { get; set; }
        public int CustRegistrationId { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string SpecificRegistrationRequest { get; set; }
        public Boolean Email { get; set; }

    }
}
