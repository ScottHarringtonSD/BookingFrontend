using BookingFrontEnd.Models;

public interface ILoginClient
{
    public string Login(Credentials credentials);
}