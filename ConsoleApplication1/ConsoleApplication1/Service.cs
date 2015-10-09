using System.Web.Http.SelfHost;
using System.Web.Http;
using Microsoft.OData.Edm;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ConsoleApplication1
{
    public class Service
    {
        private readonly HttpSelfHostServer server;

        public Service()
        {
            var selfHostConfiguraiton = new HttpSelfHostConfiguration("http://localhost:5555");

            selfHostConfiguraiton.MapHttpAttributeRoutes();
            
            selfHostConfiguraiton.MapODataServiceRoute("api", "api", GetApiModel());

            selfHostConfiguraiton.Routes.MapHttpRoute(
                name: "DefaultApiRoute",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            server = new HttpSelfHostServer(selfHostConfiguraiton);
        }

        public void Start()
        {
            server.OpenAsync();
        }

        public void Stop()
        {
            server.CloseAsync();
            server.Dispose();
        }

        private static IEdmModel GetApiModel()
        {
            var builder = new ODataConventionModelBuilder();

            var osago = builder.EntitySet<OsagoContractOdata>("OsagoContractOdata").EntityType;
            osago.Action("Annul");


            builder.Namespace = "K3";

            return builder.GetEdmModel();
        }
    }
}
