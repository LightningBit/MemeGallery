using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MemeGallery.Data;
using MemeGallery.Model;

namespace MemeGallery.Pages.MemeAdmin
{
    public class MemeGalleryModel : PageModel
    {
        private ApplicationDbContext _context;
        public List<Meme> Meme { get; set; }
        public MemeGalleryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGet()
        {
            ViewData["SuccessMessage"] = TempData["SuccessMessage"];
            Meme = await _context.Meme.ToListAsync();
        }
    }
}
