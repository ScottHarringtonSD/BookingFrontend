using BookingFrontEnd.Models;

public interface IClient{

    public Task<Booking> GetBooking(string Id);

}