using Sprout.Exam.Business.Factory;
using Sprout.Exam.Common.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Interface
{
    public interface IEmployeeService
    {
        public Task<IEmployee> Create(IEmployee employee);

        public Task<IEmployee> Update(IEmployee employee);
        public Task<bool> Delete(int employeeId);
        public Task<IEmployee> Get(int employeeId);
        public Task<IEnumerable<IEmployee>> GetAll();
        public decimal? Calculate(IEmployee employee, decimal? absentDays, decimal? workedDays);
    }
}
