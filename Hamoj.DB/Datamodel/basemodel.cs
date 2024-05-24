

namespace Hamoj.DB.Datamodel;

public class basemodel
{
    public int Create_by { get; set; }
    public DateTime Create_Date { get; set; }
    public int? Modified_by { get; set; }
    public DateTime? Modified_Date { get; set; }
    public bool is_Active { get; set; }
    public bool is_Delete { get; set; }
}
