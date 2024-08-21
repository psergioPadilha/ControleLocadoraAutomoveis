using Microsoft.AspNetCore.Mvc;

namespace ControleLocadoraAutomoveis.WebApp.Controllers
{
    public class GrupoVeiculosController : Controller
    {
        public IActionResult Listar()
        {
            return View();
        }
    }
}
