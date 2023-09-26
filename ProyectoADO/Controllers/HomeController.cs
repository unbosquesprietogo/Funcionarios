using Microsoft.AspNetCore.Mvc;
using ProyectoADO.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

using CapaDatos.Repositorio;
using CapaDatos.Entidades;

namespace ProyectoADO.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFuncionarioRepositorio _repositorio;

        public HomeController(IFuncionarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> MostrarFuncionarios()
        {
            List<Funcionario> listaFuncionario = await _repositorio.ObtenerFuncionarios(); 
            return View(listaFuncionario);
        }

        public async Task<IActionResult> buscarFuncionario()
        {
            string idFuncionario = HttpContext.Request.Query["idFuncionario"].ToString(); 
            if (int.TryParse(idFuncionario, out int idFuncionarioInt))
            {

                Funcionario funcionario = await _repositorio.ObtenerFuncionario(idFuncionarioInt);

                if (funcionario != null)
                {
                    return View(funcionario);
                }
                else
                {
                    return NotFound(); 
                }
            }
            else
            {
                return BadRequest("El parámetro 'idFuncionario' no es un entero válido.");
            }
        }



        public async Task<IActionResult> buscar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}