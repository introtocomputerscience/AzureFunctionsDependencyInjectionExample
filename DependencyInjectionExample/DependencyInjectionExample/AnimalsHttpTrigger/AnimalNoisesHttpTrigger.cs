using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AzureFunctions.Autofac;
using DependencyInjectionExample.Configs;
using DependencyInjectionExample.Interfaces;
using DependencyInjectionExample.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace DependencyInjectionExample.AnimalsHttpTrigger
{
    [DependencyInjectionConfig(typeof(AutofacConfig))]
    public static class AnimalNoisesHttpTrigger
    {
        [FunctionName("AnimalNoisesHttpTrigger")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req, TraceWriter log, [Inject]IAnimal animal)
        {
            log.Info("C# HTTP trigger function processed a request.");
            return req.CreateResponse(HttpStatusCode.OK, animal.MakeNoise());
        }
    }
}
