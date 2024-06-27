namespace FireDesk.Models
{
    public class FiltroModel
    {
        public int Take { get; set; } = 5;
        public int Page { get; set; } = 0;
        public string? Termo { get; set; }
    }
}