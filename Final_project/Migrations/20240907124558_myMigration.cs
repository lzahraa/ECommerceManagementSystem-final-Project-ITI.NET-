using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final_project.Migrations
{
    /// <inheritdoc />
    public partial class myMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Products used for maintaining and improving the health and appearance of the skin", "Skin Care" },
                    { 2, " Products designed to cleanse, condition, and style hair", "Hair Care" },
                    { 3, "Items used for various office tasks and organization", "Office Supplies" },
                    { 4, "Apparel items worn for various occasions", "Clothing" },
                    { 5, "Written or printed works that are bound together", "Books" },
                    { 6, "Edible treats and drinks.", "Sweets and Beverages" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "fatma@gmail.com", "Fatma_alZahraa", "Mohamed", "123abc" },
                    { 2, "Asmaa@Yahoo.com", "Asmaa", "mahmoud", "456def" },
                    { 3, "Hana@mail.com", "Hana", "Dawood", "789ghi" },
                    { 4, "Alaa@gmail.com", "Alaa", "Ali", "101112jkl" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImagePath", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "A product used to remove dirt, oil, and impurities from the skin", "synobar-cleanser.jpg", 320m, 5, "Cleanser" },
                    { 2, 1, "A product designed to hydrate and lock in moisture for the skin.", "Moisturizer.jpg", 100m, 45, "Moisturizer" },
                    { 3, 1, "A product that protects the skin from harmful UV rays of the sun.", "Sunscreen.jpg", 490m, 18, "Sunscreen" },
                    { 4, 2, "A product used for cleaning the hair and scalp", "شامبو-بابيلز.jpg", 190m, 8, "Shampoo" },
                    { 5, 2, "A concentrated treatment used to address specific hair concerns such as frizz or dryness", "serum.jpg", 235m, 15, "Serum" },
                    { 6, 2, "A product used to moisturize and detangle the hair after shampooing.", "conditioners.jpg", 322m, 100, "Conditioner" },
                    { 7, 2, " A styling product or treatment for the hair that provides hold or hydration.", "cream.jpg", 212m, 53, "Cream" },
                    { 8, 2, "A product used to nourish and add shine to the hair.", "oil.jpg", 192m, 95, "Hair Oil" },
                    { 9, 2, "A tool used for detangling and styling hai", "comb.jpg", 422m, 45, "Comb" },
                    { 10, 3, "Writing instruments used for jotting down notes or documents.", "Pen.jpg", 10m, 10, "Pen" },
                    { 11, 3, "Books with blank or lined pages for writing and taking notes.", "NoteBook.jpg", 22m, 11, "Notebook" },
                    { 12, 3, "Compact devices used for printing documents.", "smallPrinter.jpg", 2200m, 15, "Small Printer" },
                    { 13, 3, "Devices used for performing mathematical calculations.", "Calculator.jpg", 422m, 85, "Calculator" },
                    { 14, 3, "Tools used for measuring or drawing straight lines.", "ruler.jpg", 12m, 155, "Ruler" },
                    { 15, 3, "A tool used for removing pencil marks from paper.", "eraser.jpg", 7m, 75, "Eraser" },
                    { 16, 3, "A container used to organize and carry writing instruments", "Pencil Case.jpg", 35m, 60, "Pencil Case" },
                    { 17, 4, "A garment worn on the upper body, usually with sleeves and a collar.", "Shirt.jpg", 420m, 15, "Shirt" },
                    { 18, 4, "A one-piece garment worn by women or girls, often extending from the shoulders to the knees or lower.", "dress.jpg", 675m, 16, "Dress" },
                    { 19, 4, "A garment that hangs from the waist and covers part or all of the legs.", "skirt.jpg", 450m, 20, "Skirt" },
                    { 20, 4, " Garments worn on the lower body, typically covering both legs separately.", "pants.jpg", 430m, 17, "Pants" },
                    { 21, 4, "Footwear designed to protect and provide comfort for the feet.", "shoes.jpg", 320m, 19, "Shoes" },
                    { 22, 4, " Pieces of cloth worn around the neck and Head for warmth and covering the Hair.", "khimar.jpg", 175m, 155, "khimar hijab" },
                    { 23, 4, "A loose- fitting upper garment worn by women.", "blouse.jpg", 375m, 65, " Blouse" },
                    { 24, 5, "هي رواية من تأليف الكاتب المصري عمرو عبد الحميد صدرت كنسخة أولى سنة 2010 وأعادت عصير الكتب للنشر والتوزيع إصدارها سنة 2015.", "أرض زيكولا.jpg", 100m, 25, "أرض زيكولا" },
                    { 25, 5, "كتاب جلسات نفسية يأتي ليكون رفيقك في رحلة التعامل الصحيح مع الذات، ويقدم لك الأدوات والتقنيات التي تحتاجها لفهم ومعالجة مشكلاتك النفسية بطرق إيجابية وموجهة، وتحسين التواصل مع نفسك وفهم أعمق للعواطف والأفكار التي تؤثر فيك.", "جلسات-نفسية.jpg", 80m, 35, " Psychological Sessions" },
                    { 26, 5, "حسب علم النفس هي حالة وجدانية سلوكية، معناها أن يتصرف المرء بلا اهتمام في شؤون حياته أو حتى الأحداث العامة كالسياسة وإن كان هذا في غير صالحه.", "فن اللامبالاة.jpg", 80m, 45, "فن اللامبالاة" },
                    { 27, 5, "A book about developing effective habits", "العادات.jpg", 132m, 55, "The Most Effective Atomic Habits" },
                    { 28, 5, " A book about personal finance and investing", "rich DAD poor DAD.jpg", 122m, 65, "Rich Dad Poor Dad" },
                    { 29, 5, "Magazines featuring Disney's Mickey Mouse.", "مجلة ميكي.jpg", 110m, 75, "Mickey Magazines" },
                    { 30, 5, "في كتاب رسائل من القرآن يتتبع أدهم شرقاوي بعض آيات من القرآن الكريم تشفي القلوب وتطفئ نيرانها المشتعلة من آلام الحياة وهمومها المختلفة", "رسائل من القرآن.jpg", 189m, 85, "رسائل من القرآن" },
                    { 31, 5, "يناقش الكتاب وبشكل مباشر المشاكل التي يواجهها الإنسان سواء في مواقفه اليومية، أو المشاكل الحياتية العامة", "La_Tahzan.jpg", 169m, 95, "لا تحزن" },
                    { 32, 6, "Traditional cakes prepared for the celebration of Eid.", "كحك.jpg", 689m, 55, "Eid Cake: " },
                    { 33, 6, "Simple, unflavored biscuits or cookies.", "biscutes.jpg", 150m, 35, "Plain Biscuits: " },
                    { 34, 6, "Biscuits flavored with or coated in chocolate.", "Choc.jpg", 68m, 25, "Chocolate Biscuits: " },
                    { 35, 6, "A dessert made with cream cheese, typically on a graham cracker crust.", "cheesecake.jpg", 100m, 15, "Cheesecake: " },
                    { 36, 6, "A rich chocolate cake with a gooey center.", "Molten-Chocolate-Cake.jpg", 70m, 51, "Molten Cake: " },
                    { 37, 6, " A baked good with a grid pattern, often served with toppings.", "Wafel.jpg", 80m, 58, "Waffles:" },
                    { 38, 6, "Coffee served cold with ice.", "icedcoffee.jpg", 48m, 36, "Iced Coffee: " },
                    { 39, 6, "A warm beverage made with cocoa powder and milk.", "Hot-Chocolate-3.jpg", 80m, 51, "Hot Chocolate: " },
                    { 41, 6, " A beverage made by infusing tea leaves in hot water.", "tea.jpg", 15m, 78, "Tea:" },
                    { 42, 6, " A strong, thick coffee made using finely ground coffee beans.", "Turk.jpg", 35m, 95, "Turkish Coffee:" },
                    { 43, 6, " A coffee style known for its rich and aromatic flavor.", "french cofee.jpg", 40m, 45, "French Coffee::" },
                    { 45, 6, " A beverage or flavoring made from anise seeds. ", "ينسون.jpg", 25m, 72, "Anise:" },
                    { 46, 6, "A refreshing herb used in beverages and cooking.", "Mint.jpg", 25m, 100, " Mint: :" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
