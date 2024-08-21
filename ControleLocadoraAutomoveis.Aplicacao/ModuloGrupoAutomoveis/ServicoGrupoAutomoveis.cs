using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using ControleLocadoraAutomoveis.Infraestrutura.Orm.Migrations;
using FluentResults;

namespace ControleLocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
public class ServicoGrupoVeiculos
{
    private readonly IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

    public ServicoGrupoVeiculos(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
    {
        this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
    }

    public Result<GrupoAutomoveis> Inserir(GrupoAutomoveis grupoAutomoveis)
    {
        repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);

        return Result.Ok(grupoAutomoveis);
    }

    public Result<GrupoAutomoveis> Editar(GrupoAutomoveis grupoAutomoveisAtualizado)
    {
        var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisAtualizado.Id);

        if (grupoAutomoveis is null)
            return Result.Fail("O grupo não foi encontrado!");

        grupoAutomoveis.Descricao = grupoAutomoveisAtualizado.Descricao;

        repositorioGrupoAutomoveis.Editar(grupoAutomoveis);

        return Result.Ok(grupoAutomoveis);
    }

    public Result<GrupoAutomoveis> Excluir(int idGrupo)
    {
        var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(idGrupo);

        if (grupoAutomoveis is null)
            return Result.Fail("O grupo não foi encontrado!");

        repositorioGrupoAutomoveis.Excluir(grupoAutomoveis);

        return Result.Ok(grupoAutomoveis);
    }

    public Result<GrupoAutomoveis> SelecionarPorId(int idGrupo)
    {
        var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(idGrupo);

        if (grupoAutomoveis is null)
            return Result.Fail("O grupo não foi encontrado!");

        return Result.Ok(grupoAutomoveis);
    }

    public Result<List<GrupoAutomoveis>> SelecionarTodos()
    {
        var gruposAutomoveis = repositorioGrupoAutomoveis.SelecionarTodos();

        return Result.Ok(gruposAutomoveis);
    }
}
