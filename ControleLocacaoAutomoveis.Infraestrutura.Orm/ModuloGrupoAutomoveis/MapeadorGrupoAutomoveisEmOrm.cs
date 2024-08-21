using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocadoraAutomoveis.Infraestrutura.Orm.ModuloGrupoAutomoveis;
public class MapeadorGrupoAutomoveisEmOrm : IEntityTypeConfiguration<GrupoAutomoveis>
{
	public void Configure(EntityTypeBuilder<GrupoAutomoveis> eBuilder)
	{
		eBuilder.ToTable("TBGrupoAutomoveis");

		eBuilder.Property(e => e.Id)
			.IsRequired()
			.ValueGeneratedOnAdd();

		eBuilder.Property(e => e.Descricao)
			.IsRequired()
			.HasColumnType("varchar(150)");

		eBuilder.HasData(ObterRegistrosPadrao());
	}

	private GrupoAutomoveis[] ObterRegistrosPadrao()
	{
		return
		[
			new GrupoAutomoveis { Id = 1, Descricao = "PASSEIO" },
			new GrupoAutomoveis { Id = 2, Descricao = "UTILITÁRIO" },
			new GrupoAutomoveis() { Id = 3, Descricao = "VEÍCULO PARA PCD" }
		];
	}
}
