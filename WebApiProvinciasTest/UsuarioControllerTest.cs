using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace WebApiProvinciasTest
{
    public class UsuarioControllerTest
    {
        [Theory]
        [InlineData("cristian.torres","123456")]
         public void loginOk(string username,string pass )
        {
            var _url = $"http://localhost:5000/api/users/login";
            using (var client = new HttpClient())
            {
                var myContent = JsonConvert.SerializeObject(new { username = username, password = pass });
                HttpContent _Body1 = new StringContent(myContent, Encoding.UTF8, "application/json");

                Uri _uri = new Uri(_url);
                var responseTask = client.PostAsync(_uri,_Body1);
   
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
                var myContent = JsonConvert.SerializeObject(new { username = username, password = pass});
                HttpContent _Body1 = new StringContent(myContent, Encoding.UTF8, "application/json");
                Uri _uri = new Uri(_url);
                var responseTask = client.PostAsync(_uri, _Body1);
                var NotFound = HttpStatusCode.NotFound.Equals(responseTask.Result.StatusCode);
                Assert.True(NotFound);
            }

        }
    }
}
