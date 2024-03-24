namespace AvansDevOps;

public class SprintReportPDF : SprintReportExporter
{
    protected override string FormatData(string sprintData) => $"{sprintData} - PDF formatted data.";

    protected override void SaveData(SprintReportDTO reportDTO)
    {
        var serializedDTO = System.Text.Json.JsonSerializer.Serialize(reportDTO);
        Console.WriteLine(serializedDTO);
    }
}