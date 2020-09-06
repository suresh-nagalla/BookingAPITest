using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Booking = BookingAPITest.Model.BookingModel;
using BookingResponse = BookingAPITest.Model.BookingResponse;
using AuthRequest = BookingAPITest.Model.AuthenticateRequest;
using AuthResp = BookingAPITest.Model.AuthenticationResponse;
using BookingAPITest.Model;
using TechTalk.SpecFlow.EnvironmentAccess;

namespace BookingAPITest.API
{
    public class Booking
    {
        private static readonly string basicURL = "https://restful-booker.herokuapp.com/";
        private static readonly string URLSegment = "booking/";
        private static readonly string URL = string.Concat(basicURL, URLSegment);

        public static HttpResponseMessage GetAllBookingsResponse()
        {
            var bookingUrl = URL;
            using (var httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Get })
                {
                    var response = httpClient.SendAsync(request).Result;
                    return response;
                }
            }
        }

        public static Response<List<BookingID>> GetAllBookings(HttpResponseMessage response)
        {
            var RespJsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var respBookingsList = JsonConvert.DeserializeObject<List<BookingID>>(RespJsonString);
            return new Response<List<BookingID>> { IsSuccess = response.IsSuccessStatusCode, Message = response.StatusCode.ToString(), ResponseData = respBookingsList };
        }

        public static HttpResponseMessage GetBooking(int id, string accept = "application/json")
        {
            var bookingUrl = string.Concat(URL, id.ToString());
            using (var httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Get })
                {
                    request.Headers.Add("Accept", accept);
                    var response = httpClient.SendAsync(request).Result;
                    //IsOKResponse(response);
                    return response;
                }
            }
        }

        public static HttpResponseMessage PostBooking(Model.BookingModel booking)
        {
            var bookingUrl = URL;
            string requestBody = JsonConvert.SerializeObject(booking);
            using (var httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Post })
                {
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    //request.Headers.Add("Content-Type", "application/json");
                    request.Headers.Add("Accept", "application/json");
                    var response = httpClient.SendAsync(request).Result;
                    // IsOKResponse(response);
                    return response;
                }
            }
        }

        public static Model.Response<BookingResponse> GetPostBookingDetails(HttpResponseMessage response)
        {
            var RespJsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var bookingRespObj = JsonConvert.DeserializeObject<BookingResponse>(RespJsonString);
            return new Model.Response<BookingResponse>() { IsSuccess = response.IsSuccessStatusCode, Message = response.StatusCode.ToString(), ResponseData = bookingRespObj };
        }

        public static Model.Response<BookingModel> GetUpdatedBookingDetails(HttpResponseMessage response)
        {
            var RespJsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var bookingRespObj = JsonConvert.DeserializeObject<BookingModel>(RespJsonString);
            return new Model.Response<BookingModel>() { IsSuccess = response.IsSuccessStatusCode, Message = response.StatusCode.ToString(), ResponseData = bookingRespObj };
        }

        public static HttpResponseMessage UpdateBooking(BookingModel booking, int id)
        {
            string requestBody = JsonConvert.SerializeObject(booking);
            try
            {
                var cookieContainer = new CookieContainer();
                using (var handler = new HttpClientHandler())
                {
                    handler.CookieContainer = cookieContainer;
                    var bookingUrl = string.Concat(URL, id.ToString());
                    using (var httpClient = new HttpClient(handler))
                    {
                        using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Put })
                        {
                            request.Headers.Add("Accept", "application/json");
                            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                            cookieContainer.Add(new Uri(bookingUrl), new Cookie("token", API.Authentication.GetToken()));
                            return httpClient.SendAsync(request).Result;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e);
                return null;
            }
        }

        public static Model.Response<Model.BookingModel> GetBookingDetails(HttpResponseMessage response)
        {
            try
            {
                var RespJsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var bookingRespObj = JsonConvert.DeserializeObject<Model.BookingModel>(RespJsonString);
                return new Model.Response<Model.BookingModel>() { IsSuccess = response.IsSuccessStatusCode, Message = response.StatusCode.ToString(), ResponseData = bookingRespObj };
            }
            catch (Exception ex)
            {
                return new Model.Response<Model.BookingModel>() { IsSuccess = false, Message = ex.Message, ResponseData = null };
            }

        }



        public static HttpResponseMessage DeleteBooking(int id)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                using (var handler = new HttpClientHandler())
                {
                    handler.CookieContainer = cookieContainer;
                    var bookingUrl = string.Concat(URL, id.ToString());
                    using (var httpClient = new HttpClient(handler))
                    {
                        using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Delete })
                        {
                            cookieContainer.Add(new Uri(bookingUrl), new Cookie("token", API.Authentication.GetToken()));
                            return httpClient.SendAsync(request).Result;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e);
                return null;
            }
        }

        public static void IsOKResponse(HttpResponseMessage response)
        {
            int statusCode = response != null ? Convert.ToInt32(response.StatusCode) : -1;
            if (statusCode.Equals(200))
            {
                throw new HttpException(statusCode, $"Expected Response Code : 200, But Response Code : {statusCode}:" + response.RequestMessage);
            }
            else
            {
                throw new HttpException("Failed to get Response");
            }
        }

        public static bool Get404NotFoundMessage(HttpResponseMessage response)
        {
            int statusCode = response != null ? Convert.ToInt32(response.StatusCode) : -1;
            if (statusCode.Equals(404))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
