using Final_project.Context;
using Final_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Controllers
{
    public class UserController : Controller
    {
        MyContext db = new MyContext();
        /*-------------------------------------------*/

        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            // إذا كان هناك بيانات تحتاجين إلى عرضها (مثل قائمة بالخيارات)، يمكنك استخدام ViewBag هنا
            return View();
        }
        /*---------------------------------------------*/

        // POST: Register
        [HttpPost]
        public IActionResult Register(User user)
        {
            //ModelState.Remove("PasswordConfirmation"); // على افتراض أنك تريدين إزالة التحقق من الحقول إذا كان موجودًا

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "please ,All fields are required");
                // يمكنك استخدام ViewBag لإعادة تمرير البيانات إلى الـ View إذا لزم الأمر
                // return View();
                return View(user);
            }
            // Check if the email is already used
            var existingUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "This email is already registered.");
                return View(user);
            }

            db.Users.Add(user);  // إضافة المستخدم الجديد إلى قاعدة البيانات
            db.SaveChanges();    // حفظ التغييرات

            return RedirectToAction("Login");  // إعادة توجيه المستخدم إلى صفحة تسجيل الدخول بعد التسجيل الناجح
        }
        /*--------------------------------------------------------------------------------------*/
        
  


        /*-------------------------------------------------------------------------------*/
        //// GET: Login
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //// POST: Login
        //[HttpPost]
        //public IActionResult Login(User model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ModelState.AddModelError("", "Invalid login attempt.");
        //        return View(model);
        //    }

        //    var user = db.Users
        //        .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "Invalid email or password.");
        //        return View(model);
        //    }

        //    // You may want to add authentication logic here

        //    return RedirectToAction("Index"); // Redirect to home or dashboard after successful login
        //}





        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        // POST: Login
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            // Validate user credentials
            var user = db.Users
                .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            // You may want to add authentication logic here

            return RedirectToAction("Index", "Products"); // Redirect to products page after successful login
        }


    }
}
