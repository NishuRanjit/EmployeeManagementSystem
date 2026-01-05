namespace TaskEmployeeManagementSystem.Models
{
    public class Manager:Employee
    {
        private int? teamsize;
        public int? TeamSize
        {
            get
            {
                return teamsize;
            }
            set
            {
                if (value >= 0)
                {
                    teamsize = value;
                    
                }
                else
                {
                    throw new Exception("TeamSize cannot be negative or empty");
                }
            }
        }
            
        public Manager(){
            Role = "Manager";
            }
        public override decimal CalculateBonus()
        {
            return Salary * 0.20m;
        }
    }
}
