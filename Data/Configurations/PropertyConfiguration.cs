using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(150)
            .HasColumnName("PropertyName");

        builder.Property(p => p.PricePerNight)
            .HasConversion<double>()
            .HasColumnName("Price");
        builder.HasData(
            new Property { Id = 1, Name = "Hotel Piazza Castello", PricePerNight = 120.00m, CityId = 1 },
            new Property { Id = 2, Name = "B&B Mole Antonelliana", PricePerNight = 85.50m, CityId = 1 },
            new Property { Id = 3, Name = "Trastevere Apartment", PricePerNight = 140.00m, CityId = 2 },
            new Property { Id = 4, Name = "Colosseum View Hotel", PricePerNight = 210.00m, CityId = 2 },
            new Property { Id = 5, Name = "Copacabana Beach Hostel", PricePerNight = 45.00m, CityId = 3 },
            new Property { Id = 6, Name = "Ipanema Suites", PricePerNight = 160.00m, CityId = 3 },
            new Property { Id = 7, Name = "Le Marais Studio", PricePerNight = 175.00m, CityId = 4 }
        );
    }
}