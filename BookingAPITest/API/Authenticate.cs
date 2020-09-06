using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPITest.API
{
    public class Authentication
    {
        private static string authURL = "https://restful-booker.herokuapp.com/auth";

        private static string GetAuthToken(Model.AuthenticateRequest authRequest)
        {
            try
            {
                string requestBody = JsonConvert.SerializeObject(authRequest);
                using (var httpClient = new HttpClient())
                {
                    using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(authURL), Method = HttpMethod.Post })
                    {
                        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                        var response = httpClient.SendAsync(request).Result;
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Model.AuthenticationResponse>(responseString)?.token;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e);
                return null;
            }
        }

        public static string GetToken(string username ="admin", string password="password123") => Authentication.GetAuthToken(new Model.AuthenticateRequest() { username = username, password = password });

    }
}
