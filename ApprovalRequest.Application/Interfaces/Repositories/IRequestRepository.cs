using ApprovalRequest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.Interfaces.Repositories;

public interface IRequestRepository : IBaseRepository<Request>
{
    Task<List<Request>> GetAllWithDetailsAsync(int pageNumber, int pageSize);
}
