using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleLocadoraAutomoveis.Dominio.Compartilhado;

namespace ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public class GrupoAutomoveis : EntidadeBase
    {
        public string Descricao { get; set; }

        public GrupoAutomoveis()
        {

        }

        public GrupoAutomoveis(string descricao)
        {
	        this.Descricao = descricao;
        }

		public override void AtualizarRegistro(EntidadeBase novoRegistro)
		{
			GrupoAutomoveis grupoAutomoveisAtualizado = (GrupoAutomoveis)novoRegistro;

			Descricao = grupoAutomoveisAtualizado.Descricao;
		}

		public override List<string> Validar()
		{
			List<string> erros = new List<string>();

			if (string.IsNullOrEmpty(Descricao.Trim()))
				erros.Add("O campo \"DESCRIÇÃO\" é obrigatorio!");

			return erros;
		}
	}
}