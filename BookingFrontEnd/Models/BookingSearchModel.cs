using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace BookingFrontEnd.Models;


public class BookingSearchModel{

    [BindProperty(SupportsGet = true)]
    public string? Name { get; set; }
    [BindProperty(SupportsGet = true)]
    public DateTime? Date { get; set; }

    public List<Booking> BookingList { get; set; }

    public BookingSearchModel(){
        BookingList = new List<Booking>();
        Name = null;
        Date = null;
    }
    

    public BookingSearchModel(string? name, DateTime? date, List<Booking> bookingList){
        Name = name;
        Date = date;
        BookingList = bookingList;
    }

}