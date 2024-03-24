using AvansDevOps;

namespace Tests;

[Collection("Collection")]
public class SprintExportTest
{
    [Fact]
    public void ExportReportTXT_GeneratesCorrectOutput()
    {
        // Arrange
        var reportExporter = new SprintReportTXT();
        var sprintName = "Sprint 1";
        
        StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        // Act
        reportExporter.ExportReport(sprintName);

        // Assert
        var output = sw.ToString();
        Assert.Contains("------HEADER------", output);
        Assert.Contains("Sprint report for Sprint 1", output);
        Assert.Contains("Sprint data comes in here. - TXT formatted data.", output);
        Assert.Contains($"Exported on {DateTime.Now:dd/MM/yyy}", output);
        Assert.Contains("-----FOOTER-----", output);
        Assert.Contains("TXT file saved.", output);
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void ExportReportPDF_GeneratesCorrectOutput()
    {
        // Arrange
        var reportExporter = new SprintReportPDF();
        var sprintName = "Sprint 1";

        StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        // Act
        reportExporter.ExportReport(sprintName);

        // Assert
        var output = sw.ToString();
        Assert.Contains("------HEADER------", output);
        Assert.Contains("Sprint report for Sprint 1", output);
        Assert.Contains("Sprint data comes in here. - PDF formatted data.", output);
        Assert.Contains($"Exported on {DateTime.Now:dd/MM/yyy}", output);
        Assert.Contains("-----FOOTER-----", output);
        Assert.Contains("PDF file saved.", output);

        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
}