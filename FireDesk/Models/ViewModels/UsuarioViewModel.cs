using System.ComponentModel.DataAnnotations;

namespace FireDesk.Models.ViewModels
{
    public class UsuarioViewModel
    {

        public ICollection<UsuarioModel>? Usuarios { get; set; }
    }
}
