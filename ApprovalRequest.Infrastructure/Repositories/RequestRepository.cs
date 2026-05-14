using ApprovalRequest.Application.Interfaces.Repositories;
using ApprovalRequest.Domain.Entities;
using ApprovalRequest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApprovalRequest.Infrastructure.Repositories;

public class RequestRepository
    : BaseRepository<Request>, IRequestRepository
{
    private readonly AppDbContext _context;

    public RequestRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<List<Request>> GetAllWithDetailsAsync(int pageNumber, int pageSize)
    {
        return await _context.Requests
            .AsNoTracking()
            .OrderByDescending(x => x.DateCreated)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}