namespace WebApplication6.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }=string.Empty;
        public DateTime? PlayerBirthDay { get; set; }
        public string FotoUrl { get; set; }
        public int? Boy {  get; set; }
        public int? Kilo { get; set; }
        public bool? KadinMi { get; set; }
        public bool? AktifMi { get; set; }
        public float? SmacYukseklik { get; set; }
        public float? BlokYukseklik { get; set; }
        public bool? SagElMi{ get; set; }

        public int? PositionId { get; set; }
        public Position? Position { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
