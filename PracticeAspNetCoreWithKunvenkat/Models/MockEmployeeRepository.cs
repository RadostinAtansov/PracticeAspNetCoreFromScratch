namespace PracticeAspNetCoreWithKunvenkat.Models
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MockEmployeeRepository : IEmployeeRepository
    {

        private readonly List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){ Id = 1, Name="Radu", Department=Dept.It, Email="hapa_21@abv.bg" },
                new Employee(){ Id = 2, Name="Tedu", Department=Dept.Mechanic, Email="Tedu@abv.bg" },
                new Employee(){ Id = 3, Name="Boju", Department=Dept.Phisics, Email="Boju@abv.bg" },
            };
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return this._employeeList.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeList;
        }
    }
}
