using System.Collections.Generic;
using System.Linq;

namespace tp1.Models.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Sofien ben ali", Departement = "comptabilité", Salary = 1000 },
                new Employee { Id = 2, Name = "Mourad triki", Departement = "RH", Salary = 1500 },
                new Employee { Id = 3, Name = "ali ben mohamed", Departement = "informatique", Salary = 1700 },
                new Employee { Id = 4, Name = "tarak aribi", Departement = "informatique", Salary = 1100 }
            };
        }

        public void Add(Employee e)
        {
            _employees.Add(e);
        }

        public void Delete(int id)
        {
            Employee employeeToDelete = FindByID(id);
            if (employeeToDelete != null)
            {
                _employees.Remove(employeeToDelete);
            }
        }

        public Employee FindByID(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IList<Employee> GetAll()
        {
            return _employees;
        }

        public List<Employee> Search(string term)
        {
            if (!string.IsNullOrEmpty(term))
                return _employees.Where(a => a.Name.Contains(term)).ToList();
            else
                return _employees;
        }

        public void Update(int id, Employee newemployee)
        {
            Employee employeeToUpdate = FindByID(id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = newemployee.Name;
                employeeToUpdate.Departement = newemployee.Departement;
                employeeToUpdate.Salary = newemployee.Salary;
            }
        }

        public double SalaryAverage()
        {
            return _employees.Average(x => x.Salary);
        }
        public double MaxSalary()
        {
            return _employees.Max(x => x.Salary);
        }
        public int HrEmployeesCount()
        {
            return _employees.Where(x => x.Departement == "HR").Count();
        }
    }
}
