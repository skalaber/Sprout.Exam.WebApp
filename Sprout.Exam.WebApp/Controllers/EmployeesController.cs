using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Common.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.Business.Interface;
using Sprout.Exam.Business.Extensions;
using Sprout.Exam.Business.Entity;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService EmployeeService { get; }
        IValidator<CreateEmployeeDto> CreateValidator { get; }
        IValidator<EditEmployeeDto> EditValidator { get; }
        IValidator<CalculateRequestDto> CalculateRequestValidator { get; }

        public EmployeesController(IEmployeeService employeeService,
            IValidator<CreateEmployeeDto> createValidator,
            IValidator<EditEmployeeDto> editValidator,
            IValidator<CalculateRequestDto> calculateRequestValidator)
        {
            EmployeeService = employeeService;
            CreateValidator = createValidator;
            EditValidator = editValidator;
            CalculateRequestValidator = calculateRequestValidator;
        }

        /// <summary>
        /// Gets all employee records
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await EmployeeService.GetAll();
            return Ok(result.Select(x => x.ToDto()));
        }

        /// <summary>
        /// Get specific employee
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await EmployeeService.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result.ToDto());
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {
            var validationResult = await EditValidator.ValidateAsync(input);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());

            var result = await EmployeeService.Update(input.ToEntity());

            if (result == null)
                return NotFound();

            return Ok(result.ToDto());
        }

        /// <summary>
        /// Create employee
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            var validationResult = await CreateValidator.ValidateAsync(input);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());

            var result = await EmployeeService.Create(input.ToEntity());

            return Created($"/api/employees/{result.Id}", result);
        }


        /// <summary>
        /// Delete employee
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await EmployeeService.Delete(id);
            if (!result)
                return NotFound();

            return Ok(id);
        }

        /// <summary>
        /// calculate salary
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate([FromBody] CalculateRequestDto request)
        {
            var validationResult = await CalculateRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());

            var result = await EmployeeService.Get(request.Id);

            if (result == null)
                return NotFound();

            if (EmployeeService.Calculate(result, request.AbsentDays, request.WorkedDays) is decimal salary)
                return Ok(salary);
            else
                return BadRequest();
        }

    }
}
