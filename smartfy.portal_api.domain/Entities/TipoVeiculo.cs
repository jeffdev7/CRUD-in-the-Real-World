using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
   public class TipoVeiculo : Entity, IEntityTypeConfiguration<TipoVeiculo>
    {
        public string Modelo { get; set; }
        public string Descricao { get; set; }

        public TipoVeiculo() { }

        public TipoVeiculo(string modelo, string descricao)
        {
            Modelo = modelo;
            Descricao = descricao;
        }

        public void Configure(EntityTypeBuilder<TipoVeiculo> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
        }

    }
}
