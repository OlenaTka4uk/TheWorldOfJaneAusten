using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistense.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(40);

            builder
                .Property(x => x.Year)
                .IsRequired();

            builder
                .HasData
                (
                    new Book
                    {
                        Id = 1,
                        Title = "Sense and Sensibility",
                        Year = 1811,
                        Description = "This is the first novel by Jane Austen"
                    },

                    new Book
                    { 
                        Id = 2,
                        Title = "Pride and Prejudice",
                        Year = 1813,
                        Description = "This is a novel of manners"
                    },

                    new Book
                    {
                        Id = 3,
                        Title = "Mansfield Park",
                        Year = 1814,
                        Description = "The novel tells the story of Fanny Price, starting when her overburnered family sends her at the age of ten" +
                        "to live in the household of her wealthy aunt and uncle."
                    },

                    new Book
                    {
                        Id = 4,
                        Title = "Emma",
                        Year = 1816,
                        Description = "This is a novel of manners."
                    },

                    new Book
                    { 
                        Id = 5,
                        Title = "Northanger Abbey",
                        Year = 1818,
                        Description = "This is a coming-of-age novel and a satire of Gothic novels."
                    },

                    new Book
                    { 
                        Id = 6,
                        Title = "Persuasion",
                        Year = 1818,
                        Description = "The story concerns Anne Elliot, an Englishwoman of 27 years, whose family moves to lower their home to an admiral and his wife."
                    },

                    new Book
                    {
                        Id = 7,
                        Title = "Lady Susan",
                        Year = 1871,
                        Description = "This is an epistolary novella."
                    }

                );

        }
    }
}
