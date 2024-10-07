namespace WebApplication6.Data
{
    public class Country
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public ICollection<Player>? Players { get; set; }
    }
}
