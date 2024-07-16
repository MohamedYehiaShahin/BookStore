using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Context.Configs
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Authors");

            builder.Property(x => x.FullName)
                .IsRequired().
                HasMaxLength(100);

            builder.HasData(LoadAuthors());


        }

        private List<Author> LoadAuthors()
        {
            return new List<Author>
            {
               new Author() {FullName= "Mohamed Yahia" },
                new Author() { FullName= "Ahmed Salem" },
                new Author() {FullName= "Kareem Yousef" }
            };
        }
    }
}
