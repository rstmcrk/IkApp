
namespace IkApp.Application.RequestModels
{
    public record AppUserForRegisterModel
    {
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Password { get; init; }
    }
}
