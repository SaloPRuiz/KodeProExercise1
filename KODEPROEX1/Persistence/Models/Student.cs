namespace KODEPROEX1.Persistence.Models
{
    public partial class Student
    {
        public int IdentityCard { get; set; }
        public string? Names { get; set; }
        public string? Surnames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? IdSchool { get; set; }

        public virtual School? IdSchoolNavigation { get; set; }
    }
}
