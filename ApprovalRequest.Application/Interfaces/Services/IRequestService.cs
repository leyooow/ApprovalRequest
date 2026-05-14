using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Application.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.Interfaces.Services;

public interface IRequestService
{
    Task<Guid> CreateAsync(CreateRequestDto request);

    Task<ApiResponse<RequestDto>?> GetByIdAsync(Guid id);

    Task<PagedResponse<RequestDto>> GetAllAsync(PaginationQuery query);

    Task ApproveAsync(Guid id, ApprovalActionDto request);

    Task RejectAsync(Guid id, ApprovalActionDto request);
}
