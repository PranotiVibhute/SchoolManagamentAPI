namespace WebApiAssiment3.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int ClassId { get; set; }
    }
}
