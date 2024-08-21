using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Infraestrutura.Orm.Compartilhado;
using ControleLocadoraAutomoveis.Infraestrutura.Orm.ModuloGrupoAutomoveis;

namespace ControleLocadoraAutomoveis.Testes.Integracao.Orm;
[TestClass]
public class RepositorioGrupoAutomoveisOrmTests
{
	private ControleLocadoraAutomoveisDbContext db;
	private RepositorioGrupoAutomoveisEmOrm repositorioGrupoAutomoveis;

	[TestInitialize]
	public void ConfigurarTestes()
	{
		db = new ControleLocadoraAutomoveisDbContext();

		db.GrupoAutomoveis.RemoveRange(db.GrupoAutomoveis);

		db.SaveChanges();

		repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveisEmOrm(db);
	}

	[TestMethod]
	public void Deve_Inserir_Genero()
	{
		// Arrange
		var novoGrupoAutomoveis = new GrupoAutomoveis("A��o");

		// Act
		repositorioGrupoAutomoveis.Inserir(novoGrupoAutomoveis);

		// Assert
		var grupoAutomoveisEncontrado = repositorioGrupoAutomoveis.SelecionarPorId(novoGrupoAutomoveis.Id);

		Assert.IsNotNull(grupoAutomoveisEncontrado);
		Assert.AreEqual(novoGrupoAutomoveis.Id, grupoAutomoveisEncontrado.Id);
		Assert.AreEqual(novoGrupoAutomoveis.Descricao, grupoAutomoveisEncontrado.Descricao);
	}

	[TestMethod]
	public void Deve_Editar_Genero()
	{
		// Arrange
		var novoGrupoAutomoveis = new GrupoAutomoveis("A��o");
		repositorioGrupoAutomoveis.Inserir(novoGrupoAutomoveis);

		novoGrupoAutomoveis.Descricao = "PASSEIO";

		// Act
		repositorioGrupoAutomoveis.Editar(novoGrupoAutomoveis);

		// Assert
		var grupoAutomoveisEncontrado = repositorioGrupoAutomoveis.SelecionarPorId(novoGrupoAutomoveis.Id);

		Assert.IsNotNull(grupoAutomoveisEncontrado);
		Assert.AreEqual(novoGrupoAutomoveis, grupoAutomoveisEncontrado);
	}

	[TestMethod]
	public void Deve_Excluir_Genero()
	{
		// Arrange
		var novoGrupoAutomoveis = new GrupoAutomoveis("A��o");
		repositorioGrupoAutomoveis.Inserir(novoGrupoAutomoveis);

		// Act
		repositorioGrupoAutomoveis.Excluir(novoGrupoAutomoveis);

		// Assert
		var grupoAutomoveisEncontrado = repositorioGrupoAutomoveis.SelecionarPorId(novoGrupoAutomoveis.Id);

		Assert.IsNull(grupoAutomoveisEncontrado);
	}

	[TestMethod]
	public void Deve_Selecionar_Generos()
	{
		// Arrange
		GrupoAutomoveis[] gruposAutomoveisParaInserir =
		[
			new GrupoAutomoveis("A��o"),
			new GrupoAutomoveis("PASSEIO"),
			new GrupoAutomoveis("CARGA")
		];

		// Act
		foreach (var grupoAutomoveis in gruposAutomoveisParaInserir)
			repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);

		// Assert
		var gruposAutomoveisSelecionados = repositorioGrupoAutomoveis.SelecionarTodos();

		CollectionAssert.AreEqual(gruposAutomoveisParaInserir, gruposAutomoveisSelecionados);
	}
}
