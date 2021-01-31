using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentTask.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        List<Employee> GetEmployees();
        void CreateEmployee(Employee emp);
        List<Employee> DeleteEmployee(int Id);

        List<Employee> UpdateEmployee(int Id, Employee emp);
    }
}
