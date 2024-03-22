namespace AvansDevOps;

public abstract class SprintReportExporter
{
    // TEMPLATE PATTERN: here we are defining the skeleton of the algorithm.
    public void ExportReport(string sprintData)
    {
        var formattedData = FormatData(sprintData);
        SaveData(formattedData);
    }
    
    protected abstract string FormatData(string sprintData);
    protected abstract void SaveData(string formattedData);
}