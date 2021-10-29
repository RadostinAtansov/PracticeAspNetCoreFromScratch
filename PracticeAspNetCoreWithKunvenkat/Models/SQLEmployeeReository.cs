using System.Collections.Generic;

namespace PracticeAspNetCoreWithKunvenkat.Models
{
    public class SQLEmployeeReository : IEmployeeRepository
    {
        private readonly AppDbContex context;

        public SQLEmployeeReository(AppDbContex contex)
        {
            this.context = contex;
        }
        
        public Employee AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
           var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
