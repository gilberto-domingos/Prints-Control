using AutoMapper;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Application.Features.Students.Commands.DeleteStudent;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Students;

public sealed class DeleteStudentMapper : Profile
{
    public DeleteStudentMapper()
    {
        CreateMap<DeleteStudentCommand, Student>();
        CreateMap<Student, DeleteStudentResponse>();
    }
}