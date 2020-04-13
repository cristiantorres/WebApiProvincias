using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiProvinciasTest
{
    public class ProvinciaControllerTest
    {       
        [Theory]
        [InlineData("santander")]
        [InlineData("_lomas")]
        [InlineData("lavallol")]
        public async Task GetProvinciaNotfound(string nombreProvincia)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
                var route = $"provincia/{nombreProvincia}";
                var responseTask = await client.GetAsync(route);
                var NotOk = HttpStatusCode.NotFound.Equals(responseTask.StatusCode);
                Assert.True(NotOk);
            }
        }

        [Theory]
        [InlineData("Chaco")]
        [InlineData("Tucuman")]
        [InlineData("Chubut")]
        public void GetProvinciaOk(string nombreProvincia)
        {
            var _url = $"http://localhost:5000/api/provincia/{nombreProvincia}";
            using (var client = new HttpClient())
            {
                Uri _uri = new Uri(_url);
                var responseTask = client.GetStringAsync(_uri);
                JObject _jsonResponse = JObject.Parse(responseTask.Result);
                var _provinciasEncontradas = (JArray)_jsonResponse["provincias"];
                var ok = HttpStatusCode.OK.Equals(200);
                Assert.True(ok && (_provinciasEncontradas.Count>0));
            }

        }


    }
}
