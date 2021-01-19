using ClaimsByMember.Models;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;
using CsvHelper;
using ClaimsByMember.Dtos;
using Newtonsoft.Json;
namespace ClaimsByMember.BusinessLayer
{
    public class Data
    {
        public string GetData(InputData data)
        {
            var members = new List<Member>();
            var claims = new List<Claim>();
            GetCsvData(out members, out claims);

            if (members.Count > 0)
            {
                //Join two collections and get required data
                var results = (from cl in claims
                               join mem in members on cl.MemberID equals mem.MemberID
                               where mem.MemberID == data.Id && cl.ClaimDate == data.Date
                               select new
                               {
                                   mem.MemberID,
                                   mem.EnrollmentDate,
                                   mem.FirstName,
                                   mem.LastName,
                                   cl.ClaimDate,
                                   cl.ClaimAmount
                               });
                return results.Any() ? JsonConvert.SerializeObject(results).ToString() : "No Data";
            }
            return string.Empty;
        }

        private void GetCsvData(out List<Member> members, out List<Claim> claims)
        {
            //Get data from member file
            using (var reader = new StreamReader(@"c:/member.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                csv.Read();
                csv.ReadHeader();
                members = csv.GetRecords<Member>().ToList();
            }

            // //Get data from claim file
            using (var reader = new StreamReader(@"c:/claim.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                csv.Read();
                csv.ReadHeader();
                claims = csv.GetRecords<Claim>().ToList();
            }
        }
    }
}