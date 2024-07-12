namespace FireDesk.Models.ViewModels
{
    public class TicketsViewModel
    {
        public ICollection<TicketsModel>? Tickets { get; set; }
        public int? TotalRegistros { get; set; }
        public string? Termo { get; set; }
    }
}