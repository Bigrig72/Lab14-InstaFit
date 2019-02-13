using InstaFit.Models;
using Microsoft.EntityFrameworkCore;

namespace InstaFit.Data
{
    public class InstaDbContext : DbContext
    {
        public InstaDbContext(DbContextOptions<InstaDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FitnessPost>().HasData(
               new FitnessPost
                {
                    ID = 1,
                    Description = "This was an exhausting crossFit Workout, EMOM every minute on the minute 10 burpees 1 power clean @75%",
                    Location = "Seattle Crossfit-321 Denny Way",
                    URL = "crossfit.jpeg"
                },
               new FitnessPost
                 {
                     ID = 2,
                     Description = "Following the roots of the great Arnold doing these 3 shoulder exercises will get you there!",
                     Location = "Golds Gym-Venice Beach",
                     URL = "Bodybuilding.jpeg"
                 },
               new FitnessPost
                  {
                      ID = 3,
                      Description = "Playing tennis every sunday has kept me lean and mean",
                      Location = "Tennis courts of charleston- charleston SC",
                      URL = "Tennis.jpeg"
                  },
               new FitnessPost
                   {
                       ID = 4,
                       Description = "Starting my new journey into weight loss today- lets battle these heart conditions!!",
                       Location = "Anytime FItness- Oralndo, Fla",
                       URL = "Transformation.jpeg"
                   });
        }
        public DbSet<FitnessPost> FitnessPosts { get; set; }

    }
}
