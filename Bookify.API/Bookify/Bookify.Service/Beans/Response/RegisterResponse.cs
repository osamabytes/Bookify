namespace Bookify.Service.Interfaces.Response
{
    public class RegisterResponse
    {
        public Boolean IsSuccessfulRegister { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
