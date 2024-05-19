namespace WebApiNative.Domain.Repositories
{
    public interface ITokenRepository
    {
        public Task<string> GenerateToken(string username, string password);
    }
}