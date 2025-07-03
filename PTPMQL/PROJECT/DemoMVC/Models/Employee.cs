namespace DemoMVC.Models
{
    public class Empoyee : Person
    {
        public required string EmpoyeeID { get; set; }
        public int Age { get; set; }
    }
}