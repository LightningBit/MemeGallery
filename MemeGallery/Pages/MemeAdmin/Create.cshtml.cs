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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]

        public Meme Meme { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        //return action handler tp support post
        public async Task<IActionResult> OnPost()
        {
            //check for vaid input return null to page 
            //if(Meme.Category == Meme.Rank.ToString())
            //{
            //    ModelState.AddModelError("Meme.Category", "The Rank can not match the Name.");
            //}


            if(ModelState.IsValid)
            {
                await _db.Meme.AddAsync(Meme);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
