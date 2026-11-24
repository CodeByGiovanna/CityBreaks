using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(c => c.CountryName)
            .HasMaxLength(50)
            .HasColumnName("Name");

        builder.Property(c => c.CountryCode)
            .HasMaxLength(3)
            .HasColumnName("ISO3");
                    builder.HasData(
            new Country { Id = 1, CountryCode = "ITA", CountryName = "Italy" },
            new Country { Id = 2, CountryCode = "BRA", CountryName = "Brazil" },
            new Country { Id = 3, CountryCode = "FRA", CountryName = "France" }
        );
    }
}