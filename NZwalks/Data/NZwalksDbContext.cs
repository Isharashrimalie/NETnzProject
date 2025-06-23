using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulity> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed the data for difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulity>()
            {
                new Difficulity()
                {
                    Id = Guid.Parse("2e503a55-8cd6-4002-887b-8d8d025211bf"),
                    Name = "Easy"
                },
                new Difficulity()
                {
                    Id = Guid.Parse("3535f08a-e81b-4b43-8a0a-14a525b9b9d8"),
                    Name = "Medium"
                },
                new Difficulity()
                {
                    Id = Guid.Parse("c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d"),
                    Name = "Hard"
                }
            };

            //seed the data into the Difficulties table
            modelBuilder.Entity<Difficulity>().HasData(difficulties);


            //seed the data for regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("607ebf8f-c366-44e2-b179-b013032e6d89"),
                    Code = "NI",
                    Name = "North Island",
                    RegionImageUrl = "https://example.com/north-island.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("aa4c7097-4c1b-4521-8864-2af5f4ca738d"),
                    Code = "SI",
                    Name = "South Island",
                    RegionImageUrl = "https://example.com/south-island.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("c4c75b77-ee43-4393-b1c4-c98db8052516"),
                    Code = "OT",
                    Name = "Other Island",
                    RegionImageUrl = "https://example.com/other-island.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("78220e2c-7d7b-4599-92a2-ceba96037fb7"),
                    Code = "AU",
                    Name = "Australia",
                    RegionImageUrl = "https://example.com/australia.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
