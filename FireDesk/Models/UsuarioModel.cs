using FireDesk.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FireDesk.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required, MaxLength(80, ErrorMessage = "Nome obrigatório e não pode o tamanho permitido!")]
        public string? UsuarioName { get; set; }

        [EmailAddress]
        [Required, MaxLength(120, ErrorMessage = "Email deve ser válido!")]
        public string? UsuarioEmail { get; set; }

        [Required, MaxLength(11, ErrorMessage = "CPF deve ser válido!")]
        public string? UsuarioCPF { get; set; }

        [Required, MaxLength(15, ErrorMessage = "Senha requerida!")]
        public string? UsuarioSenha { get; set; }

        [Required(ErrorMessage = "Status sem preencher!")]
        public UsuarioStatus Status { get; set; }

        [Required(ErrorMessage = "Tipo sem preencher!")]
        public UsuarioTipagem Tipo { get; set; }
    }
}