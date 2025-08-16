using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Students.Queries.GetAllStudents;

public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<CreateStudentResponse>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetAllStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));;
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<CreateStudentResponse>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<CreateStudentResponse>>(students);
    }
}