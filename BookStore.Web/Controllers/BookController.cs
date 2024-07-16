using BookStore.Data.Entities;
using BookStore.Repositories.Interfaces;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.Utilities.Helper;

namespace BookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookStoreRepository<BookViewModel,Book> _bookRepository;
        private readonly IBookStoreRepository<AuthorViewModel,Author> _authorRepository;
        private readonly IBookRepository _forOnlyBookRepository;
        public BookController(IBookStoreRepository<BookViewModel,Book> bookRepository,
            IBookStoreRepository<AuthorViewModel,Author> authorRepository,
            IBookRepository forOnlyBookRepository)    
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _forOnlyBookRepository = forOnlyBookRepository;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var BookList = _bookRepository.Retrive();
            return View(BookList);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var bookVM = _bookRepository.GetById(id);
            bookVM.Author = _authorRepository.GetEntityById(bookVM.AuthorId);
            return View(bookVM);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var Authors = FillSelectList();
            ViewBag.AuthorsList = new SelectList(Authors, "Id", "FullName");
            //var bookVM = new BookViewModel()
            //{
            //    Authors = FillSelectList()
            //};

            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookVM)
        {
            try
            {   
                var bookSelectVM = new BookViewModel()
                {Authors = FillSelectList()};
                ViewBag.AuthorsList = new SelectList(bookSelectVM.Authors, "Id", "FullName");

                if (bookVM.AuthorId == -1)
                {
                    ViewBag.message = "Please Select An Author";
                    bookVM.Authors = bookSelectVM.Authors;
                    return View(bookVM);
                }
                _bookRepository.Create(bookVM);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(bookVM);
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {

            var bookVM = _bookRepository.GetById(id);
            bookVM.Authors = FillSelectList();
            ViewBag.AuthorsList = new SelectList(bookVM.Authors,"Id","FullName");
            return View(bookVM);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookViewModel bookVM)
         {
            try
            {
              
                _bookRepository.Update(bookVM);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var bookVM = _bookRepository.GetById(id);
            return View(bookVM);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BookViewModel bookVM)
        {
            try
            {
                _bookRepository.Delete(bookVM);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string term)
        {
            var result = _forOnlyBookRepository.Search(term);
            return View("Index", result);
        }

        private List<Author> FillSelectList()
        {
           var Authors =  _authorRepository.Retrive()
                .Select(x=> new Author 
                { 
                    Id = x.Id,
                    FullName = x.FullName
                }).ToList();
            Authors.Insert(0, new Author
            { 
                Id = -1, 
                FullName = "--- Please Select An Author ---"
            });

            return Authors;
        }
    }
}
