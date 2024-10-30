using System.Text.Json.Nodes;
using BookingFrontEnd.Models;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using RestSharp;

public class LoginClient: ILoginClient, IDisposable
{
    private readonly IClient _client;
    public LoginClient(IClient client)
    {
        _client = client;
    }

    public string Login(Credentials credentials){

        try{

                var request = new RestRequest("login", Method.Post);
                request.AddBody(credentials);


                var response = _client!.ExecuteRequest<string>(request);


                return response;

            }
            catch{
                return string.Empty;
            }

        
    }

    public void Dispose() {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }

}