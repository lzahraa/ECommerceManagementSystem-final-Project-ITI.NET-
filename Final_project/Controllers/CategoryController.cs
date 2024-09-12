using Final_project.Context;
using Final_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_project.Controllers
{
    public class CategoryController : Controller
    {/*---------------------------------------------------------*/
        MyContext db = new MyContext();
        /*---------------------------------------------------------*/
        // Index - List of all Categories
        [HttpGet]
        public IActionResult Index()
        {
            var _Categories = db.Categories.ToList(); // Fetch all categories from the database
            return View(_Categories); // Pass the list of categories to the view
        }

        /*----------------------------------------------*/
        // View Details
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            // Fetch the specific category from the database
            var category = db.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                // If the category is not found, redirect to the index page
                return RedirectToAction("Index");
            }

            // Pass the category to the view
            return View(category);
        }

        /*---------------------------------------------------------*/
        // GET: Create Category
        [HttpGet]
        public IActionResult Create()
        {
          //  ViewBag.Categories = db.Categories.ToList();
            return View();
        }
        /*-------------------------------------*/

        // POST: Create Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            // make the error query doesn't go to the sql.
            ModelState.Remove("Product"); // Don't check the Category property if it's null
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.Categories.ToList();
            
            return View(category);
        }
        /*---------------------------------------------------------*/

        /*---------------------------------------------------------*/
        //editing an existing Category
        // GET: Edit Category
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Edit Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            // make the error query doesn't go to the sql.
            ModelState.Remove("Products"); // Don't check the Category property if it's null
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag.Categories = db.Categories.ToList();
                return View(category);
                
            }
            db.Categories.Update(category);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        /*---------------------------------------------------------*/

        public IActionResult Delete(int id)
        {
            var _Category = db.Categories.Find(id);
            if (_Category == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(_Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
