using System;
using System.Linq;
using ClosedXML.Excel;
using System.Text;
using System.Net;
using System.IO;
using ToolsQA;

namespace ReadExcel
{
    class Program
    {
        static void Main()
        {
            // Abrir arquivo Excel
            //var xls = new XLWorkbook(@"C:\Users\3100945\Documents\data.xlsx"); -< PC do trabalho
            var xls = new XLWorkbook(@"C:\Users\Nuno\Documents\data.xlsx");


            var planilha = xls.Worksheets.First(w => w.Name == "Clientes");
            var totalLinhas = planilha.Rows().Count();

            Console.WriteLine("Os dados no ficheiro Excel são:\n");

            Console.WriteLine("".PadRight(55, '-'));
            Console.WriteLine("Nome".PadRight(10) + "Distrito".PadLeft(20));
            Console.WriteLine("".PadRight('-'));

            // primeira linha é o cabecalho
            var linha = 2;

            while (true)
            {

                var nome = planilha.Cell("A" + linha.ToString()).Value.ToString();

                if (string.IsNullOrEmpty(nome))
                {
                    break;
                }

                Console.Write(nome.PadRight(5));
                Console.Write("".PadLeft(15));
                Console.WriteLine(Convert.ToString(planilha.Cell("B" + linha.ToString()).Value.ToString()));
                Console.Write("".PadLeft(35));
                Console.WriteLine(Convert.ToString(planilha.Cell("C" + linha.ToString()).Value.ToString()));

                linha++;

            }


            //fecha Excel
            xls.Dispose();

            Console.WriteLine("".PadRight(10, '-'));

            ConetaSite liga_ao_site = new ConetaSite();

            liga_ao_site.AbreLigacao();
            liga_ao_site.IniciaLigacao();
            liga_ao_site.FechaLigacao();

            Console.ReadKey();
        }

    }
    
}
