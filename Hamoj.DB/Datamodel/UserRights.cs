
namespace Hamoj.DB.Datamodel;

public class UserRights : basemodel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserType { get; set; }
    public string MenuName { get; set; }
    public string Icon { get; set; }
    public string Url { get; set; }

}
