namespace Hermes.Api.Domain.Contracts.Service
{
    public interface IPasswordHashService
    {
        string HashPassword(string password);
    }
}
