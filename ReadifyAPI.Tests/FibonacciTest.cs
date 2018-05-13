using System;
using Xunit;
using ReadifyAPI.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

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
        [MemberData(nameof(EnumerableNumber))]
        public async void Test_Fibonacci_Series_0_92()
        {
            for (var i = 0; i <= 92; i++)
            {
                //HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/Fibonacci?n=" + i.ToString());
                //var expectedresult = responseMessage.Content.ReadAsStringAsync();
                var actualresult = _fibonaccicontroller.Get(i) as ContentResult;
                //Assert.Equal(expectedresult.Result, actualresult.Content.ToString());
            }
        }

        [Fact]
        public async void Test_Fibonacci_Series_Less_Than_0()
        {
            for (var i = 0; i <= 92; i++)
            {
                HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/Fibonacci?n=" + (i*-1).ToString());
                var expectedresult = responseMessage.Content.ReadAsStringAsync();
                var actualresult = _fibonaccicontroller.Get(i*-1) as ContentResult;
                Assert.Equal(expectedresult.Result, actualresult.Content.ToString());
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_Fibonacci_Series_More_Than_92Async()
        {
            int a = 333;
            HttpResponseMessage responseMessage = await client.GetAsync($"https://knockknock.readify.net:443/api/Fibonacci?n={a}");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            var actualresult = _fibonaccicontroller.Get(a) as ContentResult;

            Assert.Equal(expectedresult.Result,(actualresult.Content.ToString().Contains("request is invalid")) ? string.Empty: actualresult.Content.ToString());
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_Fibonacci_Series_More_Than_Negative_92Async()
        {
            int a = -93;
            HttpResponseMessage responseMessage = await client.GetAsync($"https://knockknock.readify.net:443/api/Fibonacci?n={a}");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            var actualresult = _fibonaccicontroller.Get(a) as ContentResult;

            Assert.Equal(expectedresult.Result, (actualresult.Content.ToString().Contains("request is invalid")) ? string.Empty : actualresult.Content.ToString());
        }
        [Fact]
        public async System.Threading.Tasks.Task Test_With_StringAsync()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/Fibonacci?n=test");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            HttpResponseMessage responseMessage1 = await client.GetAsync("http://apitutorialaundy.azurewebsites.net/api/Fibonacci?n=test");
            var actualresult = responseMessage1.Content.ReadAsStringAsync();
            Assert.Equal(expectedresult.Result, actualresult.Result);
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_With_NullAsync()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/Fibonacci?n=");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            HttpResponseMessage responseMessage1 = await client.GetAsync("http://apitutorialaundy.azurewebsites.net/api/Fibonacci?n=");
            var actualresult = responseMessage1.Content.ReadAsStringAsync();
            Assert.Equal(expectedresult.Result, actualresult.Result);
        }

        public static IEnumerable<object[]> EnumerableNumber => new List<object[]>
        { new object[]{
            0,1,1,2,3,5,8,13, 21,34,55,89,144,233,377,610,987,1597,2584,4181,6765,10946,17711,28657,46368,75025,121393,196418,317811,514229,832040,1346269,2178309,3524578 ,
            5702887,9227465,14930352,24157817,39088169,63245986,102334155,165580141,267914296,433494437,701408733,1134903170,1836311903,2971215073,4807526976,7778742049 ,
            12586269025,20365011074,32951280099,53316291173,86267571272,139583862445,225851433717,365435296162,591286729879,956722026041,1548008755920 ,2504730781961,4052739537881,
            6557470319842,10610209857723,17167680177565,27777890035288,44945570212853,72723460248141,117669030460994,190392490709135,308061521170129,498454011879264,806515533049393,
            1304969544928657,2111485077978050,3416454622906707 ,5527939700884757,8944394323791464,14472334024676221,23416728348467685,37889062373143906,61305790721611591 ,
            99194853094755497,160500643816367088,259695496911122585,420196140727489673,679891637638612258,1100087778366101931,1779979416004714189,2880067194370816120,4660046610375530309,7540113804746346429
        }
        };

    }
}
