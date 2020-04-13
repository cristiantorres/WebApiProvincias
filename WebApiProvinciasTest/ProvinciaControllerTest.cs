using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiProvincias;
using Xunit;

namespace WebApiProvinciasTest
{
   
    public class ProvinciaControllerTest
    {
        private readonly HttpClient client;

        public ProvinciaControllerTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            client = appFactory.CreateClient();
        }

        [Theory]
        [InlineData("santander")]
        [InlineData("_lomas")]
        [InlineData("lavallol")]
        public async Task GetProvinciaNotfound(string nombreProvincia)
        {

                client.BaseAddress = new Uri("http://localhost:5000/api/");
                var route = $"provincia/{nombreProvincia}";
                var responseTask = await client.GetAsync(route);
                var NotOk = HttpStatusCode.NotFound.Equals(responseTask.StatusCode);
                Assert.True(NotOk);
          
        }

        [Theory]
        [InlineData("Chaco")]
        [InlineData("Tucuman")]
        [InlineData("Chubut")]
        public void GetProvinciaOk(string nombreProvincia)
        {
            var _url = $"http://localhost:5000/api/provincia/{nombreProvincia}";

            Uri _uri = new Uri(_url);
            var responseTask = client.GetAsync(_uri);
            Assert.True(HttpStatusCode.OK.Equals(responseTask.Result.StatusCode));
        }


    }
}
