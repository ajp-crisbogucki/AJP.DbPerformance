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
    
    public static void PerformanceWithEfOneByOneInsert(List<RowModel> rows)
    {
        var result = new PerformanceModel();
        result.Count = rows.Count;
        result.Name = "Insert one by one by Entity Framework ";
        var timer = new Stopwatch();
        timer.Start();
        foreach (var row in rows)
        {
            DbServices.AdSingleByEf(row);
        }
        timer.Stop();
        result.Time = timer.ElapsedMilliseconds;

        DisplayService.DisplayResult(result);
    }
    
    public static void PerformanceWithEfOnePackage(List<RowModel> rows)
    {
        var result = new PerformanceModel();
        result.Count = rows.Count;
        result.Name = "Insert one package by Entity Framework ";
        var timer = new Stopwatch();
        timer.Start();
        DbServices.AddOnePackageByEf(rows);
        timer.Stop();
        result.Time = timer.ElapsedMilliseconds;
        DisplayService.DisplayResult(result);
    }
    
    public static void PerformanceWithEfPackageSize(List<RowModel> rows)
    {
        var result = new PerformanceModel();
        result.Count = rows.Count;
        result.Name = "Insert package size 1000 row by EF";
        var timer = new Stopwatch();
        timer.Start();
        DbServices.AddOnePackageSizeByEf(rows);
        timer.Stop();
        result.Time = timer.ElapsedMilliseconds;
        DisplayService.DisplayResult(result);
    }
}