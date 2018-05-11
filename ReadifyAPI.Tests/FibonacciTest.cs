using System;
using Xunit;
using ReadifyAPI.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace ReadifyAPI.Tests
{
    public class FibonacciTest
    {
        private readonly FibonacciController _fibonaccicontroller;
        private HttpClient client = new HttpClient();

        public FibonacciTest()
        {
            _fibonaccicontroller = new FibonacciController();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        [Fact]

        public async void Test_Fibonacci_Series_First_92()
        {
            for (var i = 0; i <= 92; i++)
            {
                HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/Fibonacci?n=" + i.ToString());
                var expectedresult = responseMessage.Content.ReadAsStringAsync();
                var actualresult = _fibonaccicontroller.Get(i) as JsonResult;
                Assert.Equal(expectedresult.Result, actualresult.Value.ToString());
            }
        }
        [Fact]
        public void Test_Fibonacci_Series_More_Than_92()
        {
            var expectedresult = string.Empty;
            var actualresult = _fibonaccicontroller.Get(93) as JsonResult;

            Assert.Equal(expectedresult, actualresult.Value.ToString());
        }
    }
}
