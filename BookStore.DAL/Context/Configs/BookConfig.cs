using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Context.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
           builder.HasKey(x => x.Id);

            builder.ToTable("Books");

            builder.Property(x => x.Title)
                .IsRequired().
                HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(250);

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId)
                .IsRequired();

            builder.HasData(LoadBooks());


        }

        private List<Book> LoadBooks()
        {
            return new List<Book>
            {
                new Book()
                {
                    Title = "C# Programming" , Description = "no discription",AuthorId = 1,DocumentUrl="s",PhotoUrl="d"
                },
                new Book()
                {
                    Title = "Java Programming" , Description = "no data",AuthorId =2,DocumentUrl="s",PhotoUrl="d"
                },
                new Book()
                {
                    Title = "Python Programming" , Description = "nothing",AuthorId = 3,DocumentUrl="s",PhotoUrl="d"
                }
            };
        }
    }
}
