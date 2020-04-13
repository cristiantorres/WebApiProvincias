using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiProvincias;
using Xunit;

namespace WebApiProvinciasTest
{
    public class UsuarioControllerTest
    {
        private readonly HttpClient client;

        public UsuarioControllerTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            client = appFactory.CreateClient();
        }
        [Theory]
        [InlineData("cristian.torres","123456")]
         public async Task loginOk(string username,string pass )
        {
            var _url = $"http://localhost:5000/api/usuario/login";
 
            var myContent = JsonConvert.SerializeObject(new { username = username, password = pass });
            HttpContent _Body1 = new StringContent(myContent, Encoding.UTF8, "application/json");

            Uri _uri = new Uri(_url);
            var responseTask =await client.PostAsync(_uri,_Body1);
   
            var ok = HttpStatusCode.OK.Equals(responseTask.StatusCode);
            Assert.True(ok);
  

        }
        [Theory]
        [InlineData("cristn.torres", "1450006")]
        public async Task loginNotOk(string username, string pass)
        {
            var _url = $"http://localhost:5000/api/users/login";
 
            var myContent = JsonConvert.SerializeObject(new { username = username, password = pass});
            HttpContent _Body1 = new StringContent(myContent, Encoding.UTF8, "application/json");
            Uri _uri = new Uri(_url);
            var responseTask = await client.PostAsync(_uri, _Body1);
            var NotFound = HttpStatusCode.NotFound.Equals(responseTask.StatusCode);
            Assert.True(NotFound);
        }
    }
}
