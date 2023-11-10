using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dioAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace dioAPI.Context
{   
    //context representa o db.
    public class AgendaContext : DbContext 
    {
        // construtor especial que se conecta ao banco de dados.
        public AgendaContext (DbContextOptions<AgendaContext> options):base(options)
        {

        }
    //criação do dbset que vai representar uma tabela.
    public DbSet<Contato> Contatos {get; set;}
    }
}