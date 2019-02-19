using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InstaFit.Models;
using InstaFit.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using InstaFit.Models.utilites;
using Microsoft.WindowsAzure.Storage.Blob;

namespace InstaFit.Pages.FitnessPosts
{
    public class ManageModel : PageModel
    {
        private readonly IFit _fitnessPost;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public FitnessPost FitnessPost { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public /*Models.utilites.*/Blob BlobImage { get; set; }

        public ManageModel(IFit fitnessPost, IConfiguration configuration)
        {
            _fitnessPost = fitnessPost;
            // blob storage account to be referenced
            BlobImage = new Blob(configuration);
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

            if(Image != null)
            {
                var filepath = Path.GetTempFileName();
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                // get container
                var container = await BlobImage.GetContainer("fitness");
                // upload image
                 BlobImage.UploadFile(container, Image.FileName, filepath);

                // Get the Image that we just uploaded

                CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);

                // update the db image for the restaurant
                post.URL = blob.Uri.ToString();

            }

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