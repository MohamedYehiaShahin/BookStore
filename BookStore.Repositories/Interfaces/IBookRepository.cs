using BookStore.Data.Entities;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.Interfaces
{
    public interface IBookRepository
    {
        List<BookViewModel> Search(string term);
    }
}
