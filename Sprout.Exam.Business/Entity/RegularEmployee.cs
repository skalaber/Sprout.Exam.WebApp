using Sprout.Exam.Business.Factory;
using System;

namespace Sprout.Exam.Business.Entity
{
    public class RegularEmployee : IEmployee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string TIN { get; set; }
        public decimal Rate => 20000;
        private decimal DailyRate => Rate / 22;
        private readonly decimal TaxRate = 0.12M;

        public decimal Calculate(decimal days)
        {
            return Math.Round(Rate - (DailyRate * days) - (Rate * TaxRate), 2);
        }
    }
}
