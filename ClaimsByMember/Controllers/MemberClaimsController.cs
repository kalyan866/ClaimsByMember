using System.Web.Http;
using ClaimsByMember.Dtos;
using ClaimsByMember.BusinessLayer;
namespace ClaimsByMember.Controllers
{
    public class MemberClaimsController : ApiController
    {
        // GET: api/MemberClaims/inputdata
        public string Get(InputData data)
        {
            var csvData = new Data();
            return csvData.GetData(data);
        }
    }
}
