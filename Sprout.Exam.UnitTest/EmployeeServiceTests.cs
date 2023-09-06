using Moq;
using NUnit.Framework;
using Sprout.Exam.Business.Extensions;
using Sprout.Exam.Business.Factory;
using Sprout.Exam.Business.Implementation;
using Sprout.Exam.DataAccess.Interface;
using Sprout.Exam.WebApp.Model;
using System;
using System.Threading.Tasks;

namespace Sprout.Exam.UnitTest
{
    public class Tests
    {
        #region CREATEEMPLOYEE
        public EmployeeService SetupCreate(EmployeeModel employee)
        {
            var employeeRepository = new Mock<IEmployeeRepository>();

            employeeRepository.Setup(x => x.Create(It.IsAny<EmployeeModel>())).ReturnsAsync(employee).Verifiable();

            EmployeeService service = new EmployeeService(employeeRepository.Object);

            return service;
        }


        [Test]
        public async Task TestCreatePass()
        {
            var employee = new EmployeeModel()
            {
                BirthDate = DateTime.Now,
                EmployeeTypeId = 1,
                FullName = "Test",
                TIN = "1234"
            };

            var service = SetupCreate(employee);

            var result = await service.Create(employee.ToEntity());

            Assert.AreEqual(employee.FullName, result.FullName);
            Assert.AreEqual(employee.BirthDate, result.BirthDate);
            Assert.AreEqual(employee.TIN, result.TIN);
            Assert.AreEqual(employee.ToEntity().GetType(), result.GetType());
        }

        [Test]
        public void TestCreateFail()
        {
            var employee = new EmployeeModel()
            {
                BirthDate = DateTime.Now,
                EmployeeTypeId = 3,
                FullName = "Test",
                TIN = "1234"
            };

            var service = SetupCreate(employee);
            var ex = Assert.ThrowsAsync<NotSupportedException>(() => service.Create(employee.ToEntity()));

            StringAssert.AreEqualIgnoringCase(ex.Message, "Employee type not supported");
        }
        #endregion

        #region UPDATEEMPLOYEE
        public EmployeeService SetupUpdate(EmployeeModel employee)
        {
            var employeeRepository = new Mock<IEmployeeRepository>();

            employeeRepository.Setup(x => x.Update(It.IsAny<EmployeeModel>())).ReturnsAsync(employee).Verifiable();

            EmployeeService service = new EmployeeService(employeeRepository.Object);

            return service;
        }


        [Test]
        public async Task TestUpdatePass()
        {
            var employee = new EmployeeModel()
            {
                Id = 1,
                BirthDate = DateTime.Now,
                EmployeeTypeId = 1,
                FullName = "Test",
                TIN = "1234"
            };

            var service = SetupUpdate(employee);

            var result = await service.Update(employee.ToEntity());

            Assert.AreEqual(employee.Id, result.Id);
            Assert.AreEqual(employee.FullName, result.FullName);
            Assert.AreEqual(employee.BirthDate, result.BirthDate);
            Assert.AreEqual(employee.TIN, result.TIN);
            Assert.AreEqual(employee.ToEntity().GetType(), result.GetType());
        }

        [Test]
        public void TestUpdateFail()
        {
            var employee = new EmployeeModel()
            {
                Id = 1,
                BirthDate = DateTime.Now,
                EmployeeTypeId = 3,
                FullName = "Test",
                TIN = "1234"
            };

            var service = SetupUpdate(employee);
            var ex = Assert.ThrowsAsync<NotSupportedException>(() => service.Update(employee.ToEntity()));

            StringAssert.AreEqualIgnoringCase(ex.Message, "Employee type not supported");
        }
        #endregion


        #region DELETEEMPLOYEE
        public EmployeeService SetupDelete()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();

            employeeRepository.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(true).Verifiable();

            EmployeeService service = new EmployeeService(employeeRepository.Object);

            return service;
        }


        [Test]
        public async Task TestDeletePass()
        {
            var service = SetupDelete();
            var result = await service.Delete(1);
            Assert.AreEqual(true, result);
        }
        #endregion

        #region GETEMPLOYEE
        public EmployeeService SetupGet(EmployeeModel employeeModel)
        {
            var employeeRepository = new Mock<IEmployeeRepository>();

            employeeRepository.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(employeeModel);

            EmployeeService service = new EmployeeService(employeeRepository.Object);

            return service;
        }


        [Test]
        public async Task TestGetPass()
        {
            var employee = new EmployeeModel()
            {
                Id = 1,
                BirthDate = DateTime.Now,
                EmployeeTypeId = 1,
                FullName = "Test",
                TIN = "1234"
            };

            var service = SetupGet(employee);
            var result = await service.Get(1);

            Assert.AreEqual(employee.Id, result.Id);
            Assert.AreEqual(employee.FullName, result.FullName);
            Assert.AreEqual(employee.BirthDate, result.BirthDate);
            Assert.AreEqual(employee.TIN, result.TIN);
            Assert.AreEqual(employee.ToEntity().GetType(), result.GetType());
        }
        #endregion
    }
}