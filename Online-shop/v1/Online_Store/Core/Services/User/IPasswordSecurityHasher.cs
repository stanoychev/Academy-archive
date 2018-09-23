namespace Online_Store.Core.Services.User
{
    public interface IPasswordSecurityHasher
    {
        string Hash(string password, int iterations);
        string Hash(string password);
        bool Verify(string hashedPassword, string realPassword);
    }
}
