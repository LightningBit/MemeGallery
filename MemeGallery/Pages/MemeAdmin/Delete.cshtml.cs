using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MemeGallery.Data;
using MemeGallery.Model;


namespace MemeGallery.Pages.MemeAdmin
{
    //use bindProperties to create more than one Meme
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]

        public Meme Meme { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Meme = _db.Meme.Find(id);
            //Meme = _db.Meme.FirstOrDefault(u => u.Id == id);
            //Meme = _db.Meme.SingleOrDefault(u => u.Id == id;
            //Meme = _db.Meme.Where(u => u.Id == id).FirstOrDefault();

        }

        //return action handler tp support post
        public async Task<IActionResult> OnPost()
        {
            var memeFromDb = _db.Meme.Find(Meme.Id);
            if (memeFromDb != null)
            {
                _db.Meme.Remove(memeFromDb);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Meme deleted successfully";

                return RedirectToPage("Index");

            }
            return Page();

        }

    }
}
