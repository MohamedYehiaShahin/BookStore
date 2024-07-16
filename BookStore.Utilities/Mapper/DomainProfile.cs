using AutoMapper;
using BookStore.Data.Entities;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utilities.Mapper
{
    public class DomainProfile :Profile
    {
        public DomainProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel, Book>();

            CreateMap<Author, AuthorViewModel>();
            CreateMap<AuthorViewModel, Author>();

        }
    }
}
