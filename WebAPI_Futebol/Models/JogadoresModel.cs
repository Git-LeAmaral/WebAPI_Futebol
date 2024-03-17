using System.ComponentModel.DataAnnotations;
using WebAPI_Futebol.Enums;

namespace WebAPI_Futebol.Models
{
    public class JogadoresModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public PosicaoEnum Posicao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataDeInicio { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
