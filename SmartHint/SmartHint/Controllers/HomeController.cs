using Microsoft.AspNetCore.Mvc;
using SmartHint.Data.Repository;
using SmartHint.Models;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SmartHint.Helppers;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
namespace SmartHint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DashboardRepository _dashboardRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _logger = logger;
            _dashboardRepository = new();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditarCadastro(string cpfCnpj, string tipoPessoa, string nomeRazaoSocial, string telefone, string bloqueado, string formattedDate, string genero, string inscricaoEst, string isento, string senha, string email, string id)
        {
            ViewData["CpfCnpj"] = cpfCnpj;
            ViewData["tipoPessoa"] = tipoPessoa;
            ViewData["nomeRazaoSocial"] = nomeRazaoSocial;
            ViewData["telefone"] = telefone;
            ViewData["bloqueado"] = bloqueado;
            ViewData["dtNascimento"] = formattedDate.Replace("-", "/");
            ViewData["genero"] = genero;
            ViewData["inscricaoEst"] = inscricaoEst;
            ViewData["isento"] = isento;
            ViewData["senha"] = senha;
            ViewData["email"] = email;
            ViewData["id"] = id;
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet, Route("Home/CarregarClientes")]
        public JsonResult CarregarClientes(string data)
        {
            return Json(_dashboardRepository.CarregarClientes(data));
        }

        [HttpPost]
        public JsonResult CadastroCliente([FromBody] JsonElement data)
        {
            return Json(_dashboardRepository.CadastroCliente(data.GetValue("nomeCliente"), data.GetValue("email"), data.GetValue("telefone"), data.GetValue("tipoPessoa"), data.GetValue("cpfCnpj"), data.GetValue("inscricaoEstadual"), data.GetValue("genero"), data.GetValue("dataNascimento"), data.GetValue("senha"), data.GetValue("isento"), data.GetValue("bloqueado")));
        }
        [HttpPost]
        public JsonResult AtualizarCadastro([FromBody] JsonElement data)
        {
            return Json(_dashboardRepository.AtualizarCadastro(data.GetValue("nomeCliente"), data.GetValue("email"), data.GetValue("telefone"), data.GetValue("tipoPessoa"), data.GetValue("cpfCnpj"), data.GetValue("inscricaoEstadual"), data.GetValue("genero"), data.GetValue("dataNascimento"), data.GetValue("senha"), data.GetValue("isento"), data.GetValue("bloqueado")));
        }
        
    }
   
}