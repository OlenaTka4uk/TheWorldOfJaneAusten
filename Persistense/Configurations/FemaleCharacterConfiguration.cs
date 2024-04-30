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
    public class FemaleCharacterConfiguration : IEntityTypeConfiguration<FemaleCharacter>
    {
        public void Configure(EntityTypeBuilder<FemaleCharacter> builder)
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
                    new FemaleCharacter
                    {
                        Id = 1,
                        Name = "Elinor Dashwood",
                        BookId = 1,
                        Characteristic = "The sensible and reserved eldest daughter of Mr and Mrs Henry Dashwood."
                    },

                    new FemaleCharacter
                    {
                        Id = 2,
                        Name = "Marianne Dashwood",
                        BookId = 1,
                        Characteristic = "The romantically inclined and eagerly expressive second daughter of Mr and Mrs Henry Dashwood."
                    },

                    new FemaleCharacter
                    {
                        Id = 3,
                        Name = "Margaret Dashwood",
                        BookId = 1,
                        Characteristic = "the youngest daughter of Mr and Mrs Henry Dashwood."
                    }
                );
        }
    }
}
