

using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IVendorUserService

{
    Task<List<VendorUserDto>> GetAllAsync(int vendorId);

    Task<VendorUserDto> AddEdit(VendorUserDto dto, int VendorId);

     Task<VendorUserDto> GetDataById(int id);
}
