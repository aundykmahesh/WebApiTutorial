using System;
using Xunit;
using ReadifyAPI.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Diagnostics;

namespace ReadifyAPI.Tests
{
    public class ReverseWordsTest
    {
        private readonly ReverseWordsController _reversewordscontroller;
        private HttpClient client = new HttpClient();
        private static Random random = new Random();

        public ReverseWordsTest()
        {
            _reversewordscontroller = new ReverseWordsController();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        [Fact]

        public async void Test_Randomly_Generated_Sentences()
        {
            for (int i = 0; i <= 100; i++)
            {
                string randomword = RandomGenerateString(i);
                HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/ReverseWords?sentence=" + randomword);
                var expectedresult = responseMessage.Content.ReadAsStringAsync();
                var actualresult = _reversewordscontroller.Get(randomword);
                Assert.Equal(expectedresult.Result.Replace('"', ' ').Trim(), actualresult.Value);
            }
        }

        [Fact]
        public async void Test_Randomly_Generated_Sentence()
        {

            string randomword = RandomGenerateString(1000);
            //string randomword = "This is foe testing";
                HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/ReverseWords?sentence=" + randomword);
                var expectedresult = responseMessage.Content.ReadAsStringAsync();
                var actualresult = _reversewordscontroller.Get(randomword);
            Debug.Print(expectedresult.Result);
            Debug.Print(actualresult.Value.ToString());
                Assert.Equal(expectedresult.Result.Replace('"', ' ').Trim(), actualresult.Value);
           
        }
        [Fact]

        public async void Test_Empty_Sentence()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/ReverseWords?sentence=");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            var actualresult = _reversewordscontroller.Get("");
            Assert.Equal(expectedresult.Result.Replace('"', ' ').Trim(), actualresult.Value);
        }
        [Fact]

        public async void Test_NULL_Sentence()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://knockknock.readify.net:443/api/ReverseWords");
            var expectedresult = responseMessage.Content.ReadAsStringAsync();
            var actualresult = _reversewordscontroller.Get(null);
            Assert.Equal(expectedresult.Result.Replace('"', ' ').Trim(), actualresult.Value);
        }
        //Thanks to https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings-in-c
        private static string RandomGenerateString(int length)
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789           !#$%^&*(){}[]:;':?>.<,";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
