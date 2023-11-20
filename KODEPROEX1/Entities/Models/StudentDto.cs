namespace KODEPROEX1.Entities.Models;

// DTO to handle the principal information that we want
public class StudentDto
{
    public int IdentityCard { get; set; }
    public string Names { get; set; }
    public string SchoolName { get; set; }
    public DateTime? DateOfBirth { get; set; }
}