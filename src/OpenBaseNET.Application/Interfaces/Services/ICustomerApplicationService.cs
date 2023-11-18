﻿using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Application.Interfaces.Extension;

namespace OpenBaseNET.Application.Interfaces.Services;

public interface ICustomerApplicationService : IApplicationService
{
    Task<IEnumerable<CustomerResponse>> FindByNameUsingDapperAsync(
        FindCustomerByNameRequest request,
        CancellationToken cancellationToken);

    Task<IEnumerable<CustomerResponse>> FindByNameAsync(
        FindCustomerByNameRequest request,
        CancellationToken cancellationToken);

    Task<UpdateCustomerResponse?> UpdateAsync(
        UpdateCustomerRequest request,
        CancellationToken cancellationToken);

    Task<CreateCustomerResponse?> CreateAsync(
        CreateCustomerRequest request,
        CancellationToken cancellationToken);

    Task<DeleteCustomerResponse?> DeleteAsync(
        DeleteCustomerRequest request,
        CancellationToken cancellationToken);

    Task<CustomerResponse> GetByIdAsync(
        FindCustomerByIdRequest request,
        CancellationToken cancellationToken);

    Task<PaginatedResponse<CustomerResponse>> GetAsync(
        GetCustomerRequest request,
        CancellationToken cancellationToken);
}