using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WesternInn_TG_SA_AF.Data;
using WesternInn_TG_SA_AF.Models;

namespace WesternInn_TG_SA_AF.Pages.Guests
{
    public class IndexModel : PageModel
    {
        private readonly WesternInn_TG_SA_AF.Data.ApplicationDbContext _context;

        public IndexModel(WesternInn_TG_SA_AF.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Guest> Guest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Guest != null)
            {
                Guest = await _context.Guest.ToListAsync();
            }
        }
    }
}
