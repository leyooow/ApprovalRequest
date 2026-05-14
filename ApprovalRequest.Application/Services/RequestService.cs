using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Application.DTOs.Request;
using ApprovalRequest.Application.Interfaces.Repositories;
using ApprovalRequest.Application.Interfaces.Services;
using ApprovalRequest.Domain.Entities;
using ApprovalRequest.Domain.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.Services;

public class RequestService : IRequestService
{
    private readonly IBaseRepository<Request> _repository;
    private readonly IMapper _mapper;
    public RequestService(
        IBaseRepository<Request> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<RequestDto>> CreateAsync(RequestDto dto)
    {

        var response = new ApiResponse<RequestDto>();

        try
        {
            var entity = _mapper.Map<Request>(dto);

            await _repository.AddAsync(entity);

            response.Data = _mapper.Map<RequestDto>(entity);
            response.Success = true;
            response.StatusCode = 201;
            response.Message = "Request created successfully";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = $"An error occurred: {ex.Message}";
            return response;
        }

    }

    public Task<ApiResponse<RequestDto>?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<RequestDto>> GetAllAsync(PaginationQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse> ApprovalAsync(Guid id, ApprovalActionDto request)
    {
        var response = new ApiResponse();
        try
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
            {
                response.StatusCode = 404;
                response.Message = "Request not found";

                return response;
            }

            result.Status = request.ApprovalAction == RequestStatus.Approved
               ? RequestStatus.Approved
               : RequestStatus.Rejected;

            result.ReviewedBy = request.ReviewedBy;

            await _repository.UpdateAsync(result);

            response.Success = true;
            response.StatusCode = 200;
            response.Message = request.ApprovalAction == RequestStatus.Approved
                ? "Request approved successfully"
                : "Request rejected successfully";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = $"An error occurred: {ex.Message}";
            return response;
        }


    }

    public Task<ApiResponse<RequestDto>> CreateAsync(CreateRequestDto request)
    {
        throw new NotImplementedException();
    }

}
