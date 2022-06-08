namespace MoveisPlanejados.Models
{
    public class Movel
    {
            public int MovelId { get; set; }
            public string Tipo { get; set; }
            public string Material { get; set; }
            public string Link { get; set; }
            public string Status { get; set; }
            public int? FuncionarioId { get; set; }
            public virtual Funcionario funcionario { get; set; }
            
            
    }
}