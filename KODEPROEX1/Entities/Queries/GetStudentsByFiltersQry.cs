namespace KODEPROEX1.Entities.Queries;

public class GetStudentsByFiltersQry
{
    public string? SearchTerm { get; set; }
    public DateTime? LessThan { get; set; }
    public DateTime? GreaterThan { get; set; }
}