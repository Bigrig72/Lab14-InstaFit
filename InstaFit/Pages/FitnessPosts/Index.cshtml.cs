using InstaFit.Models;
using InstaFit.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace InstaFit.Pages.FitnessPosts
{
    public class IndexModel : PageModel
    {
        private readonly IFit _FitnessPost;

        public IndexModel(IFit fitnessPost)
        {
            _FitnessPost = fitnessPost;
        }

        [FromRoute]
        public int ID { get; set; }
        public FitnessPost FitnessPost { get; set; }



        public async Task OnGet()
        {
            FitnessPost = await _FitnessPost.FindFitnessPost(ID);
        }
    }
}