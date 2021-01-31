using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentTask.Models
{
    public class EmployeeData:IEmployeeRepository
    {
        public List<Employee> _employeeList;

        public EmployeeData()
        {
            _employeeList = new List<Employee>
            {
                new Employee() { EmpNo=1, FirstName="Rajesh", LastName = "Sirivella", Email = "rajeshaug24@gmail.com"},
                new Employee() { EmpNo=2, FirstName="Siva", LastName = "Kavuri", Email = "siva.k@gmail.com"}
            };
        }

        public void CreateEmployee(Employee emp)
        {
            _employeeList.Add(emp);
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.EmpNo == Id);
        }

        public List<Employee> UpdateEmployee(int Id, Employee emp)
        {
            //loadList.Where(p => p.EmpNo == obj.EmpNo).Update(); 
            foreach(var e in _employeeList)
            {
                if(e.EmpNo == emp.EmpNo)
                {
                    e.FirstName = emp.FirstName;
                    e.LastName = emp.LastName;
                    e.Email = emp.Email;
                }
            }
            return _employeeList;
        }
        public List<Employee> GetEmployees()
        {
            return _employeeList;
        }

        public List<Employee> DeleteEmployee(int Id)
        {
            Employee objEmp = _employeeList.FirstOrDefault(e => e.EmpNo == Id);
            _employeeList.Remove(objEmp);
            return _employeeList;
        }
    }
}
