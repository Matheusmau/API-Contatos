using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dioAPI.Entity
{
    public class Contato
    {
        //Criação da entidade contato, que vai representar uma tabela no banco de dados.
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}