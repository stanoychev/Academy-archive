namespace Online_Store.Core.Providers
{
    public interface ILoggedUserProvider
    {
        int CurrentUserId { get; set; }
    }
}
