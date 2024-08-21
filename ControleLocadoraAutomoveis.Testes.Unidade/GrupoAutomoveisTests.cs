using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleLocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace ControleLocadoraAutomoveis.Testes.Unidade
{
	[TestClass] // Atributos
	[TestCategory("Teste de validação de campos da entidade GrupoAutomoveis")]
	public class GrupoAutomoveisTests
	{
		[TestMethod]
		public void Deve_Validar_GrupoAutomoveis_Corretamente()
		{
			// AAA = Triple A

			// Arrange (preparação do teste)
			GrupoAutomoveis grupoAutomoveisInvalido = new GrupoAutomoveis("");

			List<string> errosEsperados =
			[
				"O campo \"DESCRIÇÃO\" é obrigatorio!"
			];

			// Act (ação do teste)
			List<string> erros = grupoAutomoveisInvalido.Validar();

			// Assert (asserção do teste)
			CollectionAssert.AreEqual(errosEsperados, erros);
		}
	}
}
