using System.ComponentModel.DataAnnotations;

namespace FireDesk.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required, MaxLength(80, ErrorMessage = "Nome obrigatório e não pode o tamanho permitido!")]
        public string? UsuarioName { get; set; }
        [EmailAddress]
        [Required, MaxLength(120, ErrorMessage ="Email deve ser válido!")]
        public string? UsuarioEmail { get; set; }
        [Required, MaxLength(11, ErrorMessage ="CPF deve ser válido!")]
        public string? UsuarioCPF { get; set; }
       
    }
}
