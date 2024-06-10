using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IDropDownBindService
{
    Task<List<DropDownDto>> BindCategoryDropDown();

    Task<List<DropDownDto>> BindVendorUserDropDown(int VendorId);


}
