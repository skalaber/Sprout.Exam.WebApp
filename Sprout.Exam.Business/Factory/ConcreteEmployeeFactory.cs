using Sprout.Exam.Business.Entity;
using Sprout.Exam.Common.Enums;
using System;

namespace Sprout.Exam.Business.Factory
{
    public class ConcreteEmployeeFactory : EmployeeFactory
    {
        protected override IEmployee CreateEmployee(EmployeeType employeeType)
        {
            switch (employeeType)
            {
                case EmployeeType.Regular:
                    return new RegularEmployee();
                case EmployeeType.Contractual: 
                    return new ContractualEmployee();
                default:
                    throw new NotImplementedException("Employee type not yet implemented");
            }
        }
    }
}
