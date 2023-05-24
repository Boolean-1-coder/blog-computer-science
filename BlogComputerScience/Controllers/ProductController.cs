               using Microsoft.AspNetCore.Mvc;

using BlogComputerScience.Database;
using BlogComputerScience.Models;

namespace BlogComputerScience.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> productList = new List<Product>();
             
            using (BlogContext db = new BlogContext())
            {

                productList = db.Products.OrderBy(p => p.Ranking).ToList();


            }

            return View("Index", productList);
        }

        public IActionResult Details(int id)
        {
            using (BlogContext db = new BlogContext())
            {
                Product? ProductDetails = db.Products.Where(product => product.Id == id).FirstOrDefault();
                if(ProductDetails != null)
                {
                    return View("Details", ProductDetails);
                }
                
            }

			return NotFound($"l'articolo con in {id} non  è stato trovato!");

		}
            


         [HttpGet]
         public IActionResult Create()
            {
                return View("Create");
            }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product NewProduct)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", NewProduct);
            }

            using(BlogContext db = new BlogContext())
            {
                db.Products.Add(NewProduct);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using(BlogContext db = new BlogContext())
            {
                Product? productToEdit = db.Products.Where(product => product.Id == id).FirstOrDefault();
                if(productToEdit == null)
                {
                    return NotFound("Il prodotto non è stato trovato");
                } else
                {
                    return View(productToEdit);
                }
            }
        }

        [HttpPost]      
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Product updatedProduct)
        {
            if(!ModelState.IsValid)
            {
                return View("Create", updatedProduct);
            } else
            {
                using(BlogContext db = new BlogContext())
                {   

                    Product? productToUpdate = db.Products.Where(product => product.Id == id).FirstOrDefault();
                    if(productToUpdate == null)
                    {
                        return NotFound("Il prodotto non è stato trovato");
                    } else
                    {
                        productToUpdate.Name = updatedProduct.Name;
                        productToUpdate.Description = updatedProduct.Description;
                        productToUpdate.ImgUrl = updatedProduct.ImgUrl;
                        productToUpdate.Ranking = updatedProduct.Ranking;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                   
                    
                                      
                }
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (BlogContext db = new BlogContext()) 
            {
                Product? ProductToDelete = db.Products.Where(product => product.Id == id).FirstOrDefault();

                    if (ProductToDelete != null)
                    {
                        db.Remove(ProductToDelete);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound("Il prodotto non è stato trovato");
                    }
             }
        }
       



    }
}
