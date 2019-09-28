namespace Shared.Contract
{
    public interface IIdentityProvider
    {
        ICurrentUser GetCurrentUser();

        void SetCurrentUser(UserModel user);
    }
}
