namespace AvansDevOps;

public abstract class SprintReportExporter
{
    public string SprintName { get; set; }
    public DateTime ExportDate { get; set; }
    
    // TEMPLATE PATTERN: here we are defining the skeleton of the algorithm.
    public void ExportReport(string sprintName)
    {
        SprintName = sprintName;
        ExportDate = DateTime.Now;
        string header = CreateHeader();
        string footer = CreateFooter();
        var formattedData = FormatData("Sprint data comes in here.");
        var reportContent = $"{header}\n{formattedData}\n{footer}";

        SaveData(reportContent);
    }

    private string CreateHeader()
    {
        return $"------HEADER------\nSprint report for {SprintName}\n------HEADER------\n";
    }
    
    private string CreateFooter()
    {
        return $"\n-----FOOTER-----\nExported on {ExportDate:dd-MM-yyyy}\n-----FOOTER-----\n";
    }
    
    protected abstract string FormatData(string sprintData);
    protected abstract void SaveData(string sprintData);
}