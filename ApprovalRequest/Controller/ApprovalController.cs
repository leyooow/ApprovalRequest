using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Application.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace ApprovalRequest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApprovalController : ControllerBase
{
    /// <summary>
    /// Create new request
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<Guid>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create(CreateRequestDto request)
    {
        var response = new ApiResponse<Guid>
        {
            Success = true,
            StatusCode = StatusCodes.Status201Created,
            Message = "Request created successfully",
            Data = Guid.NewGuid()
        };

        return StatusCode(StatusCodes.Status201Created, response);
    }

    /// <summary>
    /// Get request by ID
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var data = new
        {
            Id = id,
            Title = "Sample Request",
            Status = "Pending"
        };

        var response = new ApiResponse<object>
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Message = "Request retrieved successfully",
            Data = data
        };

        return Ok(response);
    }

    /// <summary>
    /// Get all requests with pagination
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<PagedResponse<object>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery query)
    {
        var items = new List<object>
        {
            new
            {
                Id = Guid.NewGuid(),
                Title = "Request 1",
                Status = "Pending"
            },
            new
            {
                Id = Guid.NewGuid(),
                Title = "Request 2",
                Status = "Approved"
            }
        };

        var pagedData = new PagedResponse<object>
        {
            Items = items,
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
            TotalRecords = 2,
            TotalPages = 1
        };

        var response = new ApiResponse<PagedResponse<object>>
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Message = "Requests retrieved successfully",
            Data = pagedData
        };

        return Ok(response);
    }

    /// <summary>
    /// Approve request
    /// </summary>
    [HttpPut("{id:guid}/approve")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Approve(Guid id, ApprovalActionDto request)
    {
        var response = new ApiResponse<object>
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Message = "Request approved successfully"
        };

        return Ok(response);
    }

    /// <summary>
    /// Reject request
    /// </summary>
    [HttpPut("{id:guid}/reject")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Reject(Guid id, ApprovalActionDto request)
    {
        var response = new ApiResponse<object>
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Message = "Request rejected successfully"
        };

        return Ok(response);
    }
}