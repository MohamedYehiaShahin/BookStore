using BookStore.Data.Entities;
using BookStore.Repositories.Interfaces;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookStoreRepository<AuthorViewModel,Author> _authorRepository;

        public AuthorController(IBookStoreRepository<AuthorViewModel,Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        // GET: AuthorController
        public ActionResult Index()
        {
            var AuthorsList = _authorRepository.Retrive();
            return View(AuthorsList);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var author = _authorRepository.GetById(id);
            return View(author);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorViewModel author)
        {
            try
            {
                _authorRepository.Create(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = _authorRepository.GetById(id);   
            return View(author);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorViewModel author)
        {
            try
            {
                _authorRepository.Update(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = _authorRepository.GetById(id);
            return View(author);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,AuthorViewModel author)
        {
            try
            {
                _authorRepository.Delete(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
