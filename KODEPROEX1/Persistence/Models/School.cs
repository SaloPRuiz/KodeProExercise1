namespace KODEPROEX1.Persistence.Models
{
    public partial class School
    {
        public School()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? IdCountry { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
