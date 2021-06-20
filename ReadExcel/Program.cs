using System;
using System.Linq;
using ClosedXML.Excel;

namespace ReadExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            var xls = new XLWorkbook(@"C:\Users\Nuno\Documents\data.xlsx");
           var planilha = xls.Worksheets.First(w => w.Name == "Folha1");
            var totalLinhas = planilha.Rows().Count();
            // primeira linha é o cabecalho
            for (int l = 2; l <= totalLinhas; l++)
            {
                var nome = planilha.Cell($"A{l}").Value.ToString();
                var idade = int.Parse(planilha.Cell($"B{l}").Value.ToString());
                Console.WriteLine($"{nome} - {idade} ");
            }
        }
    }
}
