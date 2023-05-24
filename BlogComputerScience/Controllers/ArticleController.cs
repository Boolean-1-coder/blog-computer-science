using BlogComputerScience.Database;
using BlogComputerScience.Models;
using BlogComputerScience.Models.ModelForViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogComputerScience.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            using (BlogContext db = new BlogContext())
            {
                List<Article> ourTecArticles = db.Articles.ToList();
                return View("Index", ourTecArticles);
            } 
        }

        public IActionResult Details(int id)
        {
            using(BlogContext db = new BlogContext())
            {
                Article? articleDetails = db.Articles.Where(article => article.Id == id).FirstOrDefault();

                if (articleDetails != null)
                {
                    return View("Details", articleDetails);
                } else
                {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");
                }
            }

        }

        [Authorize(Roles = "ADMIN")]
        // ACTIONS PER LA CREAZIONE DI UN ARTICOLO
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Create(Article newArticle)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newArticle);
            }

            using (BlogContext db = new BlogContext())
            {
                db.Articles.Add(newArticle);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        // ACTIONS PER LA MODIFICA DI UN ARTICOLO
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Update(int id)
        {
            using(BlogContext db = new BlogContext())
            {
                Article? articleToModify = db.Articles.Where(article => article.Id == id).FirstOrDefault();

                if(articleToModify != null)
                {
                    return View("Update", articleToModify);
                } else {

                    return NotFound("Articolo da modifcare inesistente!");
                }
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Update(int id, Article modifiedArticle)
        {
            if(!ModelState.IsValid)
            {
                return View("Update", modifiedArticle);
            }

            using(BlogContext db = new BlogContext())
            {
                Article? articleToModify = db.Articles.Where(article => article.Id == id).FirstOrDefault();

                if(articleToModify != null) { 
                
                    articleToModify.Title = modifiedArticle.Title;
                    articleToModify.Description = modifiedArticle.Description;
                    articleToModify.Image = modifiedArticle.Image;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                } else
                {
                    return NotFound("L'articolo da modificare non esiste!");
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            using(BlogContext db = new BlogContext())
            {
                Article? articleToDelete = db.Articles.Where(article => article.Id == id).FirstOrDefault();

                if(articleToDelete != null)
                {
                    db.Remove(articleToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                } else
                {
                    return NotFound("Non ho torvato l'articolo da eliminare");

                }
            }
        }


        public IActionResult FindArticles(string titleKeyword, int viewCount)
        {
            UserProfile connectedProfile = new UserProfile("Bryan", "Lucchetta", 26);

            using (BlogContext db = new BlogContext())
            {
                List<Article> matchTitleArticles = db.Articles.Where(article => article.Title.Contains(titleKeyword)).ToList();

                ProfileListArticles resultModel = new ProfileListArticles(connectedProfile, titleKeyword, matchTitleArticles);


                return View("SearchArticles", resultModel);
            }
        }
    }
}
