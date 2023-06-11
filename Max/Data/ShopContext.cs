using Max.Models;
using Microsoft.EntityFrameworkCore;

namespace Max.Data
{


    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Orderline> Orderlines { get; set; }
        public DbSet<Processor> Processors { get; set; } 
        public DbSet<Ram> Rams{ get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }

        //public DbSet<CategoryProcessor> CategoryProcessors { get; set; }    





        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Team>()
            //    .HasMany(e => e.FootballResults)
            //    .WithOne(e => e.Team2)
            //    .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Processor>()
               .HasOne(p => p.Manufacturer)
               .WithMany(b => b.Processors)
               .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder
            //    .Entity<Post>()
            //    .HasMany(p => p.Tags)
            //    .WithMany(p => p.Posts)
            //    .UsingEntity(j => j.ToTable("PostTags"));


            //modelBuilder  // Post = Proc,   Tag = Category
            //    .Entity<Processor>()
            //    .HasMany(p => p.Categories)
            //    .WithMany(p => p.Processors)
            //    .UsingEntity(j => j.ToTable("CategoryProcessor"));






            //  modelBuilder.Entity<CategoryProcessor>()
            //.HasKey(bc => new { bc.ProcessorId, bc.CategoryId });
            //  modelBuilder.Entity<CategoryProcessor>()
            //      .HasOne(bc => bc.Processor)
            //      .WithMany(b => b.ProcessorCategories)
            //      .HasForeignKey(bc => bc.ProcessorId);
            //  modelBuilder.Entity<CategoryProcessor>()
            //      .HasOne(bc => bc.Category)
            //      .WithMany(c => c.ProcessorCategories)
            //      .HasForeignKey(bc => bc.CategoryId);


            Manufacturer[] manufacturers =
            {
                new Manufacturer{Id = 1, Name = "Asus", Description="hello"},
                new Manufacturer{Id = 2, Name = "AMD", Description="hello"},
                new Manufacturer{Id = 3, Name = "Intel", Description="hello"},
                new Manufacturer{Id = 4, Name = "Nvidia", Description="hello"},
                new Manufacturer{Id = 5, Name = "Razer", Description="´sfd"},
                new Manufacturer{Id = 6, Name = "Logitech", Description="ds"},
                new Manufacturer{Id = 7, Name = "AOC", Description="d"},
                new Manufacturer{Id = 8, Name = "Coolermaster", Description="df"},
                new Manufacturer{Id = 9, Name = "KeepQuiet", Description="xcv"}

            };
            modelBuilder.Entity<Manufacturer>().HasData(manufacturers);




            Processor processor1 = new Processor();
            processor1.Id = 1;
            processor1.Name = "intel";
            processor1.Frequency = 3.5;
            processor1.Description = "cool processor";
            processor1.ManufacturerId = 3;

            Processor processor2 = new Processor
            {
                Id = 2,
                Name = "amd",
                Frequency = 2.5,
                Description = "also a cool processor",
                ManufacturerId = 2
            };

            Processor[] processors =
            {
                processor1,
                processor2
            };

            modelBuilder.Entity<Processor>().HasData(processors); // insert data to table processors



            Ram[] ram =
            {
                new Ram{Id = 3, Name = "Asus", Frequency=1, MemoryCapacity=7, Description="hello", ManufacturerId = 1},
                new Ram{Id = 4, Name = "Asus", Frequency=1, MemoryCapacity=5, Description="hello", ManufacturerId = 2}

            };
            modelBuilder.Entity<Ram>().HasData(ram);

            Category[] categories =
            {
                new Category{ Id = 1, Name = "Programmers"},
                new Category{ Id = 2, Name = "Office Workers"},
                new Category{ Id = 3, Name = "Gamers"},
                new Category{ Id = 4, Name = "Budget"}
            };
            modelBuilder.Entity<Category>().HasData(categories);         

            Order[] orders =
                {
                new Order{Id = 1, UserId = 1, CreatedDate = DateTime.Now, Total = 0},
                new Order{Id = 2, UserId = 1, CreatedDate = DateTime.MaxValue, Total = 5}

            };
            modelBuilder.Entity<Order>().HasData(orders);

            Orderline[] orderlines =
                {
                new Orderline{Id = 1, ProductId = 3, Quantity = 1, OrderId = 1},
                new Orderline{Id = 2, ProductId = 1, Quantity = 2, OrderId = 1}

            };
            modelBuilder.Entity<Orderline>().HasData(orderlines);

            Role[] roles =
                {                
                new Role{Id = 1, Name = "user"},
                new Role{Id = 2, Name = "moderator"}
            };
            modelBuilder.Entity<Role>().HasData(roles);

            User[] users =
              {
                new User{Id = 1, Name = "Maxim", Email="123@gmail.com", Password="password1", RoleId = 1},
                new User{Id = 2, Name = "AlsoMaxim", Email="345@gmail.com", Password="password2", RoleId = 2}

            };
            modelBuilder.Entity<User>().HasData(users);
        }
    }
}






// Entity Framework Core Tools for the NuGet Package Manager Console in Visual Studio.

//Enables these commonly used commands:
//Add-Migration
//Bundle-Migration
//Drop-Database
//Get-DbContext
//Get-Migration
//Optimize-DbContext
//Remove-Migration
//Scaffold-DbContext
//Script-Migration
//Update-Database