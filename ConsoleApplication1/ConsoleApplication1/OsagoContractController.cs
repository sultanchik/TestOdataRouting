using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsoleApplication1
{
    public class OsagoContractController : ApiController
    {
        public IHttpActionResult GetOsago()
        {
            return StatusCode(HttpStatusCode.Accepted);
        }


        [Route("api/OsagoContracts({guid:guid})/Annul")]
        public IHttpActionResult Post(Guid guid)
        {
            if (guid.Equals(Guid.Empty))
                return StatusCode(HttpStatusCode.NotFound);

            var guidString = guid.ToString();

            var lastSymbol = guidString[guidString.Length - 1];

            int number;
            if (int.TryParse(lastSymbol.ToString(), out number))
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                return StatusCode(HttpStatusCode.Accepted);
            }
        }
    }
}
