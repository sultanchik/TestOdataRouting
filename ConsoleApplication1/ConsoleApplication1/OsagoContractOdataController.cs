using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace ConsoleApplication1
{
    public class OsagoContractOdataController : ODataController
    {
        public IQueryable<OsagoContractOdata> Get([FromODataUri] string key)
        {
            return null;
        }

        [ODataRoute("OsagoContractOdata({guid})/K3.Annul")]
        public IHttpActionResult Annul(string guid)
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
