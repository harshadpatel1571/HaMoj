
using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IVendorService
{
    Task<List<VendorDto>> GetAllAsync();

}
