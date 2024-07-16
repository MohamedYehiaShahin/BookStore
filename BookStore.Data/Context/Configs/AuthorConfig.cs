using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Context.Configs
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("PK_Authors");
           
           

            builder.ToTable("Authors");

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.HasData(LoadAuthors());


        }

        private List<Author> LoadAuthors()
        {
            return new List<Author>
            {
               new Author() {Id = 1, FullName= "Mohamed Yahia" },
                new Author() {Id = 2, FullName= "Ahmed Salem" },
                new Author() {Id = 3,FullName= "Kareem Yousef" }
            };
        }
    }
}
