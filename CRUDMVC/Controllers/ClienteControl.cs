using CRUDMVC.Models;
using CRUDMVC.Data;
using CRUDMVC.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace CRUDMVC.Controllers
{
    public class ClienteControl : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var dbcontext = new Banco();

            ViewData["clientes"] = dbcontext.Clientes.Where(p => p.Id > 0).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Cliente cliente)
        {
            var dbcontext = new Banco();
            dbcontext.Add(cliente);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deletar(Cliente cliente)
        {
            var dbcontext = new Banco();

            var clienteDelete = dbcontext.Clientes.Find(cliente.Id);
            dbcontext.Remove(clienteDelete);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Atualizar(Cliente novosDadosCliente)
        {
            var dbcontext = new Banco();

            var antigosDadosCliente = dbcontext.Clientes.Find(novosDadosCliente.Id);

            antigosDadosCliente.Nome = novosDadosCliente.Nome;
            antigosDadosCliente.CPF = novosDadosCliente.CPF;
            antigosDadosCliente.Nascimento = novosDadosCliente.Nascimento;
            antigosDadosCliente.Situacao = novosDadosCliente.Situacao;

            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}