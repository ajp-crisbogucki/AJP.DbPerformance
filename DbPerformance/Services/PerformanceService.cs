using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using DbPerformance.Models;

namespace DbPerformance.Services;

public static class PerformanceService
{
    public static void PerformanceOneByOneInsertSingleConnection(List<RowModel> rows)
    {
        var result = new PerformanceModel();
        result.Count = rows.Count;
        result.Name = "Insert one by one single connection";
        var timer = new Stopwatch();
        timer.Start();
        foreach (var row in rows)
        {
            DbServices.AddSingle(row);
        }

        timer.Stop();
        result.Time = timer.ElapsedMilliseconds;

        DisplayService.DisplayResult(result);
    }

    public static void PerformanceOneByOneInsertCommonConnection(List<RowModel> rows)
    {
        var result = new PerformanceModel();
        result.Count = rows.Count;
        result.Name = "Insert one by one common connection";
        var timer = new Stopwatch();

        using SqlConnection connection = new SqlConnection(DbServices.connconnString);
        connection.Open();
        timer.Start();
        foreach (var row in rows)
        {
            DbServices.AddSingle(row, connection);
        }

        connection.Close();
        timer.Stop();
        result.Time = timer.ElapsedMilliseconds;

        DisplayService.DisplayResult(result);
    }

    public static void PerformanceWithBulkCopy(List<RowModel> rows)
    {
        var result = new PerformanceModel();
        result.Count = rows.Count;
        result.Name = "Insert one range - one connection";
        var timer = new Stopwatch();
        
        var dt = ConverService.ToDataTable(rows);
        var dataReader = new DataTableReader(dt);
        
        timer.Start();
        DbServices.WithBulkCopy(dataReader);


        timer.Stop();
        result.Time = timer.ElapsedMilliseconds;

        DisplayService.DisplayResult(result);
    }
}