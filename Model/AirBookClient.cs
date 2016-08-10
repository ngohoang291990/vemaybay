using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using Model.Converts;
using Model.Models;
using Newtonsoft.Json;

namespace Model
{
    public class AirBookClient
    {
        private readonly HttpClient httpClient;

        private AuthenticateInfo auth;

        public AirBookClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SetAuthenticate(AuthenticateInfo authenticate)
        {
            this.auth = authenticate;
        }

        public void SetServerInfo(ServerInfo serverInfo)
        {
            this.httpClient.BaseAddress = new Uri(serverInfo.ApiServer);
        }

        public IEnumerable<Flight> FindFlight(FindFlight findFlight)
        {
            if (this.httpClient.BaseAddress == null)
            {
                throw new InvalidOperationException("Must set server info first");
            }

            if (this.auth == null)
            {
                throw new NullReferenceException("Authenticate is not set");
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "oapi/airline/Flights/Find?$expand=TicketPriceDetails,Details,PriceSummaries,TicketOptions");
            requestMessage.Content = new ObjectContent(typeof(FindFlight),findFlight,new JsonMediaTypeFormatter());

            this.SetAuthenticateHeader(requestMessage);
            var response = this.httpClient.SendAsync(requestMessage).Result;
            if (response.IsSuccessStatusCode)
            {
                var text = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<ODataWrapper<IEnumerable<Flight>>>(
                    text, new TimeSpanJsonConverter()).Value;
            }

            throw new InvalidOperationException(response.Content.ReadAsStringAsync().Result);
        }

        public BookingResult BookFlight(Booking booking)
        {
            if (this.httpClient.BaseAddress == null)
            {
                throw new InvalidOperationException("Must set server info first");
            }

            if (this.auth == null)
            {
                throw new NullReferenceException("Authenticate is not set");
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/oapi/airline/Bookings");
            var json = JsonConvert.SerializeObject(booking, Formatting.None, new DecimalJsonConverter(), new TimeSpanJsonConverter());

            var content = new StringContent(json);
            content.Headers.ContentType.MediaType = "application/json";
            requestMessage.Content = content;
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.SetAuthenticateHeader(requestMessage);
            var response = this.httpClient.SendAsync(requestMessage).Result;
            if (response.IsSuccessStatusCode)
            {
                var text = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<BookingResult>(
                    text,
                    new TimeSpanJsonConverter(),
                    new DecimalJsonConverter());
            }

            throw new InvalidOperationException(response.Content.ReadAsStringAsync().Result);
        }

        private void SetAuthenticateHeader(HttpRequestMessage requestMessage)
        {
            var byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", this.auth.Username, this.auth.Password));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}