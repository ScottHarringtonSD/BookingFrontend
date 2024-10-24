using BookingFrontEnd.Models;

public interface IBookingClient{

    public Booking GetBooking(string Id);

    public string AddBooking(BookingBusinessModel booking);

    public List<Booking> GetAllBookings();

    public List<Booking> GetMonthlyBookings(int year, int month);

    public void Dispose();
}