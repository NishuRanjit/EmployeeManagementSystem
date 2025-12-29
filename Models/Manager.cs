namespace TaskEmployeeManagementSystem.Models
{
    public class Manager:Employee
    {
        public int? TeamSize { get; set; }
        public Manager(){
            Role = "Manager";
            }
        public override decimal CalculateBonus()
        {
            return Salary * 0.20m;
        }
    }
}
