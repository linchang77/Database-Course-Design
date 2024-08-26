namespace db_course_design.DTOs
{
    public class GuideSalaryRecordResponse
    {
        public DateTime SalaryPaidDate { get; set; }

        public int? SalaryAmount { get; set; }

        public string? Description { get; set; }
    }
}
