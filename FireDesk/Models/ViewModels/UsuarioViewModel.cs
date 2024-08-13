using FireDesk.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FireDesk.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public ICollection<UsuarioModel>? Usuarios { get; set; }
        public int? TotalRegistros { get; set; }
        public string? Termo { get; set; }
    }
}