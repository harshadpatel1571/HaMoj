using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IDropDownBrindService
{
    Task<List<DropDownDto>> BrindCategoryDropDown();

}
