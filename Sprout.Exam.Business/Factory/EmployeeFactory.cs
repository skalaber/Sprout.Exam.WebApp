using Sprout.Exam.Common.Enums;
using System;

namespace Sprout.Exam.Business.Factory
{
    public abstract class EmployeeFactory
    {
        protected abstract IEmployee CreateEmployee(EmployeeType employeeType);

        public IEmployee CreateEmployee(EmployeeType employeeType, string name, DateTime birthDate, string tin) 
        {
           var employee = CreateEmployee(employeeType);

            employee.FullName = name;
            employee.BirthDate = birthDate;
            employee.TIN = tin;

            return employee;
        }
        public IEmployee CreateEmployee(EmployeeType employeeType, string name, DateTime birthDate, string tin, int id)
        {
            var employee = CreateEmployee(employeeType, name, birthDate, tin);

            employee.Id = id;
            return employee;
        }
    }
}
