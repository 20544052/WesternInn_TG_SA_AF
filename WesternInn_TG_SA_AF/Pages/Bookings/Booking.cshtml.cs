using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WesternInn_TG_SA_AF.Models;

namespace WesternInn_TG_SA_AF.Pages.Bookings
{
    [Authorize(Roles = "Guest")]

    public class BookingModel: PageModel
    {
        private readonly WesternInn_TG_SA_AF.Data.ApplicationDbContext _context;

        public BookingModel(WesternInn_TG_SA_AF.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public RoomBooking BookingInput { get; set; }
        
        // List of different bookings; for passing to the content file to display
        public IList<Booking> DiffBookings { get; set; }

        // GET: Guest/RoomBooking
        public IActionResult OnGet()
        {
            ViewData["RoomList"] = new SelectList(_context.Room, "RoomId", "RoomId");
            return Page();
        }

        public async Task<IActionResult> OnPostAysnc()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var bookingA = new SqliteParameter("roomA",BookingInput.BookingA);
            var bookingB = new SqliteParameter("roomB", BookingInput.BookingB);

            var diffBookings = _context.Booking.FromSqlRaw("select [Room].* from [Room] inner join [Booking] on "
                + "[Room].Id = [Booking].RoomId where [Booking].RoomId = @roomA and "
                + "[Room].Id no in (select [Room].Id from [Room] inner join [Booking] on "
                + "[Room].Id = [Booking].RoomId where [Booking].RoomId = @roomB)", bookingA, bookingB);

            //.Select(ro => new Room { Id = ro.Id, Level = ro.Level, BedCount = ro.BedCount, Price = ro.Price});

            DiffBookings = await diffBookings.ToListAsync();

            ViewData["RoomList"] = new SelectList(_context.Room, "RoomId", "RoomId");

            return Page();

            /*
             pulic voide OnGet()
            {
            }
            */
        }
    }
}