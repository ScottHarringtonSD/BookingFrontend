using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BookingFrontEnd.Models;

public class BookingAvailabilityModel{
    public int Month{ get; set; }

    public int Year{ get; set; }

    public string?[,] Availabilities { get; set; }

    public BookingAvailabilityModel(){
        Month = 0;
        Year = 0;
        Availabilities = new string?[31,2];
    }

    public BookingAvailabilityModel(int month, int year, List<Booking> bookingList){

        Month = month;
        Year = year;
        Availabilities = AvailabilityCalculator(bookingList);

    }


    private string?[,] AvailabilityCalculator(List<Booking> bookings){
        string?[,] returnArray = new string?[31,2];

            for (int i = 0; i<31; i++){
                for(int j = 0; j<2; j++){
                    returnArray[i,j] = null;
                }
            }

            int currentMonth = Month;
            int currentYear = Year;

            foreach(Booking booking in bookings)
            {
                if(booking.Date.Month == currentMonth &&
                 booking.Date.Year == currentYear){
                    if(booking.Room == "Guest"){
                        returnArray[booking.Date.Day - 1, 0] = booking.Name;
                    }
                    else{
                        returnArray[booking.Date.Day - 1, 1] = booking.Name;
                    }
                 }
            }

            return returnArray;
    }
}