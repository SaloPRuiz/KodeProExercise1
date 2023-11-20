using KODEPROEX1.Entities.Models;
using KODEPROEX1.Entities.Queries;
using KODEPROEX1.Implementation.Interfaces;
using KODEPROEX1.Persistence;

namespace KODEPROEX1.Implementation.Repositories;

public class StudentRepo : IStudentRepo
{
    private readonly KODEPROExerciseContext _ctx;

    public StudentRepo(KODEPROExerciseContext ctx)
    {
        _ctx = ctx;
    }

    // Principal method to search and filter our students
    public List<StudentDto> GetStudentsByFilters(GetStudentsByFiltersQry? query)
    {
        if (query is null)
        {
            // Display all students if the search term is empty
            return _ctx.Students.Select(x => new StudentDto
            {
                IdentityCard = x.IdentityCard,
                Names = $"{x.Names} {x.Surnames}",
                SchoolName = x.IdSchoolNavigation.Name,
                DateOfBirth = x.DateOfBirth
            }).ToList();
        }

        // Perform the search based on name, surname, date of birth, or school name
        var filteredStudents = _ctx.Students
            .Where(x =>
                (query.LessThan == null || x.DateOfBirth <= query.LessThan) &&
                (query.GreaterThan == null || x.DateOfBirth >= query.GreaterThan) &&
                (query.SearchTerm == null || (x.Names.Contains(query.SearchTerm) ||
                 x.Surnames.Contains(query.SearchTerm) ||
                 x.DateOfBirth.ToString().Contains(query.SearchTerm) ||
                 x.IdSchoolNavigation.Name.Contains(query.SearchTerm))))
            .Select(x => new StudentDto
            {
                IdentityCard = x.IdentityCard,
                Names = $"{x.Names} {x.Surnames}",
                SchoolName = x.IdSchoolNavigation.Name,
                DateOfBirth = x.DateOfBirth
            }).ToList();

        return filteredStudents;
    }
}