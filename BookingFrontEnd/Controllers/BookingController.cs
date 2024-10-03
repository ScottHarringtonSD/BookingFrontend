using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookingFrontEnd.Models;
using RestSharp;
using Microsoft.Extensions.WebEncoders.Testing;


namespace BookingFrontEnd.Controllers;

public class BookingController : Controller
{
    private readonly IClient _client;

    public BookingController(IClient client, ILogger<HomeController> logger)
    {
        _client = client;
        _logger = logger;
    }

    private readonly ILogger<HomeController> _logger;



    //Remeber its controller/action/parameter as the strucuture.    
    public IActionResult BookingDetail(string id){

        Booking returnBooking = _client.GetBooking(id).Result;

        return View(returnBooking);

    }


    public IActionResult BookingSearch(){
        return View();
    }

    public IActionResult BookingSearchResults(string search){

        DateOnly testDate = DateOnly.Parse("12-12-2000");
        Booking example = new Booking("id","test", "testt", testDate);

        List<Booking> bookingList = new List<Booking>();

        bookingList.Add(example);
        return PartialView("_BookingSearch", bookingList);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
