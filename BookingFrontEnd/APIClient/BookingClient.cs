using System.Text.Json.Nodes;
using BookingFrontEnd.Models;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using RestSharp;
   

public class BookingClient : IBookingClient, IDisposable

{
        private readonly IClient _client;
        public BookingClient(IClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Gets a list of all the bookings
        /// </summary>
        /// <returns>The full list of bookings</returns>
        public List<Booking> GetAllBookings(){

            var request = new RestRequest("Bookings", Method.Get);

            var response = _client!.ExecuteRequest<List<BookingBusinessModel>>(request);

            List<Booking> returnList = new List<Booking>();

            foreach(var bookingBusinessModel in response){
                Booking returnBooking = new Booking(bookingBusinessModel);
                returnList.Add(returnBooking);
            }

            return returnList;
            
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

        /// <summary>
        /// Adds a booking to the system.
        /// </summary>
        /// <param name="booking">The booking being added.</param>
        /// <returns>The Id of the booking added.</returns> 
        public string AddBooking(BookingBusinessModel booking){

            var request = new RestRequest("Bookings", Method.Post);
            request.AddBody(booking);
            var response = _client!.ExecuteRequest<AddSuccess>(request);


            return response.Id;
        }

        /// <summary>
        /// Gets the bookings for a given month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns>Returns a list of bookings in that month.</returns>
        public List<Booking> GetMonthlyBookings(int year, int month)   
        {
            var request = new RestRequest("Bookings/monthly/" + year + "/" + month, Method.Get);

            var response = _client!.ExecuteRequest<List<BookingBusinessModel>>(request);

            List<Booking> returnList = new List<Booking>();

            foreach(var bookingBusinessModel in response){
                Booking returnBooking = new Booking(bookingBusinessModel);
                returnList.Add(returnBooking);
            }

            return returnList;
        }

        /// <summary>
        /// Searches for bookings given name of client and date.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <returns>A list of bookings that match the search.</returns>
        public List<Booking> SearchBookings(string? name, DateTime? date){


            string dateRequest = string.Empty;
            if(date != null){
                DateTime newDate = (DateTime)date;
                dateRequest = newDate.Year.ToString() + "-" + newDate.Month.ToString("00") + "-" + newDate.Day.ToString("00");
            }



            var request = new RestRequest("Bookings", Method.Get);

            request.AddQueryParameter("searchName", name);

            request.AddQueryParameter("searchDate", dateRequest);

            var response = _client!.ExecuteRequest<List<BookingBusinessModel>>(request);

            List<Booking> returnList = new List<Booking>();

            foreach(var bookingBusinessModel in response){
                Booking returnBooking = new Booking(bookingBusinessModel);
                returnList.Add(returnBooking);
            }

            return returnList;
        }

        /// <summary>
        /// Deletes a booking.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A boolean to confirm if the booking has been deleted.</returns>
        public bool DeleteBooking(string id, string token){

    

                var request = new RestRequest(

                "Bookings/" + id, Method.Delete).AddHeader("Auth", token);


                var response = _client!.ExecuteRequest<JsonObject>(request);


                return true;



        }

    
        public void Dispose() {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }

}

