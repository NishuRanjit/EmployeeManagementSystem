namespace TaskEmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } = "Employee";
        public decimal Salary{ get; set; }
      
        public decimal Bonus{ get; set; }
         public virtual decimal CalculateBonus()
        {
            return Salary * 0.10m;
        }
      
       
    }
}
