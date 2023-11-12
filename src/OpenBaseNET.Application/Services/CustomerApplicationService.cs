﻿using AutoMapper;
using MediatR;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomer;
using OpenBaseNET.Application.Features.CustomerFeatures.DeleteCustomer;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerById;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByName;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameUsingDapper;
using OpenBaseNET.Application.Features.CustomerFeatures.GetCustomers;
using OpenBaseNET.Application.Features.CustomerFeatures.UpdateCustomer;
using OpenBaseNET.Application.Interfaces.Services;

namespace OpenBaseNET.Application.Services;

public sealed class CustomerApplicationService : ICustomerApplicationService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CustomerApplicationService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<UpdateCustomerResponse?>
        UpdateAsync(UpdateCustomerRequest request)
    {
        var query = _mapper.Map<UpdateCustomerCommand>(request);
        return await _mediator.Send(query);
    }

    public async Task<IEnumerable<CustomerResponse>>
        FindByNameAsync(FindCustomerByNameRequest request)
    {
        var query = _mapper.Map<FindCustomerByNameQuery>(request);
        return await _mediator.Send(query);
    }

    public async Task<IEnumerable<CustomerResponse>>
        FindByNameUsingDapperAsync(FindCustomerByNameRequest request)
    {
        var query = _mapper.Map<FindCustomerByNameUsingDapperQuery>(request);
        return await _mediator.Send(query);
    }

    public async Task<CreateCustomerResponse?>
        CreateAsync(CreateCustomerRequest request)
    {
        var query = _mapper.Map<CreateCustomerCommand>(request);
        return await _mediator.Send(query);
    }

    public async Task<DeleteCustomerResponse?> DeleteAsync(DeleteCustomerRequest request)
    {
        var query = _mapper.Map<DeleteCustomerCommand>(request);
        return await _mediator.Send(query);
    }

    public async Task<CustomerResponse> GetByIdAsync(FindCustomerByIdRequest request)
    {
        var query = _mapper.Map<FindCustomerByIdQuery>(request);
        return await _mediator.Send(query);
    }

    public async Task<PaginateResponse<CustomerResponse>> GetAsync(GetCustomerRequest request)
    {
        var query = _mapper.Map<GetCustomerQuery>(request);
        return await _mediator.Send(query);
    }
}