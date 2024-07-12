using FireDesk.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireDesk.Models
{
    public class TicketsModel
    {
        [Key]
        public int TicketID { get; set; }

        [Required(ErrorMessage = "Assunto sem preencher!")]
        public string? Assunto { get; set; }

        [Required(ErrorMessage = "Descrição sem preencher!")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Status sem preencher!")]
        public DeskStatus Status { get; set; }

        [Required(ErrorMessage = "Usuario de Abertura sem preencher!")]
        public int UsuarioAberturaId { get; set; }

        public int? UsuarioFechamentoId { get; set; } = null;

        [Required(ErrorMessage = "Data de providência sem preencher!")]
        [DataType(DataType.DateTime)]
        public DateTime DataProv { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Prioridade sem preencher!")]
        public PrioridadeStatus Prioridade { get; set; }

        [ForeignKey("Tecnicos")]
        public int TecnicoId { get; set; }

        public TecnicosModel? Tecnicos { get; set; }
    }
}