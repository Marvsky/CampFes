namespace CampFes.Models.JWT
{
    public class TokenRequest
    {
        public string? Token { get; set; }

        public string? Refresh_Token { get; set; }
    }
}
