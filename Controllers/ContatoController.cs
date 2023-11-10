using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dioAPI.Context;
using dioAPI.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dioAPI.Controllers
{   [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        //atributo e injeção de independencia
        
        private readonly AgendaContext _context; 
        // É uma instância do DbContext do EF Core, que representa a camada de acesso a dados para interagir com o banco de dados.

        //construtor para receber o Context
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        //CREATE
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }

        //READ
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);
            //método para buscar com entidade com base na chave primária.

            if(contato == null)
            return NotFound();

            return Ok(contato);
        }

            //READ
        [HttpGet("ObterPornome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);
            //método para buscar com entidade com base na chave primária.

             if(contatoBanco == null)
            return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
            return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}