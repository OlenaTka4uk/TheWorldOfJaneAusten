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
    public class MaleCharacterConfiguration : IEntityTypeConfiguration<MaleCharacter>
    {
        public void Configure(EntityTypeBuilder<MaleCharacter> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder
                .HasData
                (
                    new MaleCharacter
                    { 
                        Id = 1,
                        BookId = 1,
                        Name = "Edward Ferras",
                        Characteristic = "The elder of Fanny Dashwood's two brothers."
                    },

                    new MaleCharacter
                    {
                        Id = 2,
                        BookId = 1,
                        Name = "John Willoughby",
                        Characteristic = "A philandering nephew of a neighbour of the Middletons."
                    },

                    new MaleCharacter
                    {
                        Id = 3,
                        BookId = 1,
                        Name = "Colonel Brandon",
                        Characteristic = "a close friend of Sir John Middleton."
                    }

                );
        }
    }
}
