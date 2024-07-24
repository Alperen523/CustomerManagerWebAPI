namespace CustomerManagerWebApiByAlp.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
