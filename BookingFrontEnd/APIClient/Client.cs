using System.Text.Json.Nodes;
using BookingFrontEnd.Models;
using RestSharp;

public class Client : IClient, IDisposable
    {
        private RestClient RestClient  {get; set;}

        public Client()

        {

            //RestClient = new RestClient("http://localhost:3000/");
            RestClient = new RestClient("https://bookingapi-1ymq.onrender.com/");

        }



        public T ExecuteRequest<T>(RestRequest restRequest)

        {

            var restResponse = RestClient.Execute<T>(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK || restResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return restResponse.Data!;

            }
            else if (restResponse.StatusCode == System.Net.HttpStatusCode.Conflict){
                throw new ConflictingException("This data conflicts with that in the database");
            }

            // else if (restResponse.StatusCode == System.Net.HttpStatusCode.NotFound)

            // {

            //     throw new EntityNotFoundException();

            // }

            // else if (restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)

            // {

            //     throw new DataStoreException();

            // }

            // else if (restResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)

            // {

            //     throw new InternalServerErrorException();

            // }

            else

            {

                throw new Exception("An unexpected error has occurred, please try again and hope something better happens.");

            }

        }




        public void Dispose() {
        RestClient?.Dispose();
        GC.SuppressFinalize(this);
    }

        
    }