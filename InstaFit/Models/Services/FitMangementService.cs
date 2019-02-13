using InstaFit.Data;
using InstaFit.Models.Interfaces;
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
        public Task DeleteAsync(int id)
        {
         
        }

        public Task<FitnessPost> FindFitnessPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FitnessPost>> GetFitnessPosts()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(FitnessPost fitnessPost)
        {
            throw new NotImplementedException();
        }
    }
}
