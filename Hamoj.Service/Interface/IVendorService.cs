
using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IVendorService
{
    Task<List<VendorDto>> GetAllAsync();

    Task<VendorDto> AddEditVendor(VendorDto dto);

    Task<VendorDto> GetDataById(int id);

    Task<bool> Delete(int id);

    Task<VendorDto> FindDuplicate(string Email, string MobileNumber, int? id);

}
