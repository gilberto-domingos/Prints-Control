using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Students.Queries.GetByIdStudent;

public class GetByIdStudentQueryHandler : IRequestHandler<GetByIdStudentQuery,GetByIdStudentResponse>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetByIdStudentQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdStudentResponse> Handle(GetByIdStudentQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<GetByIdStudentResponse>(student);
    }
}