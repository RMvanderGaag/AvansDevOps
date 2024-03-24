namespace AvansDevOps;

public abstract class SprintReportExporter
{
    public string SprintName { get; set; }
    public DateTime ExportDate { get; set; }
    
    // TEMPLATE PATTERN: here we are defining the skeleton of the algorithm.
    public SprintReportDTO ExportReport(string sprintName)
    {
        SprintName = sprintName;
        ExportDate = DateTime.Now;

        var reportDTO = new SprintReportDTO()
        {
            Header = CreateHeader(),
            Body = FormatData("Sprint data comes in here."),
            Footer = CreateFooter()
        };
        
        SaveData(reportDTO);
        return reportDTO;
    }

    private string CreateHeader() => $"------HEADER------Sprint report for {SprintName}------HEADER------";
    private string CreateFooter() => $"-----FOOTER-----Exported on {ExportDate:dd-MM-yyyy}-----FOOTER-----";
    protected abstract string FormatData(string sprintData);
    protected abstract void SaveData(SprintReportDTO reportDTO);
}