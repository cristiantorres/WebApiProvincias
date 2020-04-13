using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace WebApiProvinciasTest
{
    class UsuarioControllerTest
    {
        [Theory]
        [InlineData("cristian.torres","123456")]
         public void loginOk(string username,string pass )
        {
            var _url = $"http://localhost:5000/api/users/login";
            using (var client = new HttpClient())
            {
                Uri _uri = new Uri(_url);
                var responseTask = client.PostAsync(_uri,new HttpContent(new { username = username, password = pass }));
   
                var ok = HttpStatusCode.OK.Equals(responseTask.Result.StatusCode);
                Assert.True(ok);
            }

        }
        [Theory]
        [InlineData("cristn.torres", "1450006")]
        public void loginNotOk(string username, string pass)
        {
            var _url = $"http://localhost:5000/api/users/login";
            using (var client = new HttpClient())
            {
                Uri _uri = new Uri(_url);
                var responseTask = client.PostAsync(_uri, new HttpContent(new { username = username, password = pass }));
                var NotFound = HttpStatusCode.NotFound.Equals(responseTask.Result.StatusCode);
                Assert.True(NotFound);
            }

        }
    }
}
