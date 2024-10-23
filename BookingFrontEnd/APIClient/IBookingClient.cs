using BookingFrontEnd.Models;

public interface IBookingClient{

    public Booking GetBooking(string Id);

    public string AddBooking(BookingBusinessModel booking);

    public List<Booking> GetAllBookings();

    public void Dispose();
}