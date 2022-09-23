using FirstRealApp.Models.PoodleEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FirstRealApp.Models
{

    
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Poodle>? Poodles { get; set; }

        public DbSet<PoodleSize>? PoodleSizes { get; set; }

        public DbSet<PoodleColor>? PoodleColors { get; set; }
        
        public DbSet<Image> Images { get; set; }









        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Image>().HasData(
                new Image() { Id =1 , Name = "Don", Url = "https://i.imgur.com/xOseBFm.jpeg", PedigreeUrl = "https://i.imgur.com/buICnwV.png" },
                new Image() { Id = 4, Name = "Sosa", Url= "https://i.imgur.com/nuBvd3X.jpeg", PedigreeUrl = "https://i.imgur.com/FFnFmyy.png" },
                new Image() { Id = 2, Name = "Ruza", Url = "https://i.imgur.com/6Ll5PQL.jpeg", PedigreeUrl = "https://i.imgur.com/5wGPffP.png" },
                new Image() { Id = 3, Name = "Luna", Url= "https://i.imgur.com/QnE8Brd.jpeg", PedigreeUrl = "https://i.imgur.com/1HvFBCZ.png" },
                new Image() { Id = 5, Name = "Dolly", Url= "https://i.imgur.com/t2q0Put.jpeg", PedigreeUrl = "https://i.imgur.com/YHBaAPu.png" },
                new Image() { Id = 6, Name = "Cici", Url= "https://i.imgur.com/dWBkNFR.jpeg", PedigreeUrl = "https://i.imgur.com/P5ZegtI.png" }
                
                );

            
            
            builder.Entity<PoodleColor>().HasData(
                new PoodleColor() { Id = 1, Name = "Black" },
                new PoodleColor() { Id = 2, Name = "White" },
                new PoodleColor() { Id = 3, Name = "Brown" },
                new PoodleColor() { Id = 4, Name = "Gray" },
                new PoodleColor() { Id = 5, Name = "Apricot" },
                new PoodleColor() { Id = 6, Name = "Red" },
                new PoodleColor() { Id = 7, Name = "Black and tan" }
                );



            builder.Entity<PoodleSize>().HasData(
                new PoodleSize() { Id = 1, Name = "Toy" },
                new PoodleSize() { Id = 2, Name = "Miniature" },
                new PoodleSize() { Id = 3, Name = "Medium" },
                new PoodleSize() { Id = 4, Name = "Standard" }


                );

            builder.Entity<Poodle>().HasData(
                new Poodle() { Id = 1, Name = "Toy Love Story Don Juan", DateOfBirth = new DateTime(2020, 2, 1), GeneticTests = true, Sex="Male", PedigreeNumber = "JR 70310tp", PoodleColorId = 6, PoodleSizeId = 2, ImageId = 1 },
                new Poodle() { Id = 6, Name = "Cici", DateOfBirth = new DateTime(2020, 11, 14), GeneticTests = true, Sex = "Female", PedigreeNumber = "JR 78844", PoodleColorId = 5, PoodleSizeId = 2, ImageId = 6 },
                new Poodle() { Id = 5, Name = "Greta Garbo Von Apalusso", DateOfBirth = new DateTime(2018, 11, 4), GeneticTests = true, Sex = "Female", PedigreeNumber = "JR 82652", PoodleColorId = 5, PoodleSizeId = 2, ImageId= 5 },
                new Poodle() { Id = 2, Name = "Scarlet Rain  Von Apalusso", DateOfBirth = new DateTime(2020, 11, 3), GeneticTests = true, Sex = "Female", PedigreeNumber = "JR 78838", PoodleColorId = 6, PoodleSizeId = 1, ImageId = 2},
                new Poodle() { Id = 4, Name = "Skyler Von Apalusso", DateOfBirth = new DateTime(2020, 11, 3), GeneticTests = true, Sex = "Female", PedigreeNumber = "JR 78837", PoodleColorId = 6, PoodleSizeId = 2, ImageId =4 },
                new Poodle() { Id = 3, Name = "Loko Loko Crveni Mayestoso", DateOfBirth = new DateTime(2017, 05, 13), GeneticTests = true, Sex = "Female", PedigreeNumber = "JR 70296tp", PoodleColorId = 7, PoodleSizeId = 1, ImageId= 3 }

                );
            



            base.OnModelCreating(builder);
        }
    }
}
