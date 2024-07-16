using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.Repositories.Interfaces;
using BookStore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.Implementations
{
    public class AuthorRepository : IBookStoreRepository<AuthorViewModel,Author>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public AuthorRepository(IMapper mapper,
            ApplicationDbContext context) {
            _mapper = mapper;
            _context = context;
            
        }

        public void Create(AuthorViewModel entity)
        {
            using(_context)
            {
                //entity.Id = _context.Authors.Max(x => x.Id)+1;
                var Author = _mapper.Map<Author>(entity);
                _context.Add(Author);
                _context.SaveChanges();
            }
            
            
        }

        public void Delete(AuthorViewModel entity)
        {
            using(_context)
            {
                var author = _context.Authors.FirstOrDefault(x => x.Id == entity.Id);
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            
        }

        public AuthorViewModel GetById(int id)
        {
          
                var author = _context.Authors.SingleOrDefault(x => x.Id == id);
                var authorVM = _mapper.Map<AuthorViewModel>(author);
                return authorVM;  
            
        }

        public IList<AuthorViewModel> Retrive()
        {
            
            var AuthorVMList =  _context.Authors.Select(x=>new AuthorViewModel() { Id = x.Id, FullName = x.FullName});

            return AuthorVMList.ToList();
        }

        public void Update(AuthorViewModel entity)
        {
            using (_context)
            {
                var author = _mapper.Map<Author>(entity);
                _context.Entry(author).State = EntityState.Modified;
                _context.SaveChanges();
            }

        }

        public Author GetEntityById(int id)
        {
           
                var authorVM = GetById(id);
                var author = _mapper.Map<Author>(authorVM);
                return author;
            
            
        }
    }
}
