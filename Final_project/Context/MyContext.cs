using Final_project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO.Pipelines;
using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace Final_project.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2F0TJEL;Database=G5.NetITIMVCDay04;Trusted_Connection=True;Encrypt=false");
        }

        /*--------------------------------------------------------------------*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*-----------------------------------------------------*/
            // Seading
            var _Users = new List<User>
            {
                new User { UserId = 1, FirstName = "Fatma_alZahraa",LastName="Mohamed",Email="fatma@gmail.com",Password="123abc" },
                new User { UserId = 2, FirstName = "Asmaa",LastName="mahmoud",Email="Asmaa@Yahoo.com",Password="456def" },
                new User { UserId = 3, FirstName = "Hana",LastName="Dawood",Email="Hana@mail.com",Password="789ghi" },
                new User { UserId = 4, FirstName = "Alaa",LastName="Ali",Email="Alaa@gmail.com",Password="101112jkl" },
            };


            var _Categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Skin Care",Description="Products used for maintaining and improving the health and appearance of the skin" },
                new Category { CategoryId = 2, Name = "Hair Care",Description=" Products designed to cleanse, condition, and style hair" },
                new Category { CategoryId = 3, Name = "Office Supplies",Description="Items used for various office tasks and organization" },
                new Category { CategoryId = 4, Name = "Clothing",Description="Apparel items worn for various occasions" },
                new Category { CategoryId = 5, Name = "Books",Description="Written or printed works that are bound together" },
                new Category { CategoryId = 6, Name = "Sweets and Beverages",Description="Edible treats and drinks." },
            };



            var _Products = new List<Product>
            {
                new Product { ProductId = 1, Title = "Cleanser", Price = 320, Description = "A product used to remove dirt, oil, and impurities from the skin", Quantity = 5, ImagePath = "synobar-cleanser.jpg", CategoryId = 1 },
                new Product { ProductId = 2, Title = "Moisturizer", Price = 100, Description = "A product designed to hydrate and lock in moisture for the skin.", Quantity = 45, ImagePath = "Moisturizer.jpg", CategoryId = 1 },
                new Product { ProductId = 3, Title = "Sunscreen", Price = 490, Description = "A product that protects the skin from harmful UV rays of the sun.", Quantity = 18, ImagePath = "Sunscreen.jpg", CategoryId = 1 },

                new Product { ProductId = 4, Title = "Shampoo", Price = 190, Description = "A product used for cleaning the hair and scalp", Quantity = 8, ImagePath = "شامبو-بابيلز.jpg", CategoryId = 2 },
                new Product { ProductId = 5, Title = "Serum", Price = 235, Description = "A concentrated treatment used to address specific hair concerns such as frizz or dryness", Quantity = 15, ImagePath = "serum.jpg", CategoryId = 2 },
                new Product { ProductId = 6, Title = "Conditioner", Price = 322, Description = "A product used to moisturize and detangle the hair after shampooing.", Quantity = 100, ImagePath = "conditioners.jpg", CategoryId = 2 },
                new Product { ProductId = 7, Title = "Cream", Price = 212, Description = " A styling product or treatment for the hair that provides hold or hydration.", Quantity = 53, ImagePath = "cream.jpg", CategoryId = 2 },
                new Product { ProductId = 8, Title = "Hair Oil", Price = 192, Description = "A product used to nourish and add shine to the hair.", Quantity = 95, ImagePath = "oil.jpg", CategoryId = 2 },
                new Product { ProductId = 9, Title = "Comb", Price = 422, Description = "A tool used for detangling and styling hai", Quantity = 45, ImagePath = "comb.jpg", CategoryId = 2 },

                new Product { ProductId = 10, Title = "Pen", Price = 10, Description = "Writing instruments used for jotting down notes or documents.", Quantity = 10, ImagePath = "Pen.jpg", CategoryId = 3 },
                new Product { ProductId = 11, Title = "Notebook", Price = 22, Description = "Books with blank or lined pages for writing and taking notes.", Quantity = 11, ImagePath = "NoteBook.jpg", CategoryId = 3 },
                new Product { ProductId = 12, Title = "Small Printer", Price = 2200, Description = "Compact devices used for printing documents.", Quantity = 15, ImagePath = "smallPrinter.jpg", CategoryId = 3 },
                new Product { ProductId = 13, Title = "Calculator", Price = 422, Description = "Devices used for performing mathematical calculations.", Quantity = 85, ImagePath = "Calculator.jpg", CategoryId = 3 },
                new Product { ProductId = 14, Title = "Ruler", Price = 12, Description = "Tools used for measuring or drawing straight lines.", Quantity = 155, ImagePath = "ruler.jpg", CategoryId = 3 },
                new Product { ProductId = 15, Title = "Eraser", Price = 7, Description = "A tool used for removing pencil marks from paper.", Quantity = 75, ImagePath = "eraser.jpg", CategoryId = 3 },
                new Product { ProductId = 16, Title = "Pencil Case", Price = 35, Description = "A container used to organize and carry writing instruments", Quantity = 60, ImagePath = "Pencil Case.jpg", CategoryId = 3 },

                new Product { ProductId = 17, Title = "Shirt", Price = 420, Description = "A garment worn on the upper body, usually with sleeves and a collar.", Quantity = 15, ImagePath = "Shirt.jpg", CategoryId = 4 },
                new Product { ProductId = 18, Title = "Dress", Price = 675, Description = "A one-piece garment worn by women or girls, often extending from the shoulders to the knees or lower.", Quantity = 16, ImagePath = "dress.jpg", CategoryId = 4 },
                new Product { ProductId = 19, Title = "Skirt", Price = 450, Description = "A garment that hangs from the waist and covers part or all of the legs.", Quantity = 20, ImagePath = "skirt.jpg", CategoryId = 4 },
                new Product { ProductId = 20, Title = "Pants", Price = 430, Description = " Garments worn on the lower body, typically covering both legs separately.", Quantity = 17, ImagePath = "pants.jpg", CategoryId = 4 },
                new Product { ProductId = 21, Title = "Shoes", Price = 320, Description = "Footwear designed to protect and provide comfort for the feet.", Quantity = 19, ImagePath = "shoes.jpg", CategoryId = 4 },
                new Product { ProductId = 22, Title = "khimar hijab", Price = 175, Description = " Pieces of cloth worn around the neck and Head for warmth and covering the Hair.", Quantity = 155, ImagePath = "khimar.jpg", CategoryId = 4 },
                new Product { ProductId = 23, Title = " Blouse", Price = 375, Description = "A loose- fitting upper garment worn by women.", Quantity = 65, ImagePath = "blouse.jpg", CategoryId = 4 },

               new Product { ProductId = 24, Title = "أرض زيكولا", Price = 100, Description = "هي رواية من تأليف الكاتب المصري عمرو عبد الحميد صدرت كنسخة أولى سنة 2010 وأعادت عصير الكتب للنشر والتوزيع إصدارها سنة 2015.", Quantity = 25, ImagePath = "أرض زيكولا.jpg", CategoryId = 5 },
               new Product { ProductId = 25, Title = " Psychological Sessions", Price = 80, Description = "كتاب جلسات نفسية يأتي ليكون رفيقك في رحلة التعامل الصحيح مع الذات، ويقدم لك الأدوات والتقنيات التي تحتاجها لفهم ومعالجة مشكلاتك النفسية بطرق إيجابية وموجهة، وتحسين التواصل مع نفسك وفهم أعمق للعواطف والأفكار التي تؤثر فيك.", Quantity = 35, ImagePath = "جلسات-نفسية.jpg", CategoryId =5 },
               new Product { ProductId = 26, Title = "فن اللامبالاة", Price = 80, Description = "حسب علم النفس هي حالة وجدانية سلوكية، معناها أن يتصرف المرء بلا اهتمام في شؤون حياته أو حتى الأحداث العامة كالسياسة وإن كان هذا في غير صالحه.", Quantity = 45, ImagePath = "فن اللامبالاة.jpg", CategoryId = 5 },
               new Product { ProductId = 27, Title = "The Most Effective Atomic Habits", Price = 132, Description = "A book about developing effective habits", Quantity = 55, ImagePath = "العادات.jpg", CategoryId = 5 },
               new Product { ProductId = 28, Title = "Rich Dad Poor Dad", Price = 122, Description = " A book about personal finance and investing", Quantity = 65, ImagePath = "rich DAD poor DAD.jpg", CategoryId = 5 },
               new Product { ProductId = 29, Title = "Mickey Magazines", Price = 110, Description = "Magazines featuring Disney's Mickey Mouse.", Quantity = 75, ImagePath = "مجلة ميكي.jpg", CategoryId = 5 },
               new Product { ProductId = 30, Title = "رسائل من القرآن", Price = 189, Description = "في كتاب رسائل من القرآن يتتبع أدهم شرقاوي بعض آيات من القرآن الكريم تشفي القلوب وتطفئ نيرانها المشتعلة من آلام الحياة وهمومها المختلفة", Quantity = 85, ImagePath = "رسائل من القرآن.jpg", CategoryId = 5 },
               new Product { ProductId = 31, Title = "لا تحزن", Price = 169, Description = "يناقش الكتاب وبشكل مباشر المشاكل التي يواجهها الإنسان سواء في مواقفه اليومية، أو المشاكل الحياتية العامة", Quantity = 95, ImagePath = "La_Tahzan.jpg", CategoryId = 5 },

                new Product { ProductId = 32, Title = "Eid Cake: ", Price = 689, Description = "Traditional cakes prepared for the celebration of Eid.", Quantity= 55, ImagePath = "كحك.jpg",CategoryId = 6 },
                new Product { ProductId = 33, Title = "Plain Biscuits: " , Price = 150, Description = "Simple, unflavored biscuits or cookies.", Quantity= 35, ImagePath = "biscutes.jpg",CategoryId = 6 },
                new Product { ProductId = 34, Title = "Chocolate Biscuits: ",  Price = 68, Description = "Biscuits flavored with or coated in chocolate.", Quantity= 25, ImagePath = "Choc.jpg",CategoryId = 6 },
                new Product { ProductId = 35, Title = "Cheesecake: ", Price = 100, Description = "A dessert made with cream cheese, typically on a graham cracker crust.", Quantity= 15, ImagePath = "cheesecake.jpg",CategoryId = 6 },
                new Product { ProductId = 36, Title = "Molten Cake: ", Price = 70, Description = "A rich chocolate cake with a gooey center.", Quantity = 51, ImagePath = "Molten-Chocolate-Cake.jpg", CategoryId = 6 },
                new Product { ProductId = 37, Title = "Waffles:", Price = 80, Description = " A baked good with a grid pattern, often served with toppings.", Quantity = 58, ImagePath = "Wafel.jpg",CategoryId = 6 },
                new Product { ProductId = 38, Title = "Iced Coffee: ", Price = 48, Description="Coffee served cold with ice.", Quantity = 36, ImagePath = "icedcoffee.jpg", CategoryId=6 },
                new Product { ProductId = 39, Title = "Hot Chocolate: ", Price = 80,Description= "A warm beverage made with cocoa powder and milk.", Quantity =51 , ImagePath = "Hot-Chocolate-3.jpg", CategoryId=6 },
                new Product { ProductId = 41, Title = "Tea:",Price = 15,Description = " A beverage made by infusing tea leaves in hot water.", Quantity = 78, ImagePath = "tea.jpg",CategoryId = 6 },
                new Product { ProductId = 42, Title = "Turkish Coffee:",Price = 35,Description = " A strong, thick coffee made using finely ground coffee beans.", Quantity = 95, ImagePath = "Turk.jpg",CategoryId = 6 },
                new Product { ProductId = 43, Title = "French Coffee::",Price = 40,Description = " A coffee style known for its rich and aromatic flavor.", Quantity = 45, ImagePath = "french cofee.jpg",CategoryId = 6 },
                new Product { ProductId = 45, Title = "Anise:",Price = 25,Description = " A beverage or flavoring made from anise seeds. ", Quantity = 72, ImagePath = "ينسون.jpg",CategoryId = 6 },
                new Product { ProductId = 46, Title = " Mint: :",Price = 25,Description = "A refreshing herb used in beverages and cooking.", Quantity = 100, ImagePath = "Mint.jpg",CategoryId = 6 },


            };

            /*-----------------------------------------------------------------------*/
            modelBuilder.Entity<User>().HasData(_Users);
            modelBuilder.Entity<Product>().HasData(_Products);
            modelBuilder.Entity<Category>().HasData(_Categories);
        }

            /*-----------------------------------------------------------------------*/
             public virtual DbSet<User> Users { get; set; }
             public virtual DbSet<Product> Products { get; set; }
             public virtual DbSet<Category> Categories { get; set; }


    }
    }

