using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class BookingAddModel{

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

    public List<string> RoomsList {get; set;}

    public enum RoomOptions{
        Guest,
        Front
    }

    public BookingAddModel(){
        Name = string.Empty;
        Room = string.Empty;
        Date = DateOnly.FromDateTime(DateTime.Now);
        RoomsList = new List<string>();
        foreach (string roomOption in Enum.GetNames(typeof(RoomOptions)))
        {   
            RoomsList.Add(roomOption);
        }
  

    }

    public BookingAddModel(string name, string room, DateOnly date){
        Name = name;
        Room = room;
        Date = date;
        RoomsList = new List<string>();
        foreach (string roomOption in Enum.GetNames(typeof(RoomOptions)))
        {   
            RoomsList.Add(roomOption);
        }
    }

    
    
}
