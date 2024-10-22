using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BookingFrontEnd.Models;

public class Booking
{
    public string Id { get; set; }

    [Required]
    [Display(Name = "Guest Name")]
    public string Name {get; set;}

    [Required]
    [Display(Name = "Room")]
    public string Room {get; set;}

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date")]
    public DateOnly Date {get; set;}

    public Booking(){
        Id = string.Empty;
        Name = string.Empty;
        Room = string.Empty;
        Date = new DateOnly();
    }

    public Booking(string id, string name, string room, DateOnly date){
        Id = id;
        Name = name;
        Room = room;
        Date = date;
    }

    public Booking(BookingBusinessModel bookingBusinessModel){
        Id = bookingBusinessModel._Id;
        Name = bookingBusinessModel.Name;
        Room = bookingBusinessModel.Room;
        Date = DateOnly.FromDateTime(bookingBusinessModel.Date);
    }

}