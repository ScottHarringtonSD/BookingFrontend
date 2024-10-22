using System.Text.Json.Nodes;
using BookingFrontEnd.Models;
using RestSharp;
   

public class BookingClient : IBookingClient, IDisposable

{
        private readonly IClient _client;
        public BookingClient(IClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Gets a booking given a booking id.
        /// </summary>
        /// <param name="Id">The id of the booking.
        /// <returns>The booking.</returns>
        public Booking GetBooking(string Id){
            var request = new RestRequest(

                "Bookings/" + Id, Method.Get);

            var response =

                _client!.ExecuteRequest<BookingBusinessModel>(request);


            
            return new Booking(response);
            
        }

        public string AddBooking(BookingBusinessModel booking){

            var request = new RestRequest("Bookings", Method.Post);
            request.AddBody(booking);
            var response = _client!.ExecuteRequest<AddSuccess>(request);


            return response.Id;
        }

 



        public void Dispose() {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }

}

