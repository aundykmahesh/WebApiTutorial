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
        public void Test_Fibonacci_Series_0_92()
        {
            long[] d = new long[] {0,1,1,2,3,5,8,13, 21,34,55,89,144,233,377,610,987,1597,2584,4181,6765,10946,17711,28657,46368,75025,121393,196418,317811,514229,832040,1346269,2178309,3524578 ,
            5702887,9227465,14930352,24157817,39088169,63245986,102334155,165580141,267914296,433494437,701408733,1134903170,1836311903,2971215073,4807526976,7778742049 ,
            12586269025,20365011074,32951280099,53316291173,86267571272,139583862445,225851433717,365435296162,591286729879,956722026041,1548008755920 ,2504730781961,4052739537881,
            6557470319842,10610209857723,17167680177565,27777890035288,44945570212853,72723460248141,117669030460994,190392490709135,308061521170129,498454011879264,806515533049393,
            1304969544928657,2111485077978050,3416454622906707 ,5527939700884757,8944394323791464,14472334024676221,23416728348467685,37889062373143906,61305790721611591 ,
            99194853094755497,160500643816367088,259695496911122585,420196140727489673,679891637638612258,1100087778366101931,1779979416004714189,2880067194370816120,4660046610375530309,7540113804746346429
            };
            string a = string.Empty;
            for (int i = 0; i < d.Length - 1; i++)
            {
                var actualresult = _fibonaccicontroller.Get(i) as ContentResult;
                Assert.Equal(d[i].ToString(), actualresult.Content);

            }
            
        }

        [Fact]
        public async void Test_Fibonacci_Series_Less_Than_0()
        {
            for (var i = 0; i <= 92; i++)
            {
                HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/Fibonacci?n=" + (i * -1).ToString());
                var expectedresult = responseMessage.Content.ReadAsStringAsync();
                var actualresult = _fibonaccicontroller.Get(i * -1) as ContentResult;
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

            Assert.Equal(expectedresult.Result, (actualresult.Content.ToString().Contains("request is invalid")) ? string.Empty : actualresult.Content.ToString());
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

        //public static IEnumerable<object[]> EnumerableNumber => new List<object[]>
        //{ new object[]{
        //    0,1,1,2,3,5,8,13, 21,34,55,89,144,233,377,610,987,1597,2584,4181,6765,10946,17711,28657,46368,75025,121393,196418,317811,514229,832040,1346269,2178309,3524578 ,
        //    5702887,9227465,14930352,24157817,39088169,63245986,102334155,165580141,267914296,433494437,701408733,1134903170,1836311903,2971215073,4807526976,7778742049 ,
        //    12586269025,20365011074,32951280099,53316291173,86267571272,139583862445,225851433717,365435296162,591286729879,956722026041,1548008755920 ,2504730781961,4052739537881,
        //    6557470319842,10610209857723,17167680177565,27777890035288,44945570212853,72723460248141,117669030460994,190392490709135,308061521170129,498454011879264,806515533049393,
        //    1304969544928657,2111485077978050,3416454622906707 ,5527939700884757,8944394323791464,14472334024676221,23416728348467685,37889062373143906,61305790721611591 ,
        //    99194853094755497,160500643816367088,259695496911122585,420196140727489673,679891637638612258,1100087778366101931,1779979416004714189,2880067194370816120,4660046610375530309,7540113804746346429
        //}
        //};

        public static IEnumerable<object[]> GetData() {
            yield return new object[] { 0, 0 }; yield return new object[] { 1, 1 }; yield return new object[] { 2, 1 }; yield return new object[] { 3, 2 }; yield return new object[] { 4, 3 }; yield return new object[] { 5, 5 }; yield return new object[] { 6, 8 }; yield return new object[] { 7, 13 }; yield return new object[] { 8, 21 }; yield return new object[] { 9, 34 }; yield return new object[] { 10, 55 }; yield return new object[] { 11, 89 }; yield return new object[] { 12, 144 }; yield return new object[] { 13, 233 }; yield return new object[] { 14, 377 }; yield return new object[] { 15, 610 }; yield return new object[] { 16, 987 }; yield return new object[] { 17, 1597 }; yield return new object[] { 18, 2584 }; yield return new object[] { 19, 4181 }; yield return new object[] { 20, 6765 }; yield return new object[] { 21, 10946 }; yield return new object[] { 22, 17711 }; yield return new object[] { 23, 28657 }; yield return new object[] { 24, 46368 }; yield return new object[] { 25, 75025 }; yield return new object[] { 26, 121393 }; yield return new object[] { 27, 196418 }; yield return new object[] { 28, 317811 };
            yield return new object[] { 29,514229}; yield return new object[] { 30, 832040 }; yield return new object[] { 31, 1346269 }; yield return new object[] { 32, 2178309 }; yield return new object[] { 33, 3524578 }; yield return new object[] { 34, 5702887 }; yield return new object[] { 35, 9227465 }; yield return new object[] { 36, 14930352 }; yield return new object[] { 37, 24157817 }; yield return new object[] { 38, 39088169 }; yield return new object[] { 39, 63245986 }; yield return new object[] { 40, 102334155 }; yield return new object[] { 41, 165580141 }; yield return new object[] { 42, 267914296 }; yield return new object[] { 43, 433494437 }; yield return new object[] { 44, 701408733 }; yield return new object[] { 45, 1134903170 }; yield return new object[] { 46, 1836311903 }; yield return new object[] { 47, 2971215073 }; yield return new object[] { 48, 4807526976 }; yield return new object[] { 49, 7778742049 }; yield return new object[] { 50, 12586269025 }; yield return new object[] { 51, 20365011074 }; yield return new object[] { 52, 32951280099 }; yield return new object[] { 53, 53316291173 };
            yield return new object[] { 54,86267571272}; yield return new object[] { 55, 139583862445 }; yield return new object[] { 56, 225851433717 }; yield return new object[] { 57, 365435296162 }; yield return new object[] { 58, 591286729879 }; yield return new object[] { 59, 956722026041 }; yield return new object[] { 60, 1548008755920 }; yield return new object[] { 61, 2504730781961 }; yield return new object[] { 62, 4052739537881 }; yield return new object[] { 63, 6557470319842 }; yield return new object[] { 64, 10610209857723 }; yield return new object[] { 65, 17167680177565 }; yield return new object[] { 66, 27777890035288 }; yield return new object[] { 67, 44945570212853 }; yield return new object[] { 68, 72723460248141 }; yield return new object[] { 69, 117669030460994 }; yield return new object[] { 70, 190392490709135 }; yield return new object[] { 71, 308061521170129 }; yield return new object[] { 72, 498454011879264 }; yield return new object[] { 73, 806515533049393 }; yield return new object[] { 74, 1304969544928657 }; yield return new object[] { 75, 2111485077978050 }; yield return new object[] {76,3416454622906707};
            yield return new object[] { 77, 5527939700884757 }; yield return new object[] { 78, 8944394323791464 }; yield return new object[] { 79, 14472334024676221 }; yield return new object[] { 80, 23416728348467685 }; yield return new object[] { 81, 37889062373143906 }; yield return new object[] { 82, 61305790721611591 }; yield return new object[] { 83, 99194853094755497 }; yield return new object[] { 84, 160500643816367088 }; yield return new object[] { 85, 259695496911122585 }; yield return new object[] { 86, 420196140727489673 }; yield return new object[] { 87, 679891637638612258 }; yield return new object[] { 88, 1100087778366101931 }; yield return new object[] { 89, 1779979416004714189 }; yield return new object[] { 90, 2880067194370816120 }; yield return new object[] { 91, 4660046610375530309 }; 

        }
    }

}
