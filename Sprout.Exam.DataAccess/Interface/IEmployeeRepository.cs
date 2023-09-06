using Sprout.Exam.WebApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Interface
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeModel> Create(EmployeeModel employeeModel);

        public Task<EmployeeModel> Update(EmployeeModel employeeModel);
        public Task<bool> Delete(int employeeId);
        public Task<EmployeeModel> Get(int employeeId);
        public Task<IEnumerable<EmployeeModel>> GetAll();
    }
}
