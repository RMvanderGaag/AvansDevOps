namespace AvansDevOps;

public class SprintReportPDF : SprintReportExporter
{
    // Er wordt nog niks gedaan met de sprint data. Eigenlijk wil je dit doorsturen naar de save data functie zodat het daarin geprint kan worden.
    protected override string FormatData(string sprintData)
    {
        return "Formatted PDF data.";
    }

    protected override void SaveData(string formattedData)
    {
        Console.WriteLine("Saving formatted PDF data to new PDF file.");
    }
}