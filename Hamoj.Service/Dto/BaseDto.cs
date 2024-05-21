
namespace Hamoj.Service.Dto;

public class BaseDto
{
    public int Create_by { get; set; }
    public DateTime Create_Date { get; set; }
    public int Modified_by { get; set; }
    public DateTime Modified_Date { get; set; }
    public byte is_Active { get; set; }
    public byte is_Delete { get; set; }
}

