﻿using Hamoj.DB.Datamodel;

using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllAsync();

    Task<CustomerDto> AddEditCustomer(CustomerDto dto);

    Task<CustomerDto> GetDataById(int id);

    Task<bool> Delete(int id);
}