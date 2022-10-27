using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WesternInn_TG_SA_AF.Data;
using WesternInn_TG_SA_AF.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WesternInn_TG_SA_AF.Pages
{
    public class SearchRoomsModel : PageModel
    {
        private readonly WesternInn_TG_SA_AF.Data.ApplicationDbContext _context;

        public SearchRoomsModel(WesternInn_TG_SA_AF.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> Beds { get; } = new List<SelectListItem>
        { new SelectListItem { Value = "1", Text = "1 Bed" },
          new SelectListItem { Value = "2", Text = "2 Bed" },
          new SelectListItem { Value = "3", Text = "3 Bed" },
          };
        [BindProperty(SupportsGet = true)]
        public RoomViewModel RoomViewModel { get; set; } = default!;
   

        //public void OnGet()
        //{
        //}

    }
}
