using Sprout.Exam.Business.Factory;
using System;

namespace Sprout.Exam.Business.Entity
{
    public class ContractualEmployee : IEmployee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string TIN { get; set; }
        public decimal Rate => 500;

        public decimal Calculate(decimal days)
        {
            return Math.Round(Rate * days, 2);
        }
    }
}
