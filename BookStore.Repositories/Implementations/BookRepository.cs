using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.Repositories.Interfaces;
using BookStore.Utilities.Helper;
using BookStore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.Implementations
{
    public class BookRepository : IBookStoreRepository<BookViewModel,Book>,IBookRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public BookRepository(IMapper mapper,ApplicationDbContext context)
        {
            _mapper = mapper;
           _context = context;
        }

        public void Create(BookViewModel entity)
        {
            //entity.Id= Books.Max(x => x.Id)+1;
            using(_context) 
            {
                var book = _mapper.Map<Book>(entity);
                book.DocumentUrl = UploadFileHelper.SaveFile(entity.DocumentFile, "Docs");
                book.PhotoUrl = UploadFileHelper.SaveFile(entity.PHotoFile, "Photos");
                _context.Add(book);
                _context.SaveChanges();
            }
            
        }

        public void Delete(BookViewModel entity)
        {
            using(_context) 
            {
                var book = _context.Books.FirstOrDefault(x => x.Id == entity.Id);
                _context.Books.Remove(book);
                _context.SaveChanges();
            }  
        }

        public BookViewModel GetById(int id)
        {
                var book = _context.Books.SingleOrDefault(x => x.Id == id);
                var bookViewModel = _mapper.Map<BookViewModel>(book);
                return bookViewModel;        
        }

        public Book GetEntityById(int id)
        {
            var bookVm = GetById(id);
            var book = _mapper.Map<Book>(bookVm);
            return book;
        }

        public IList<BookViewModel> Retrive()
        {
           
            var BooksVMList =  _context.Books.Select(x => new BookViewModel {Id =  x.Id, Title = x.Title, Description = x.Description,AuthorId = x.AuthorId, Author = x.Author,DocumentUrl = x.DocumentUrl,PhotoUrl=x.PhotoUrl});
            return BooksVMList.ToList();
            
        }

        public List<BookViewModel> Search(string term)
        {
            var result = _context.Books.Include(x => x.Author)
                .Where(b => b.Title.Contains(term)
                || b.Description.Contains(term)
                || b.Author.FullName.Contains(term)).ToList();
            var ResultDto = _mapper.Map<List<BookViewModel>>(result);
            return ResultDto;
        }

        public void Update(BookViewModel entity)
        {
            //var bookToDelete = GetEntityById(entity.Id);
            var BookToUpdate = _mapper.Map<Book>(entity);

            UploadFileHelper.DeleteFile("Photos/", BookToUpdate.PhotoUrl);
            UploadFileHelper.DeleteFile("Docs/", BookToUpdate.DocumentUrl);

            using (_context)
            {
                //var BookToUpdate = _context.Books.SingleOrDefault(x => x.Id == entity.Id);
                BookToUpdate.DocumentUrl = UploadFileHelper.SaveFile(entity.DocumentFile, "Docs");
                BookToUpdate.PhotoUrl = UploadFileHelper.SaveFile(entity.PHotoFile, "Photos");
                _context.Entry(BookToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
