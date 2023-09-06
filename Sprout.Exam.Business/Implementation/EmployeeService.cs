using Sprout.Exam.Business.Entity;
using Sprout.Exam.Business.Extensions;
using Sprout.Exam.Business.Factory;
using Sprout.Exam.Business.Interface;
using Sprout.Exam.DataAccess.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository EmployeeRepository { get; set; }

        public async Task<IEmployee> Create(IEmployee employee)
        {
            var model = await EmployeeRepository.Create(employee.ToModel());
            return model.ToEntity();
        }

        public async Task<IEmployee> Update(IEmployee employee)
        {
            var model = await EmployeeRepository.Update(employee.ToModel());
            return model.ToEntity();
        }

        public Task<bool> Delete(int employeeId)
        {
            return EmployeeRepository.Delete(employeeId);
        }

        public async Task<IEmployee> Get(int employeeId)
        {
            var model = await EmployeeRepository.Get(employeeId);
            return model.ToEntity();
        }

        public decimal? Calculate(IEmployee employee, decimal? absentDays, decimal? workedDays)
        {
            if (employee is RegularEmployee && absentDays.HasValue)
                return employee.Calculate(absentDays.Value);

            if (employee is ContractualEmployee && workedDays.HasValue)
                return employee.Calculate(workedDays.Value);

            return null;
        }

        public async Task<IEnumerable<IEmployee>> GetAll()
        {
            var employees = await EmployeeRepository.GetAll();
            return employees.Select(x => x.ToEntity());
        }

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }
    }
}
