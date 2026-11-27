using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_AI_BE.Entities;

namespace movie_AI_BE.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        builder.Property(u => u.UserUuid).HasDefaultValueSql("gen_random_uuid()").ValueGeneratedOnAdd().IsRequired();
        builder.HasIndex(u => u.UserUuid).IsUnique();

        builder.Property(u => u.Name);

        builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
        builder.HasIndex(u=>u.Email).IsUnique();

        builder.Property(u => u.Hashed_Password).IsRequired();

        builder.Property(u => u.temp_otp_Hashed);

        builder.Property(u => u.Role).IsRequired();

        builder.Property(u => u.Status).IsRequired();

        builder.Property(u => u.IsVerified).IsRequired();

        builder.Property(u => u.temp_otp_TimeOut);

        builder.Property(u => u.Otp_Expired_atutc).IsRequired();

        builder.Property(u => u.Created_atutc).IsRequired();

        builder.Property(u => u.Updated_atutc).IsRequired();
        
    }
}