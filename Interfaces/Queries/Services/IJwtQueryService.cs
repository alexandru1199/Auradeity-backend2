namespace Interfaces.Queries.Services
{
    public interface IJwtQueryService
    {
        string GetJwtToken(string email, long id);
    }
}
