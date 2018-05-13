using System;
using Xunit;
using ReadifyAPI.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Newtonsoft.Json;

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
            Assert.Equal(expectedresult.Result.Replace('"', ' ').Trim(), actualresult.Content);
        }
        [Fact]

        public async void Test_Isocsceles()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/TriangleType?a=12&b=12&c=13");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            var actualresult = _triangletypecontroller.Get(12, 12, 13);
            Assert.Equal(expectedresult.Result.Replace('"', ' ').Trim(), actualresult.Content);
        }
        [Fact]

        public async void TestScalene()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/TriangleType?a=12&b=13&c=14");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            var actualresult = _triangletypecontroller.Get(12, 13, 144);
            Assert.Equal(expectedresult.Result.Replace('"', ' ').Trim(), actualresult.Content);
        }
        [Fact]
        public async void Test_All_Triangles()
        {
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                int a = random.Next(0, 10000);
                int b = random.Next(0, 10000);
                int c = random.Next(0, 10000);

                HttpResponseMessage responseMessage = await client.GetAsync($"https://knockknock.readify.net:443/api/TriangleType?a={a}&b={b}&c={c}");
                var expectedresult = responseMessage.Content.ReadAsStringAsync();
                var contentresult = _triangletypecontroller.Get(a, b, c);
                var actualresult = (contentresult.Content.ToString().Contains("Error")) ? JsonConvert.DeserializeObject<string>(contentresult.Content) : contentresult.Content;
                Assert.Equal(JsonConvert.DeserializeObject<String>(expectedresult.Result),actualresult);
            }
           
        }

    }
}
