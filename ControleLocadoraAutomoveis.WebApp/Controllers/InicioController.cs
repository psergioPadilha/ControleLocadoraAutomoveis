using ControleLocadoraAutomoveis.Dominio.Compartilhado;
using Microsoft.AspNetCore.Mvc;

namespace ControleLocadoraAutomoveis.WebApp.Controllers;
public class InicioController : Controller
{
	public ViewResult Index()
	{

		return View();
	}
}
