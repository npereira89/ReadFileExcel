using System;
using System.Linq;
using ClosedXML.Excel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using RestSharp;

namespace ReadExcel
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Abrir arquivo Excel
            var xls = new XLWorkbook(@"C:\Users\3100945\Documents\data.xlsx");


            var planilha = xls.Worksheets.First(w => w.Name == "Folha1");
            var totalLinhas = planilha.Rows().Count();

            Console.WriteLine("Os dados no ficheiro Excel são:\n");

            Console.WriteLine("".PadRight(55, '-'));
            Console.WriteLine("Nome".PadRight(10) + "Idade".PadLeft(15));
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
                Console.WriteLine(Convert.ToInt32(planilha.Cell("B" + linha.ToString()).Value.ToString()));


                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://claimopenpt.duckdns.org/auth/login/");

                myReq.GetResponse();
                
                linha++;

            }

            //fecha Excel
            xls.Dispose();

            Console.WriteLine("".PadRight(10,'-'));
            Console.WriteLine("Feito!!");

            Console.ReadKey();
        
        }
    }
}
