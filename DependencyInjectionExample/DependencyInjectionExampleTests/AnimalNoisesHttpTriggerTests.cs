using DependencyInjectionExample.AnimalsHttpTrigger;
using DependencyInjectionExample.Interfaces;
using DependencyInjectionExample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DependencyInjectionExampleTests
{
    [TestClass]
    public class AnimalNoisesHttpTriggerTests
    {
        [TestMethod]
        public async Task TestShouldBark()
        {
            HttpRequestMessage request = TestHelpers.CreateGetRequest();
            TraceWriterStub traceWriter = new TraceWriterStub(System.Diagnostics.TraceLevel.Info);
            var response = await AnimalNoisesHttpTrigger.Run(request, traceWriter, new Dog());
            var content = await response.Content.ReadAsAsync<string>();
            Assert.AreEqual("Bark!", content);
        }

        [TestMethod]
        public async Task TestShouldMeow()
        {
            HttpRequestMessage request = TestHelpers.CreateGetRequest();
            TraceWriterStub traceWriter = new TraceWriterStub(System.Diagnostics.TraceLevel.Info);
            var response = await AnimalNoisesHttpTrigger.Run(request, traceWriter, new Cat());
            var content = await response.Content.ReadAsAsync<string>();
            Assert.AreEqual("Meow!", content);
        }

        [TestMethod]
        public async Task TestShouldMoo()
        {
            HttpRequestMessage request = TestHelpers.CreateGetRequest();
            TraceWriterStub traceWriter = new TraceWriterStub(System.Diagnostics.TraceLevel.Info);
            Mock<IAnimal> cow = new Mock<IAnimal>();
            cow.Setup(x => x.MakeNoise()).Returns("Moo!");
            var response = await AnimalNoisesHttpTrigger.Run(request, traceWriter, cow.Object);
            var content = await response.Content.ReadAsAsync<string>();
            Assert.AreEqual("Moo!", content);
        }
    }
}
