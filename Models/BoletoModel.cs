using BoletoApi.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoletoApi.Models
{
    public class BoletoModel
    {
        [Key]
        public int Id { get; set; }
        public required string Descricao { get; set; } 
        public required decimal Valor { get; set; }
        public required DateTime Vencimento { get; set; }
        public StatusBoletoEnum Status { get; set; }
    }
}
