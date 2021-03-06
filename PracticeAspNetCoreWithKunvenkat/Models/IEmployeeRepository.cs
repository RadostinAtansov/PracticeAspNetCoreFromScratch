namespace PracticeAspNetCoreWithKunvenkat.Models
{

    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetEmployees();
        Employee AddEmployee(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
    }
}
