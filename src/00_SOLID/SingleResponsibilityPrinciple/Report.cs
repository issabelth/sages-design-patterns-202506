using Microsoft.Data.SqlClient;
using System.Data.Common;

// dotnet add package Microsoft.Data.SqlClient

Report report = new Report { Title = "a", Content = "b" };

Console.WriteLine("Wybierz cel zapisu: (f)ile (d)b");

var selected = Console.ReadLine();

IReportService reportService = ReportServiceFactory.Create(selected);

reportService.Save(report);

// Fabryka
public class ReportServiceFactory
{
    public static IReportService Create(string selected) => selected switch // Match Patterns
    {
        "f" => new FileReportService("report1.pdf"),
        "d" => new DbReportService("datasource=reports.db..."),
        _ => throw new NotSupportedException(),
    };
}


// Dobre podejście - wydzielenie zapisu do osobnych klas
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }
}



// Abstract
public interface IReportService
{
    void Save(Report report);
}


// Concrete A
public class FileReportService : IReportService
{
    private readonly string path;

    public FileReportService(string path)
    {
        this.path = path;
    }

    public void Save(Report report)
    {
        SaveToFile(report, path);
    }

    private void SaveToFile(Report report, string path)
    {
        File.WriteAllText(path, $"{report.Title}\n{report.Content}");
    }


}


// Concrete B
public class DbReportService : IReportService
{
    private readonly string connectionString;

    public DbReportService(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Save(Report report)
    {
        SaveToDb(report, connectionString);
    }

    private void SaveToDb(Report report, string connectionString)
    {
        DbConnection db = new SqlConnection(connectionString);

        db.Open();
        var command = db.CreateCommand();
        command.ExecuteNonQuery();

        // TODO: insert to db
        db.Close();
    }
}