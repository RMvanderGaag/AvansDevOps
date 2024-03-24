namespace AvansDevOps;

public class SprintReportPDF : SprintReportExporter
{
    protected override string FormatData(string sprintData)
    {
        return $"{sprintData} - PDF formatted data.";
    }

    protected override void SaveData(string formattedData)
    {
        Console.WriteLine(formattedData);
        Console.WriteLine("PDF file saved.");
    }
}