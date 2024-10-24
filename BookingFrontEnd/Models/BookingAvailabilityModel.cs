using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BookingFrontEnd.Models;

public class BookingAvailabilityModel{
    public int Month{ get; set; }

    public int Year{ get; set; }

    public int[,] Availabilities { get; set; }

    public BookingAvailabilityModel(){
        Month = 0;
        Year = 0;
        Availabilities = new int[31,2];
    }

    public BookingAvailabilityModel(int month, int year, List<Booking> bookingList){

        Month = month;
        Year = year;
        Availabilities = AvailabilityCalculator(bookingList);

    }


    private int[,] AvailabilityCalculator(List<Booking> bookings){
        int[,] returnArray = new int[31,2];

            for (int i = 0; i<31; i++){
                for(int j = 0; j<2; j++){
                    returnArray[i,j] = 0;
                }
            }

            int currentMonth = Month;
            int currentYear = Year;

            foreach(Booking booking in bookings)
            {
                if(booking.Date.Month == currentMonth &&
                 booking.Date.Year == currentYear){
                    if(booking.Room == "Guest"){
                        returnArray[booking.Date.Day - 1, 0] = 1;
                    }
                    else{
                        returnArray[booking.Date.Day - 1, 1] = 1;
                    }
                 }
            }

            return returnArray;
    }
}