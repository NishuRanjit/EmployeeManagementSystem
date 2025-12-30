namespace TaskEmployeeManagementSystem.Models
{
    public class Employee
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value > 0 && value<70)
                {
                    id = value;

                }
                else
                {
                   throw new Exception("Id cannot be empty or zero");
                }
            }
        }
        public string Name { get; set; }
        public string Role { get; set; } = "Employee";

        private decimal salary;
        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value > 0)
                {
                    salary = value;
                }
                else
                {
                    throw new Exception("Salary cannot be empty and should be greater than zero");
                }
            }
        }

        private decimal bonus;
        public decimal Bonus
        {
            get
            {
                return bonus;
            }
            set
            {
                if (value > 0)
                {
                    bonus = value;
                }
                else
                {
                    throw new Exception("Bonus cannot be negative");
                }
            }
        }
         public virtual decimal CalculateBonus()
        {
            return Salary * 0.10m;
        }
      
       
    }
}
