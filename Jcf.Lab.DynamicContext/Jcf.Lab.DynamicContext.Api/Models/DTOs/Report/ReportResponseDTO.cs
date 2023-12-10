namespace Jcf.Lab.DynamicContext.Api.Models.DTOs.Report
{
    public class ReportResponseDTO
    {
        public Guid Id { get; set; }
        public string MyClient { get; set; }
        public string? MyText { get; set; }
        public string? MyTest { get; set; }

        public ReportResponseDTO() { }
    }
}
