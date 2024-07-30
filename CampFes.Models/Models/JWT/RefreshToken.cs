namespace CampFes.Models.JWT
{
    public class RefreshToken
    {
        public string? JTI { get; set; }

        public string? USER { get; set; }

        public string? REFRESH_TOKEN { get; set; }

        public bool IS_REVORKED { get; set; }

        public DateTime? A_UTCDT { get; set; }

        public DateTime? EXPIRY_DATE { get; set; }
    }
}
