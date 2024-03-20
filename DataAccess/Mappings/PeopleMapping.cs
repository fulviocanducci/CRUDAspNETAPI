using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess.Mappings
{
   internal class PeopleMapping : IEntityTypeConfiguration<People>
   {
      public void Configure(EntityTypeBuilder<People> builder)
      {
         builder.ToTable("Peoples");
         builder.HasKey(c => c.Id);
         builder.Property(c => c.Id).UseIdentityColumn();
         builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
         builder.Property(c => c.Active);
      }

      public static PeopleMapping Default => new PeopleMapping();
   }
}
