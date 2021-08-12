using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities

{
    public class Veiculo : Entity, IEntityTypeConfiguration<Veiculo>
    {
        public Guid TipoVeiculoId { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        public string Placa { get; set; }
        public string Parking { get; set; }
        public string Status { get; set; }

        public Veiculo() { }

        public Veiculo(Guid TipoVeiculoId, string placa, string parking, string status)
        {
            Placa = placa;
            Parking = parking;
            Status = status;
            TipoVeiculoId = TipoVeiculoId;

        }
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
        }

    }
}
