namespace WebApplication6.Data
{
    public class Position
    {
        public int PositionId { get; set; }
        public string? PositionName { get; set; }
        public ICollection<Player>? Players { get; set; }
    }
}
