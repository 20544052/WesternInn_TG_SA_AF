using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WesternInn_TG_SA_AF.Data;
using WesternInn_TG_SA_AF.Models;

namespace WesternInn_TG_SA_AF.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly WesternInn_TG_SA_AF.Data.ApplicationDbContext _context;

        public DetailsModel(WesternInn_TG_SA_AF.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            else 
            {
                Room = room;
            }
            return Page();
        }
    }
}
