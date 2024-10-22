using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookingFrontEnd.Models;
using RestSharp;
using Microsoft.Extensions.WebEncoders.Testing;



namespace BookingFrontEnd.Controllers;

public class BookingController : Controller
{
    private readonly IBookingClient _bookingClient;

    public BookingController(IBookingClient bookingClient, ILogger<HomeController> logger)
    {
        _bookingClient = bookingClient;
        _logger = logger;
    }

    private readonly ILogger<HomeController> _logger;



    //Remeber its controller/action/parameter as the strucuture.  
    [HttpGet]  
    public IActionResult BookingDetail(string id){

        Booking returnBooking = _bookingClient.GetBooking(id);

        return View(returnBooking);

    }

    [HttpGet]
    public IActionResult BookingAdd(){
        return View(new BookingAddModel());
    }

    /// <summary>
    /// Method for adding a booking.
    /// </summary>
    /// <param name="booking">The booking being added.</param>
    /// <returns>A success message.</returns>
    [HttpPost]
    public IActionResult BookingAdd(BookingAddModel booking){
        string returnString = _bookingClient.AddBooking(new BookingBusinessModel(booking));

        return RedirectToAction("BookingDetail", new { id = returnString});
    }

    /// <summary>
    /// A method for searching for stuff
    /// </summary>
    /// <returns></returns>
    public IActionResult BookingSearch(){
        return View();
    }

    /// <summary>
    /// gives the search results.
    /// </summary>
    /// <param name="search">The search query.</param>
    /// <returns>A view with the list of bookings.</returns>
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
