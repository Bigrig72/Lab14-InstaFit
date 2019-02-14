using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaFit.Models;
using InstaFit.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstaFit.Pages.FitnessPosts
{
    public class ManageModel : PageModel
    {
        private readonly IFit _fitnessPost;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public FitnessPost FitnessPost { get; set; }

        public ManageModel(IFit fitnessPost)
        {
            _fitnessPost = fitnessPost;
        }


        public async Task OnGet()
        {
            FitnessPost = await _fitnessPost.FindFitnessPost(ID.GetValueOrDefault()) ?? new FitnessPost();
        }
        public async Task<IActionResult> OnPost()
        {
            var post = await _fitnessPost.FindFitnessPost(ID.GetValueOrDefault()) ?? new FitnessPost();

            post.Description = FitnessPost.Description;
            post.Location = FitnessPost.Location;

            await _fitnessPost.SaveAsync(post);

            return RedirectToPage("/FitnessPosts/Index", new { id = post.ID });
        }
        public async Task<IActionResult> OnPostDelete()
        {
            await _fitnessPost.DeleteAsync(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}