using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 5.
 */
Report report = new Report { Title = "a", Content = "b" };

Console.WriteLine("wybierz cel zapisu: (f)ile (d)b");

var selected = Console.ReadLine();

// nie, bo przy kolejnych trzeba IFy i nowe wiersze i bez sensu
//IReportService reportService = new FileReportService(path: "");

// zamiast IFa tutaj stworzymy factory
IReportService reportService = ReportServiceFactory.Create(selected);

reportService.Save(report);

/*
 * 6.
 * Dzięki fabryce - do osobnego pliku - możemy definiować tylko tę fabrykę, a nie całość apki.
 */
public class ReportServiceFactory
{
    // wersja 1
    public static IReportService Create(string selected)
    {
        //switch (selected)
        //{
        //    case "f": return new FileReportService(path: "");
        //    case "d": return new DbReportService(connString: "");
        //    default: throw new NotSupportedException("Nieobsługiwana");
        //}

        return selected switch // pattern matching - trochę IF, nie muszę robić CASE, moge robić >, <, and, or, typ badać itp.
        {
            "f" => new FileReportService(path: ""),
            "d" => new DbReportService(connectionString: ""),
            _ => throw new NotSupportedException("Nieobsługiwana"),
        };
    }

    // wersja 2 - z użyciem lambdy, to samo
    public static IReportService CreateNewWay(string selected) => selected switch
    {
        "f" => new FileReportService(path: ""),
        "d" => new DbReportService(connectionString: ""),
        _ => throw new NotSupportedException("Nieobsługiwana"),
    };
}



// Złe podejście:
/*
 * 1.
 * Klasa raport nie powinna być odp. za zapis do tego, tamtego itp.
 * Przechowywanie danych i metody powinny być w innej klasie.
 * Czasami można to mieszać, ale na pewno nie tak jak tutaj.
 * Klasa pownna mieć tylko definicję, a metody takie ogólne powinny być już gdzie indziej.
 * Mogą być tylko metody np. czyszczenia tytułu z czegoś, ale też lepiej nie tutaj, bo można białe znaki chcieć
 * usunąć z maila itp., a nie tylko raportów.
 */
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }

    // Wywalamy stąd i wrzucamy do osobnej klasy
    //public void SaveToFile(string path)
    //{
    //    File.WriteAllText(path, $"{Title}\n{Content}");
    //}
}

/*
 * 2.
 * Dodajemy klasę ReportService i tutaj dać metody do zapisu i przekazywać obiekt Report.
 */

public class ReportService
{
    public void SaveToFile(Report report, string path)
    {
        // ...
    }

    /*
     * Też nie. Trzeba osobnej klasy do obsługi pliku i osobnej do obsługi bazy danych.
     */
    public void SaveToDb(Report report, string path)
    {
        // ...
    }
}

/*
 * 3. Tworzymy osobe klasy FileReportService i DbReportService
 */
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

/*
 * 4. Tworzymy interfejs 
 */
public interface IReportService
{
    void Save(Report report);
}