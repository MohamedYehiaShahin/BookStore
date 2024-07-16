using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public string PhotoUrl { get; set; }    
        public string DocumentUrl { get; set;}


    }
}
