using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemeGallery.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MemeGallery.Model;
using Microsoft.AspNetCore.Authorization;



namespace MemeGallery.Pages.MemeAdmin
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //_db used to call entity frame work DB categories

        public IEnumerable<Meme> Categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Meme;
        }

    }
}
