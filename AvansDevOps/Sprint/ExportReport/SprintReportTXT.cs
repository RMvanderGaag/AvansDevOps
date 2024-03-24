namespace AvansDevOps;

public class SprintReportTXT : SprintReportExporter
{
    protected override string FormatData(string sprintData)
    {
        return $"{sprintData} - TXT formatted data.";
    }

    protected override void SaveData(string formattedData)
    {
        Console.WriteLine(formattedData);
        Console.WriteLine("TXT file saved.");
    }
}