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
        public IList<Booking> Bookings { get; set; }

        // GET: Guest/RoomBooking
        public IActionResult OnGet()
        {
            ViewData["GuestList"] = new SelectList(_context.Guest, "Email", "FullName");
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
        }
    }
}