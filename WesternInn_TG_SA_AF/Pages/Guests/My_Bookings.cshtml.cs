using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WesternInn_TG_SA_AF.Data;
using WesternInn_TG_SA_AF.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.Sqlite;

namespace WesternInn_TG_SA_AF.Pages.Guests
{
    [Authorize(Roles = "Guests")]
    public class My_BookingsModel : PageModel
    {
        private readonly WesternInn_TG_SA_AF.Data.ApplicationDbContext _context;

        public My_BookingsModel(WesternInn_TG_SA_AF.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guest? Myself { get; set; }

        public IList<Booking> Bookings { get; set;} 

        public async Task<IActionResult> OnGetAsync(string sortOrder)
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;

            string query = "SELECT [Booking].* FROM [Booking] INNER JOIN [Guest] ON [Booking].GuestEmail = [Guest].Email WHERE [Guest].Email = @email";
            var parameter = new SqliteParameter("@email", _email);

            var bookings = _context.Booking.FromSqlRaw(query, parameter);

            

            switch (sortOrder)
            {
                case "checkIn_asc":
                    bookings = bookings.OrderBy(m => m.CheckIn);
                    break;
                case "checkIn_desc":
                    bookings = bookings.OrderByDescending(m => m.CheckIn);
                    break;
                case "cost_asc":
                    bookings = bookings.OrderBy(m => (double)m.Cost);
                    break;
                case "cost_desc":
                    bookings = bookings.OrderByDescending(m => (double)m.Cost);
                    break;
            }

            ViewData["NextCheckInOrder"] = sortOrder != "checkIn_asc" ? "checkIn_asc" : "checkIn_desc";
            ViewData["NextCostOrder"] = sortOrder != "cost_asc" ? "cost_asc" : "cost_desc";

            Bookings = await bookings.AsNoTracking().ToListAsync();

            Guest guest = await _context.Guest.FirstOrDefaultAsync(m => m.Email == _email);
             
            if (guest != null)
            {
                ViewData["ExistInDB"] = "true";
                Myself = guest;
            }
            else
            {
                ViewData["ExistInDB"] = "false";
            }

            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "checkIn_asc";
            }

            return Page();
        }

    }

}
