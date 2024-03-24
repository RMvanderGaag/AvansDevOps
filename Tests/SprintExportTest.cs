using AvansDevOps;

namespace Tests;

[Collection("Collection")]
public class SprintExportTest
{
    [Fact]
    public void ExportReportTXT_GeneratesCorrectDTO()
    {
        // Arrange
        var reportExporter = new SprintReportTXT();
        var sprintName = "Sprint 1";
        var expectedDate = DateTime.Now.ToString("dd-MM-yyyy");

        // Act
        var actualDTO = reportExporter.ExportReport(sprintName);

        // Assert
        Assert.Equal($"------HEADER------Sprint report for {sprintName}------HEADER------", actualDTO.Header);
        Assert.Equal("Sprint data comes in here. - TXT formatted data.", actualDTO.Body);
        Assert.Contains(expectedDate, actualDTO.Footer);
    }

    [Fact]
    public void ExportReportPDF_GeneratesCorrectDTO()
    {
        // Arrange
        var reportExporter = new SprintReportPDF();
        var sprintName = "Sprint 1";
        var expectedDate = DateTime.Now.ToString("dd-MM-yyyy");

        // Act
        var actualDTO = reportExporter.ExportReport(sprintName);

        // Assert
        Assert.Equal($"------HEADER------Sprint report for {sprintName}------HEADER------", actualDTO.Header);
        Assert.Equal("Sprint data comes in here. - PDF formatted data.", actualDTO.Body);
        Assert.Contains(expectedDate, actualDTO.Footer);
    }
}