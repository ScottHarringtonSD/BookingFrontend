namespace BookingFrontEnd.Models;

public class BookingBusinessModel
{


    public string _Id { get; set; }

    public string Name {get; set;}

    public string Room {get; set;}
    public DateTime Date {get; set;}


    public BookingBusinessModel(){
        _Id = string.Empty;
        Name = string.Empty;
        Room = string.Empty;
        Date = DateTime.MinValue;
    }

    public BookingBusinessModel(string id, string name, string room, DateTime date){
        _Id = id;
        Name = name;
        Room = room;
        Date = date;
    }

    public BookingBusinessModel(Booking booking){
        _Id = booking.Id;
        Name = booking.Name;
        Room = booking.Room;
        Date = booking.Date.ToDateTime(TimeOnly.MinValue);
    }

    public BookingBusinessModel(BookingAddModel booking){
        _Id = string.Empty;
        Name = booking.Name;
        Room = booking.Room;
        Date = booking.Date.ToDateTime(TimeOnly.MinValue);
    }


}