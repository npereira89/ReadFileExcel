using System;
using System.Linq;
using ClosedXML.Excel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Net.Http;

namespace ReadExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Abrir arquivo Excel
            var xls = new XLWorkbook(@"C:\Users\Nuno\Documents\data.xlsx");


            var planilha = xls.Worksheets.First(w => w.Name == "Folha1");
            var totalLinhas = planilha.Rows().Count();

            Console.WriteLine("Os dados no ficheiro Excel são:\n");

            Console.WriteLine("".PadRight(55, '-'));
            Console.WriteLine("Nome".PadRight(10) + "Idade".PadLeft(15) + "Distrito".PadLeft(20));
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
                Console.Write("".PadLeft(35));
                Console.WriteLine(Convert.ToString(planilha.Cell("C" + linha.ToString()).Value.ToString()));

                linha++;

            }


            //fecha Excel
            xls.Dispose();

            Console.WriteLine("".PadRight(10, '-'));
            Console.WriteLine("Feito!!");

            string param = "username=nuno.pereira@pt.softins.com&password=init1234";
            string url = "https://claimopenpt.duckdns.org/auth/login";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = param.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();

            using (Stream stream = request.GetRequestStream())
            {
                byte[] paramAsBytes = Encoding.Default.GetBytes(param);
                stream.Write(paramAsBytes, 0, paramAsBytes.Count());
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                foreach (var cookie in response.Cookies)
                {
                    var properties = cookie.GetType()
                                           .GetProperties()
                                           .Select(p => new
                                           {
                                               Name = p.Name,
                                               Value = p.GetValue(cookie)
                                           });
                }
            }

            Console.ReadKey();
        }

    }
}
