using ApprovalRequest.Application.DTOs.Common;
using ApprovalRequest.Application.DTOs.Request;
using ApprovalRequest.Domain.Entities;
using AutoMapper;

public class RequestProfile : Profile
{
    public RequestProfile()
    {
        CreateMap<Request, RequestDto>().ReverseMap();
        CreateMap<Request, CreateRequestDto>().ReverseMap();
    }
}