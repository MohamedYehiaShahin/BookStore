﻿
using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }


        public string FullName { get; set; }

        public List<Book> BookList { get; set; }

    }
}
