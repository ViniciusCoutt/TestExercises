// See https://aka.ms/new-console-template for more information

using SistemaDeVendas.Business;
using SistemaDeVendas.Repository;

var averageMonthCalc = new SalesBusiness(new SalesRepository()).AverageMonthCalc(04, 2021);
Console.WriteLine($"Valor médio de vendas no Mês: {averageMonthCalc}");
