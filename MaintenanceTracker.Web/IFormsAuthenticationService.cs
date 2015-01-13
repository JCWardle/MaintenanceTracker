namespace MaintenanceTracker.Web
{
    public interface IFormsAuthenticationService
    {
        void SetAuthCookie(string username, bool remember);
    }
}