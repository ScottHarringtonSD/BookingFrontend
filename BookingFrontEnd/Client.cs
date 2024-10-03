using System.Text.Json.Nodes;
using BookingFrontEnd.Models;
using RestSharp;

public class Client : IClient, IDisposable
    {
        private readonly IRestClient _restClient;
        public Client()
        {
            var options = new RestClientOptions("http://localhost:3000")
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            _restClient = new RestClient(options);
        }

        public async Task<Booking> GetBooking(string Id){
            var request = new RestRequest("bookings/" + Id, Method.Get);
            //request.AddParameter("id", Id);
            var response = await _restClient.GetAsync<RestResponse>(request);

            if(response != null){
                    Console.WriteLine(response.Content);
            }
            




            DateOnly testDate = DateOnly.Parse("12-12-2000");
            return new Booking("", "test", "test", testDate);
            
        }



        public void Dispose() {
        _restClient?.Dispose();
        GC.SuppressFinalize(this);
    }

        
    }