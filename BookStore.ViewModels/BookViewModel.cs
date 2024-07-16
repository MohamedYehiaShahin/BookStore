using BookStore.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
     public class BookViewModel
    {
        
        [Display(Name = "Book Id")]
        public int Id { get; set; }

        [Required(ErrorMessage ="You Must Enter Book Name")]
        [Display(Name ="Book Name")]
        public string Title { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public List<Author> Authors { get; set; }

        public IFormFile PHotoFile { get; set; }
        public string PhotoUrl { get; set; }

        public IFormFile DocumentFile { get; set; }
        public string DocumentUrl { get; set; }
    }
}

