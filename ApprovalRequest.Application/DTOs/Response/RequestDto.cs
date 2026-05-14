using ApprovalRequest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.DTOs.Common;
public class RequestDto
{
   
    public required string Title { get; set; }

    public string? Description { get; set; }

    public required string RequestedBy { get; set; }

    public RequestStatus Status { get; set; }

    public string? ReviewedBy { get; set; }

    public string? RejectionReason { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateReviewed { get; set; }
}