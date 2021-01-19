using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ClaimsByMember.Models
{
    public class Member
    {
        
        public int MemberID { get; set; }
        
        public DateTime EnrollmentDate { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}