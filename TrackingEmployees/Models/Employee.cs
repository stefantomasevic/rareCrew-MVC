namespace TrackingEmployees.Models
{
    public class Employee
    {
        public string Id { get; set; }

        public string EmployeeName { get; set; }

        public DateTimeOffset StarTimeUtc { get; set; }

        public DateTimeOffset EndTimeUtc { get; set; }

        public string EntryNotes { get; set; }
     
    }
}
