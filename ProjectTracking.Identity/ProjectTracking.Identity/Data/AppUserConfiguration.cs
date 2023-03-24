using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracking.Identity.Models;

namespace ProjectTracking.Identity.Data;

public class AppUserConfiguration:IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(e => e.Id); 
    }
}