using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.DTOs.Request;

public class ApprovalActionDto
{
    public string ReviewedBy { get; set; } = string.Empty;

    public string? Reason { get; set; }
}
