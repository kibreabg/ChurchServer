using ChurchServer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChurchServer.Infrastructure.Data.Config
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(p => p.Title)
                .HasMaxLength(100);
            builder.Property(p => p.FirstName)
                .HasMaxLength(100);
            builder.Property(p => p.LastName)
                .HasMaxLength(100);
            builder.Property(p => p.SurName)
                .HasMaxLength(100);
            builder.Property(p => p.Sex)
                .HasMaxLength(100);
            builder.Property(p => p.BirthDate)
                .HasMaxLength(100);
            builder.Property(p => p.MaritalStatus)
                .HasMaxLength(100);
            builder.Property(p => p.WeddingDate)
                .HasMaxLength(100);
            builder.Property(p => p.BaptizedHere)
                .HasMaxLength(10);
            builder.Property(p => p.PreviousChurch)
                .HasMaxLength(100);
            builder.Property(p => p.MembershipDate)
                .HasMaxLength(100);
            builder.Property(p => p.DiscipleshipTeacher)
                .HasMaxLength(100);
            builder.Property(p => p.IsServing)
                .HasMaxLength(10);
            builder.Property(p => p.EducationLevel)
                .HasMaxLength(100);
            builder.Property(p => p.IsInHomeCell)
                .HasMaxLength(10);
            builder.Property(p => p.NotInHomeCellReason)
                .HasMaxLength(100);
            builder.Property(p => p.PermitHomeForHomeCell)
                .HasMaxLength(10);
            builder.Property(p => p.IsInChurchSocialService)
                .HasMaxLength(10);
            builder.Property(p => p.HasJob)
                .HasMaxLength(10);
            builder.Property(p => p.Occupation)
                .HasMaxLength(100);
            builder.Property(p => p.Company)
                .HasMaxLength(100);
            builder.Property(p => p.Responsibility)
                .HasMaxLength(100);
            builder.Property(p => p.Profession)
                .HasMaxLength(100);
            builder.Property(p => p.OtherAbilities)
                .HasMaxLength(100);

        }
    }
}
