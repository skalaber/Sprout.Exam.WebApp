using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Interface;
using Sprout.Exam.WebApp.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext DataContext)
        {
            _dataContext = DataContext;    
        }
        public async Task<EmployeeModel> Create(EmployeeModel employeeModel)
        {
            var added = await _dataContext.Employee.AddAsync(employeeModel);
            await _dataContext.SaveChangesAsync();

            return added.Entity;
        }

        public async Task<EmployeeModel> Update(EmployeeModel employeeModel)
        {
            var existing = await _dataContext.Employee.FirstOrDefaultAsync(x => x.Id == employeeModel.Id && !x.IsDeleted);

            if (existing == null)
                return null;

            existing.FullName = employeeModel.FullName;
            existing.BirthDate = employeeModel.BirthDate;
            existing.TIN = employeeModel.TIN;
            existing.EmployeeTypeId = employeeModel.EmployeeTypeId;
            
            await _dataContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int employeeId)
        {
            var existing = await _dataContext.Employee.FirstOrDefaultAsync(x => x.Id == employeeId && !x.IsDeleted);

            if (existing == null)
                return false;

            existing.IsDeleted = true;

            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<EmployeeModel> Get(int employeeId) => await _dataContext.Employee.FirstOrDefaultAsync(x => x.Id == employeeId && !x.IsDeleted);

        public async Task<IEnumerable<EmployeeModel>> GetAll() => await _dataContext.Employee.Where(x => !x.IsDeleted).ToListAsync();
    }
}
