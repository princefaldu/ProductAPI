using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApplication.Models;

namespace ProductApplication.Controllers
{
    [ApiController]
    [Route("api/products")]
        public class ProductController : Controller
        {
            private readonly ApplicationDbContext _context;

            public ProductController(ApplicationDbContext context)
            {
                _context = context;
            }

        // GET: Products
        [Route("GetAllProducts")]
        public IActionResult Index()
            {
            var products = _context.Product.ToList();
            return Ok(products);

            //    var products = _context.Products.ToList();
            //    return View(products);
            }

        // GET: Products/Details/5
        [Route("GetDetailsProductsByID/{id}")]

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Product
                .FirstOrDefault(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Route("AddNewProducts")]

        public IActionResult Create()
            {
                return View();
            }

            // POST: Products/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create([Bind("Name,Category,Description,Status")] Product product)
            {
                if (ModelState.IsValid)
                {
                    object value = _context.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }

        // GET: Products/Edit/5
        [Route("UpdateProductsByID/{id}")]
        public IActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = _context.Product.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

        //    // POST: Products/Edit/5
        //    [HttpPost]
        //[Route("UpdateProducts/{id}")]
        //[ValidateAntiForgeryToken]
        //    public IActionResult Edit(int id, [Bind("Name,Category,Description,Status")] Product product)
        //    {
        //        if (id != product.ProductId)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(product);
        //                _context.SaveChanges();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!ProductExists(product.ProductId))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(product);
        //    }

        //// GET: Products/Update/{id}
        //[HttpGet]
        //[Route("UpdateProduct/{id}")]
        //public IActionResult Update(int id)
        //{
        //    // Retrieve the existing product from the database
        //    var existingProduct = _context.Product.Find(id);

        //    if (existingProduct == null)
        //    {
        //        return NotFound(); // Product not found
        //    }

        //    return View(existingProduct); // Display the product data in an update form
        //}

        //// POST: Products/Update/{id}
        //[HttpPost]
        //[Route("UpdateProduct/{id}")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(int id, [Bind("Id,Name,Category,Description,Status")] Product updatedProduct)
        //{
        //    if (id != updatedProduct.ProductId)
        //    {
        //        return NotFound(); // Product id in URL does not match the id in the model
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Update the existing product in the database
        //            _context.Update(updatedProduct);
        //            _context.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(id))
        //            {
        //                return NotFound(); // Product not found
        //            }
        //            else
        //            {
        //                throw; // Handle any other exception that may occur during update
        //            }
        //        }

        //        return RedirectToAction(nameof(Index)); // Redirect to the product list page
        //    }

        //    return View(updatedProduct); // Redisplay the form with validation errors
        //}

        private bool ProductExists(int id)
        {
            return _context.Product.Any(p => p.ProductId == id);
        }


        // GET: Products/Delete/5
        [Route("DeleteProductsByID/{id}")]
        public IActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = _context.Product.FirstOrDefault(m => m.ProductId == id);
                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }

            // POST: Products/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {
                var product = _context.Product.Find(id);
                _context.Product.Remove(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            //private bool ProductExists(int id)
            //{
            //return _context.Product.Any(e => e.ProductId == id);
            //}
        }
    }

