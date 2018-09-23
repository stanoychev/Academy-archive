namespace Online_Store.Core.Providers
{
    public class LoggedUserProvider : ILoggedUserProvider
    {
        public LoggedUserProvider()
        {
            this.CurrentUserId = -1;
        }

        public int CurrentUserId { get; set; }
    }
}
