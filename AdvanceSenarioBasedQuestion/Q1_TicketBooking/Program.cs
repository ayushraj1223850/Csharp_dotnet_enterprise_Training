using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    // Represents one seat in theatre/train/bus
    public class Seat
    {
        public int SeatNo { get; }
        public bool IsBooked { get; private set; }

        public Seat(int seatNo)
        {
            SeatNo = seatNo;
            IsBooked = false;
        }

        // Only Seat itself can change booking state
        public void MarkBooked()
        {
            IsBooked = true;
        }
    }

    // Booking service responsible for thread safety
    public class BookingService
    {
        private readonly Dictionary<int, Seat> _seats;

        // Lock object to synchronize access
        private readonly object _lock = new object();

        public BookingService(int totalSeats)
        {
            _seats = new Dictionary<int, Seat>();

            for (int i = 1; i <= totalSeats; i++)
            {
                _seats[i] = new Seat(i);
            }
        }

        // Thread-safe seat booking method
        public bool BookSeat(int seatNo, string userId)
        {
            lock (_lock) // Only ONE thread enters at a time
            {
                if (!_seats.ContainsKey(seatNo))
                    throw new ArgumentException("Invalid seat number");

                Seat seat = _seats[seatNo];

                if (seat.IsBooked)
                {
                    Console.WriteLine($"User {userId} failed to book Seat {seatNo}");
                    return false;
                }

                // Book the seat safely
                seat.MarkBooked();
                Console.WriteLine($"User {userId} successfully booked Seat {seatNo}");
                return true;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            BookingService service = new BookingService(totalSeats: 5);

            // Simulating multiple users booking SAME seat concurrently
            Task[] users =
            {
                Task.Run(() => service.BookSeat(1, "UserA")),
                Task.Run(() => service.BookSeat(1, "UserB")),
                Task.Run(() => service.BookSeat(1, "UserC")),
                Task.Run(() => service.BookSeat(1, "UserD"))
            };

            Task.WaitAll(users);

            Console.WriteLine("\nBooking completed safely.");
        }
    }
}
