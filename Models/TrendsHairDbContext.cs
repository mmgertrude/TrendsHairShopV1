
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TrendsHairShop.Models
{
    public class TrendsHairDbContext : IdentityDbContext<IdentityUser>
    {
        public TrendsHairDbContext(DbContextOptions<TrendsHairDbContext> options) : base(options)
        {

        }
        //entities that DbContext will manage
        public DbSet<Hair> HairPieces { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        //sdfghjklølkjhgfddfuioiufdsdfghjkløkjhgfghj
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Curly" , Description ="Hair with curles"});
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "straight", Description ="straight hair" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "wavy", Description ="Hair with waves" });

            //seed pies

            modelBuilder.Entity<Hair>().HasData(new Hair
            {
                HairId = 1,
                Name = "Afro Kinky tight curles",
                Price = 12.95M,
                ShortDescription = "Gives a kinky afro. Crotchet hair",
                LongDescription = "The tight spiral curls in this look are perfect for a girl looking for a more polished look.Even better, you don’t have to deal with all the time it takes to curl hair in the morning!",
                CategoryId = 1,
                ImageUrl =  "https://www.styleinterest.com/wp-content/uploads/2016/02/4120416-crochet-braids-hairstyles-.png",
                //ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
                InStock = true,
                IsHairOfTheWeek = true,
                ImageThumbnailUrl =  "https://www.styleinterest.com/wp-content/uploads/2016/02/4120416-crochet-braids-hairstyles-.png",

                //ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg"
                 
            });

            modelBuilder.Entity<Hair>().HasData(new Hair
            {
                HairId = 2,
                Name = "Afro Kinky Straight",
                Price = 18.95M,
                ShortDescription = "You'll love it!",
                LongDescription ="lovely straight kinky to mimic the look of a blown-out head full of natural hair",
                    //"Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 2,
                ImageUrl = "https://ae01.alicdn.com/kf/HTB1hnlBbaL7gK0jSZFBq6xZZpXau/Ali-Julia-Hair-Afro-Kinky-Straight-Hair-360-Lace-Front-Wig-Brazilian-Remy-Human-Hair-Wigs.jpg_q50.jpg",
                //"https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg",
                InStock = true,
                IsHairOfTheWeek = true,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/HTB1hnlBbaL7gK0jSZFBq6xZZpXau/Ali-Julia-Hair-Afro-Kinky-Straight-Hair-360-Lace-Front-Wig-Brazilian-Remy-Human-Hair-Wigs.jpg_q50.jpg",

               // ImageThumbnailUrl ="https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecakesmall.jpg"
            });

            modelBuilder.Entity<Hair>().HasData(new Hair
            {
                HairId = 3,
                Name = "Angle waves",
                Price = 18.95M,
                ShortDescription = "beautiful wavy hair weave",
                LongDescription = "Loose Wave Hair Extensions Wavy Weave Wefts. fdfdfdsffdffdffdfdfdfdfdfdf sdjflkdjfkdfkdjfkd fdfdfdsffdffdffdfdfdfdfdfdf sdjflkdjfkdfkdjfkd fdfdfdsffdf sdjflkdjfkdfkdjfkd fdfdfdsffdf",
                    //"Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 3,
                ImageUrl = "https://www.dhresource.com/0x0/f2/albu/g8/M00/0F/F5/rBVaV1xMFv6AScriAAKjDa1r1ro271.jpg/unice-kinky-curly-bulks-women-afro-loose.jpg",
                //"https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg",
                InStock = true,
                IsHairOfTheWeek = false,
                ImageThumbnailUrl = "https://www.dhresource.com/0x0/f2/albu/g8/M00/0F/F5/rBVaV1xMFv6AScriAAKjDa1r1ro271.jpg/unice-kinky-curly-bulks-women-afro-loose.jpg",

                //ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg"
                
            });
        }
    }
}