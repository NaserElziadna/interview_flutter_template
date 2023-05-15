namespace PizzaBE.Application.DTOs.ApplicationUser
{
    public class JwtTokenResponseDTO
    {
        public string token { get; set; }
        public long id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public bool isBlocked { get; set; }
        public string role { get; set; }
    }
}
