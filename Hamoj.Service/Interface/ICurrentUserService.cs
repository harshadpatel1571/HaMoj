namespace Hamoj.Service.Interface;

public interface ICurrentUserService
{
    int GetCurrentUserId();
    string GetCurrentUserName();
    string GetCurrentUserRole();
}
