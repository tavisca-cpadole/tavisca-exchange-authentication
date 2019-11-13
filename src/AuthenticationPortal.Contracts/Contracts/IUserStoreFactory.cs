namespace AuthenticationPortal.Contracts
{
    public interface IUserStoreFactory
    {
        IUserStore GetUserStore(string storeName);
    }
}
