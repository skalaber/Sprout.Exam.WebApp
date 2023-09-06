using System;

namespace Sprout.Exam.Business.Factory
{
    public interface IEmployee
    {
        public decimal Calculate(decimal days);
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string TIN { get; set; }
        public decimal Rate { get; }
    }
}
