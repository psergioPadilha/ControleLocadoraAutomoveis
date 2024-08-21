using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Infraestrutura.Orm.ModuloGrupoAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleLocadoraAutomoveis.Infraestrutura.Orm.Compartilhado;

public class ControleLocadoraAutomoveisDbContext : DbContext
{
	public DbSet<GrupoAutomoveis> GrupoAutomoveis { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var connectionString = config
			.GetConnectionString("SqlServer");

		optionsBuilder.UseSqlServer(connectionString);

		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new MapeadorGrupoAutomoveisEmOrm());

		base.OnModelCreating(modelBuilder);
	}
}
