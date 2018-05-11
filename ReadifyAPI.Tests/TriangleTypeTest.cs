using System;
using Xunit;
using ReadifyAPI.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ReadifyAPI.Tests
{
    public class TriangleTypeTest
    {
        private readonly TriangleTypeController _triangletypecontroller;
        private HttpClient client = new HttpClient();

        public TriangleTypeTest()
        {
            _triangletypecontroller = new TriangleTypeController();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        [Fact]

        public async void Test_Equilateral()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/TriangleType?a=12&b=12&c=12");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            var actualresult = _triangletypecontroller.Get(12, 12, 12);
            Assert.Equal(expectedresult.Result.Replace('"', ' ').Trim(), actualresult.Value);
        }
        [Fact]

        public async void Test_Isocsceles()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/TriangleType?a=12&b=13&c=12");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            var actualresult = _triangletypecontroller.Get(12, 13, 12);
            Assert.Equal(expectedresult.Result.Replace('"', ' ').Trim(), actualresult.Value);
        }
        [Fact]

        public async void TestScalene()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/TriangleType?a=12&b=13&c=14");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            var actualresult = _triangletypecontroller.Get(12, 13, 144);
            Assert.Equal(expectedresult.Result.Replace('"', ' ').Trim(), actualresult.Value);
        }

    }
}
