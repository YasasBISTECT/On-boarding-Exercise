using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Models
{
    public class AccountInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int CustRegistrationId { get; set; }
       // [Key, Column(Order = 1)]
        public string ContactPerson { get; set; }
      //  [Key, Column(Order = 3)]
        public string BusinessName { get; set; }
      //  [Key, Column(Order = 4)]
        public int ContactNumber { get; set; }
       // [Key, Column(Order = 5)]
        public string StreetAddress1 { get; set; }
       // [Key, Column(Order = 6)]
        public string StreetAddress2 { get; set; }
      //  [Key, Column(Order = 7)]
        public string City { get; set; }
      //  [Key, Column(Order = 8)]
        public string District { get; set; }
      //  [Key, Column(Order = 9)]
        public string Email { get; set; }
       // [Key, Column(Order = 10)]
        public DateTime StratDate { get; set; }

    }
}
