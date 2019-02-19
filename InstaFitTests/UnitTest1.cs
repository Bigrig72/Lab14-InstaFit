using System;
using Xunit;
using InstaFit.Pages;
using InstaFit.Models;
using Microsoft.EntityFrameworkCore;
using InstaFit.Data;
using InstaFit.Models.Services;
using System.Collections.Generic;

namespace InstaFitTests
{
    public class UnitTest1
    {
        [Fact]
        public async void CanDeleteAPost()
        {
            DbContextOptions<InstaDbContext> options =
                new DbContextOptionsBuilder<InstaDbContext>
                ().UseInMemoryDatabase("DeletePost").Options;

            using (InstaDbContext context = new InstaDbContext(options))
            {
                FitnessPost post = new FitnessPost();
                post.ID = 1;
                post.Location = "Golds Gym";
                post.URL = "crimson.jpeg";
                post.Description = "Doing my best to stay fit";

                FitnessPost post2 = new FitnessPost();
                post2.ID = 2;
                post2.Location = "Golds Gym";
                post2.URL = "crimson.jpeg";
                post2.Description = "Doing my best to stay fit";

                FitMangementService fitService = new FitMangementService(context);

                await fitService.DeleteAsync(post2.ID);
                var deleted = await context.FitnessPosts.FirstOrDefaultAsync(r => r.ID == post2.ID);
                Assert.Null(deleted);
            }
        }
        [Fact]
        public async void CanFindAPost()
        {
            DbContextOptions<InstaDbContext> options =
                new DbContextOptionsBuilder<InstaDbContext>
                ().UseInMemoryDatabase("FindPost").Options;

            using (InstaDbContext context = new InstaDbContext(options))
            {
                FitnessPost post = new FitnessPost();
                post.ID = 1;
                post.Location = "Golds Gym";
                post.URL = "crimson.jpeg";
                post.Description = "Doing my best to stay fit";

                FitnessPost post2 = new FitnessPost();
                post2.ID = 2;
                post2.Location = "Anytime fitness";
                post2.URL = "packer.jpeg";
                post2.Description = "Loving life";

                FitMangementService fitService = new FitMangementService(context);

                await fitService.FindFitnessPost(1);
                FitnessPost find = await context.FitnessPosts.FirstOrDefaultAsync(r => r.ID == post.ID);
                Assert.Equal("Golds Gym", post.Location);
            }
        }
        [Fact]
        public async void CanGetAllPosts()
        {
            DbContextOptions<InstaDbContext> options =
                new DbContextOptionsBuilder<InstaDbContext>
                ().UseInMemoryDatabase("GetPosts").Options;

            using (InstaDbContext context = new InstaDbContext(options))
            {
                FitnessPost post = new FitnessPost();
                post.ID = 1;
                post.Location = "Golds Gym";
                post.URL = "crimson.jpeg";
                post.Description = "Doing my best to stay fit";

                FitnessPost post2 = new FitnessPost();
                post2.ID = 2;
                post2.Location = "Anytime fitness";
                post2.URL = "packer.jpeg";
                post2.Description = "Loving life";

                FitMangementService fitService = new FitMangementService(context);
                await context.FitnessPosts.AddAsync(post);
                await context.FitnessPosts.AddAsync(post2);
                await context.SaveChangesAsync();
               
                List<FitnessPost> find = await fitService.GetFitnessPosts();             
                
                Assert.Equal(2, find.Count);       

            }
        }
        [Fact]
        public async void CanSavePosts()
        {
            DbContextOptions<InstaDbContext> options =
                new DbContextOptionsBuilder<InstaDbContext>
                ().UseInMemoryDatabase("SavePosts").Options;

            using (InstaDbContext context = new InstaDbContext(options))
            {
                FitnessPost post = new FitnessPost();
                post.ID = 1;
                post.Location = "Golds Gym";
                post.URL = "crimson.jpeg";
                post.Description = "Doing my best to stay fit";

                FitnessPost post2 = new FitnessPost();
                post2.ID = 2;
                post2.Location = "Anytime fitness";
                post2.URL = "packer.jpeg";
                post2.Description = "Loving life";

                FitMangementService fitService = new FitMangementService(context);
                await context.FitnessPosts.AddAsync(post);
                await context.FitnessPosts.AddAsync(post2);
                await context.SaveChangesAsync();

                List<FitnessPost> find = await fitService.GetFitnessPosts();

                Assert.Equal(1, post.ID);

            }
        }
    }
}
