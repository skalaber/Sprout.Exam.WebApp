using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Common.DataTransferObjects
{
    public class CalculateRequestDto
    {
        public int Id { get; set; }
        public decimal? AbsentDays { get; set; }
        public decimal? WorkedDays { get; set; }
    }
}
