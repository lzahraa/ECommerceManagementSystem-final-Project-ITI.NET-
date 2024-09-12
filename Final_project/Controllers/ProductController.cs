using Final_project.Context;
using Final_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Controllers
{
    public class ProductController : Controller
    {
        /*---------------------------------------------------------*/
        MyContext db = new MyContext();
        /*---------------------------------------------------------*/
        // Index - List of all Products
        [HttpGet]
        public IActionResult Index()
        {
            var _Products = db.Products.Include(pro => pro.Category);
            // View Model To Pass Data To View
            return View(_Products);
        }
        /*----------------------------------------------*/
        // View Details
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            // note : var _Product = db.Products.Include(e => e.Category).FirstOrDefault(emp => emp.CategoryId == id); 
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Product);
        }

        /*---------------------------------------------------------*/
        // create a new product
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");

            return View();
        }
        /*---------------------------------------------------------*/   
        [HttpPost]
        public async Task<IActionResult> Create(Product prod, IFormFile ImagePath)
        {
            // make the error query doesn't go to the sql.
            ModelState.Remove("Category"); // Don't check the Category property if it's null
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please fill out all required fields.");
                ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
                return View(prod);
            }

            if (ImagePath != null && ImagePath.Length > 0)
            {
                var fileName = Path.GetFileName(ImagePath.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImagePath.CopyToAsync(stream);
                }

                prod.ImagePath = fileName; // Save the file name to the ImagePath property
            }

            db.Products.Add(prod);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }

        /*---------------------------------------------------------*/
     
        /*---------------------------------------------------------*/
        //editing an existing Product
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _product = db.Products.Include(pro => pro.Category).FirstOrDefault(p => p.ProductId == id);
            if (_product == null)
            {
                return RedirectToAction("Index");
            }

        
          // ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name", _product.CategoryId);
            ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View(_product); // write _product to make the Edited Product info appear
          
        }
        /*-------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(Product pr)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
                return View(pr);
            }
            db.Products.Update(pr);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }


        /*---------------------------------------------------------*/

        public IActionResult Delete(int id)
        {
            var _Product = db.Products.Find(id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }
            db.Products.Remove(_Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

