using KODEPROEX1.Entities.Models;
using KODEPROEX1.Entities.Queries;

namespace KODEPROEX1.Implementation.Interfaces;

public interface IStudentRepo
{
    List<StudentDto> GetStudentsByFilters(GetStudentsByFiltersQry? query);
}