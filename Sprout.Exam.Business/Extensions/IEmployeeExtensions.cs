using Sprout.Exam.Business.Entity;
using Sprout.Exam.Business.Factory;
using Sprout.Exam.Common.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.WebApp.Model;
using System;

namespace Sprout.Exam.Business.Extensions
{
    public static class IEmployeeExtensions
    {
        private static readonly string DateDefaultFormat = "yyyy-MM-dd";
        public static EmployeeModel ToModel(this IEmployee entity) => new EmployeeModel()
        {
            Id = entity.Id,
            FullName = entity.FullName,
            BirthDate = entity.BirthDate,
            TIN = entity.TIN,
            EmployeeTypeId = (int)entity.GetEmployeeType()
        };

        public static EmployeeDto ToDto(this IEmployee entity) => new EmployeeDto()
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Birthdate = entity.BirthDate.ToString(DateDefaultFormat),
            Tin = entity.TIN,
            TypeId = (int)entity.GetEmployeeType()
        };

        public static IEmployee ToEntity(this EmployeeModel employee)
        {
            if (employee == null)
                return null;

            ConcreteEmployeeFactory factory = new ConcreteEmployeeFactory();

            return factory.CreateEmployee(GetEmployeeType(employee.EmployeeTypeId), employee.FullName, employee.BirthDate, employee.TIN, employee.Id);
        }

        public static IEmployee ToEntity(this CreateEmployeeDto employee)
        {
            if (employee == null)
                return null;

            ConcreteEmployeeFactory factory = new ConcreteEmployeeFactory();
            return factory.CreateEmployee(GetEmployeeType(employee.TypeId), employee.FullName, employee.Birthdate, employee.Tin);
        }

        public static IEmployee ToEntity(this EditEmployeeDto employee)
        {
            if (employee == null)
                return null;

            ConcreteEmployeeFactory factory = new ConcreteEmployeeFactory();
            return factory.CreateEmployee(GetEmployeeType(employee.TypeId), employee.FullName, employee.Birthdate, employee.Tin, employee.Id);
        }

        private static EmployeeType GetEmployeeType(this IEmployee employee)
        {
            if (employee is RegularEmployee)
                return EmployeeType.Regular;

            if (employee is ContractualEmployee)
                return EmployeeType.Contractual;

            throw new NotSupportedException("Invalid employee");
        }

        private static EmployeeType GetEmployeeType(int employeeTypeId)
        {
            return (EmployeeType)employeeTypeId;
        }
    }
}
