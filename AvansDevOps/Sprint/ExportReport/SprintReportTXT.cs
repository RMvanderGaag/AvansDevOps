namespace AvansDevOps;

public class SprintReportTXT : SprintReportExporter
{
    protected override string FormatData(string sprintData) => $"{sprintData} - TXT formatted data.";

    protected override void SaveData(SprintReportDTO reportDTO)
    {
        var serializedDTO = System.Text.Json.JsonSerializer.Serialize(reportDTO);
        Console.WriteLine(serializedDTO);
    }
}