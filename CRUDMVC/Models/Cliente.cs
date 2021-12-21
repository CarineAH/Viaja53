using CRUDMVC.Enum;
using System;

namespace CRUDMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public Situacao Situacao { get; set; }
    }
}
