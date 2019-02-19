using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaFit.Models.Interfaces
{
    public interface IFit
    {
        // Delete the post
        Task DeleteAsync(int id);
        // Search or Find
        Task<FitnessPost> FindFitnessPost(int id);
        // Get all posts
        Task<List<FitnessPost>> GetFitnessPosts();
        // Save the post
        Task SaveAsync(FitnessPost fitnessPost);
    }
}
