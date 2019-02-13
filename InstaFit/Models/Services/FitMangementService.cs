using InstaFit.Data;
using InstaFit.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaFit.Models.Services
{
    public class FitMangementService : IFit
    {
        private readonly InstaDbContext _context;

        public FitMangementService(InstaDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            FitnessPost fitnessPost = await _context.FitnessPosts.FindAsync(id);
            if(fitnessPost != null)
            {
                _context.Remove(fitnessPost);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<FitnessPost> FindFitnessPost(int id)
        {
            FitnessPost fitnessPost = await _context.FitnessPosts.FirstOrDefaultAsync(m => m.ID == id);

            return fitnessPost;
        }

        public Task<List<FitnessPost>> GetFitnessPosts()
        {
            return _context.FitnessPosts.ToListAsync();
        }

        public async Task SaveAsync(FitnessPost fitnessPost)
        {
        if (await _context.FitnessPosts.FirstOrDefaultAsync(m => m.ID == fitnessPost.ID) == null)
            {
                _context.FitnessPosts.Add(fitnessPost);
            }
            else
            {
                _context.FitnessPosts.Update(fitnessPost);
            }
            await _context.SaveChangesAsync();
        }
    }
}
