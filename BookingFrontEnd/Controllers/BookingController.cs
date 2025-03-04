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



    /// <summary>
    /// Gets the details of the boooking
    /// </summary>
    /// <param name="id">The id of the booking</param>
    /// <returns>The booking detail page.</returns>
    [HttpGet]  
    public IActionResult BookingDetail(string id){
        try{

        Booking returnBooking = _bookingClient.GetBooking(id);

        return View(returnBooking);
        }
        catch{
            TempData["Error"] = "Sorry, something unexpectedly went wrong. Please try again, it (probably) won't happen twice.";
            return RedirectToAction("Index", "Home"); 
        }

    }

    [HttpGet]
    public IActionResult BookingAdd(){
        try{
        return View(new BookingAddModel());
        }
        catch{
            TempData["Error"] = "Sorry, something unexpectedly went wrong. Please try again, it (probably) won't happen twice.";
            return RedirectToAction("Index", "Home"); 
        }
    }

    /// <summary>
    /// Method for adding a booking.
    /// </summary>
    /// <param name="booking">The booking being added.</param>
    /// <returns>A success message.</returns>
    [HttpPost]
    public IActionResult BookingAdd(BookingAddModel booking){
        try{

        string returnString = _bookingClient.AddBooking(new BookingBusinessModel(booking));

        return RedirectToAction("BookingDetail", new { id = returnString});
        }
        catch(ConflictingException){
            TempData["Message"] = "Error: This room is already booked on this day. Please try a different room or a different day!";
            return View(booking);
        }
        catch{
            TempData["Error"] = "Sorry, something unexpectedly went wrong. Please try again, it (probably) won't happen twice.";
            return RedirectToAction("Index", "Home"); 
        }
    }

    /// <summary>
    /// Gets the availability.
    /// </summary>
    /// <param name="year">The year</param>
    /// <param name="month">The month</param>
    /// <returns>The availability client.</returns>
    [HttpGet]
    public IActionResult BookingAvailability(int year, int month){


        try{

        List<Booking> bookingList = _bookingClient.GetMonthlyBookings(year, month);

        BookingAvailabilityModel bookingAvailability = new BookingAvailabilityModel(month,year,bookingList);
        

        return View(bookingAvailability);
        }
        catch{
            TempData["Error"] = "Sorry, something unexpectedly went wrong. Please try again, it (probably) won't happen twice.";
            return RedirectToAction("Index", "Home"); 
        }
    }

    /// <summary>
    /// A method for searching for stuff
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult BookingSearch(BookingSearchModel search){
        try{

        if(search.Name == null && search.Date == null){
            return View(new BookingSearchModel());
        }
        

        List<Booking> bookingList = _bookingClient.SearchBookings(search.Name, search.Date);

        BookingSearchModel bookingSearch = new BookingSearchModel(search.Name, search.Date, bookingList);

        return View(bookingSearch);
        }
        catch{
            TempData["Error"] = "Sorry, something unexpectedly went wrong. Please try again, it (probably) won't happen twice.";
            return RedirectToAction("Index", "Home"); 
        }
            

        
    }


    /// <summary>
    /// A method for deleting bookings.
    /// </summary>
    /// <param name="id">The id of the booking being deleted.</param>
    /// <returns>The search page.</returns>
    [HttpPost]
    public IActionResult BookingDelete(string id){
        try{
            var token = HttpContext.Request.Cookies["token"];

            if(token == null){
                throw new UnauthorisedException("You are not authorised to complete this action.");
            }

            bool result = _bookingClient.DeleteBooking(id, token);

            TempData["Message"] = "Booking Deletion Successful!";
            return RedirectToAction("BookingSearch", new { search = new BookingSearchModel()});
        }
        catch(UnauthorisedException ex){
            TempData["Error"] = "You are not authorised to delete bookings. You need to login, or maybe refresh your login.";
            return RedirectToAction("BookingDetail", new { id = id}); 
        }
        catch{
            TempData["Error"] = "This deletion failed. Not sure why. Sorry";
            return RedirectToAction("BookingDetail", new { id = id}); 
        }
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    
}
