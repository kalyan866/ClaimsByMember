using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaimsByMember.Models
{
    public class Claim
    {
        public int MemberID { get; set; }
        public DateTime ClaimDate { get; set; }
        public decimal ClaimAmount { get; set; }
    }
}