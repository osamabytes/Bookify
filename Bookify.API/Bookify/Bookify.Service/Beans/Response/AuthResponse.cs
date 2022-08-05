namespace Bookify.Service.Interfaces.Response
{
    public class AuthResponse
    {
        public Boolean IsAuthSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
