using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoveisPlanejados.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Matricula { get; set; }
        public string Setor { get; set; }
        public DateTime Vencimento { get; set; }
        public bool Disponivel { get; set; }
        public virtual ICollection<Movel> Moveis { get; set; }
    }
}