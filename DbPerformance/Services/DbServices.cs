using System.Data.Common;
using System.Data.SqlClient;
using DbPerformance.Models;

namespace DbPerformance.Services;

public static class DbServices
{
    public static string connconnString = "Server=localhost,1433;Database=dbMyProjects;User Id=sa;Password=tajne_haslo;";

    public static void CreateTable()
    {
        using SqlConnection connection = new SqlConnection(connconnString);
        connection.Open();
        var cmd = new SqlCommand(
            @"create table KODY
        (
            KOD_POCZTOWY NVARCHAR(255),
            ADRES        NVARCHAR(255),
            MIEJSCOWOSC  NVARCHAR(255),
            WOJEWODZTWO  NVARCHAR(255),
            POWIAT       NVARCHAR(255)
        )");
        cmd.Connection = connection;
        cmd.ExecuteScalar();
        connection.Close();
    }

    public static int Count()
    {
        using SqlConnection connection = new SqlConnection(connconnString);
        connection.Open();
        var cmd = new SqlCommand("SELECT COUNT(*) FROM dbMyProjects.dbo.KODY");
        cmd.Connection = connection;
        var reader = cmd.ExecuteReader();
        var result = 0;
        while (reader.Read())
        {
            result = (int)reader[0];    
        }
        connection.Close();
        return result;

    }
    public static void AddSingle(RowModel model)
    {
        using SqlConnection connection = new SqlConnection(connconnString);
        connection.Open();
        var cmd = new SqlCommand("INSERT INTO dbMyProjects.dbo.KODY (KOD_POCZTOWY, ADRES, MIEJSCOWOSC, WOJEWODZTWO, POWIAT) VALUES (@KodPocztowy, @Adres, @Miejscowosc, @Wojewodztwo, @Powiat)");
        cmd.Parameters.AddWithValue("@KodPocztowy", model.KodPocztowy);
        cmd.Parameters.AddWithValue("Adres", model.Adres);
        cmd.Parameters.AddWithValue("Miejscowosc", model.Miejscowosc);
        cmd.Parameters.AddWithValue("Wojewodztwo", model.Wojewodztwo);
        cmd.Parameters.AddWithValue("Powiat", model.Powiat);

        cmd.Connection = connection;
        cmd.ExecuteNonQuery();
        connection.Close();
    }
    
    public static void AddSingle(RowModel model, SqlConnection connection)
    {
        var cmd = new SqlCommand("INSERT INTO dbMyProjects.dbo.KODY (KOD_POCZTOWY, ADRES, MIEJSCOWOSC, WOJEWODZTWO, POWIAT) VALUES (@KodPocztowy, @Adres, @Miejscowosc, @Wojewodztwo, @Powiat)");
        cmd.Parameters.AddWithValue("@KodPocztowy", model.KodPocztowy);
        cmd.Parameters.AddWithValue("Adres", model.Adres);
        cmd.Parameters.AddWithValue("Miejscowosc", model.Miejscowosc);
        cmd.Parameters.AddWithValue("Wojewodztwo", model.Wojewodztwo);
        cmd.Parameters.AddWithValue("Powiat", model.Powiat);

        cmd.Connection = connection;
        cmd.ExecuteNonQuery();
    }
    
    public static void WithBulkCopy(DbDataReader rows)
    {
        using SqlConnection connection = new SqlConnection(connconnString);
        connection.Open();
        using (System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(connection))
        {
            bulkCopy.DestinationTableName = "dbo.KODY";
            bulkCopy.WriteToServer(rows);
        }
        connection.Close();
    }
}