using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Models;

namespace API.Data
{
    public class TarefaMap : IEntityTypeConfiguration<FuncoesModel>
    {
        public void Configure(EntityTypeBuilder<FuncoesModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}