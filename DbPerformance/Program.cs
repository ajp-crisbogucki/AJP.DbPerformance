// See https://aka.ms/new-console-template for more information

using DbPerformance;
using DbPerformance.Services;

Console.WriteLine("Test performance start");

var data= FileService.ReadCsv("./../../../kody.csv");
//DbServices.CreateTable();

//PerformanceService.PerformanceOneByOneInsertSingleConnection(data);
//PerformanceService.PerformanceOneByOneInsertCommonConnection(data);
PerformanceService.PerformanceWithBulkCopy(data);
PerformanceService.PerformanceWithBulkCopy(data);
PerformanceService.PerformanceWithBulkCopy(data);
PerformanceService.PerformanceWithBulkCopy(data);
PerformanceService.PerformanceWithBulkCopy(data);
PerformanceService.PerformanceWithBulkCopy(data);

Console.WriteLine("Test performance stop");
