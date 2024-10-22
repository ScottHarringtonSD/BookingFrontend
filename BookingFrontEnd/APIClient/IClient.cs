using BookingFrontEnd.Models;
using RestSharp;

public interface IClient{


    public T ExecuteRequest<T>(RestRequest restRequest);

    public void Dispose();

}