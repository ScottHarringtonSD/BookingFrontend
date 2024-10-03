namespace BookingFrontEnd.Models;

public class Booking
{
    public string Id { get; set; }

    public string Name {get; set;}

    public string Room {get; set;}
    public DateOnly Date {get; set;}

    public Booking(string id, string name, string room, DateOnly date){
        Id = id;
        Name = name;
        Room = room;
        Date = date;
    }

}