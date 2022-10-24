using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WesternInn_TG_SA_AF.Data;
using WesternInn_TG_SA_AF.Models;
using System.Globalization;

namespace WesternInn_TG_SA_AF.Pages.Bookings
{
    public class BookingModel : PageModel
    {
        private readonly WesternInn_TG_SA_AF.Data.ApplicationDbContext _context;

        public BookingModel(WesternInn_TG_SA_AF.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id");
            ViewData["GuestEmail"] = new SelectList(_context.Guest, "Email", "FullName");
            return Page();
        }

        [BindProperty(SupportsGet = true)]
        public Booking Booking { get; set; } = default!;

        // To protect from overposting attacks, se https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid || _context.Booking == null || Booking == null)
            {
                return Page();
            }

            string _email = User.FindFirst(ClaimTypes.Name).Value;
            Booking.GuestEmail = _email;
            var theBooking = await _context.Room.Where(r => r.Id == Booking.RoomId).FirstAsync();
            DateTime a = await _context.Booking.Where(cout => cout.CheckOut);
            DateTime b;
            TimeSpan span = a.Subtract(b);
            Booking.Cost = span.Days * theBooking.Price;

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
