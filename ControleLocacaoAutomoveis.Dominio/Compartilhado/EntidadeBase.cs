using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocadoraAutomoveis.Dominio.Compartilhado
{
	public abstract class EntidadeBase
	{
		public int Id { get; set; }

		public abstract void AtualizarRegistro(EntidadeBase novoRegistro);

		public abstract List<string> Validar();
	}
}
