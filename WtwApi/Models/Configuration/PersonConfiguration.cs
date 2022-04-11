using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WtwApi.Models.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<PersonModel>
    {
        public void Configure(EntityTypeBuilder<PersonModel> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(p => p.Id);
        }
    }
}
