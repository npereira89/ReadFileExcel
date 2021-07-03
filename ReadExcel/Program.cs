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

                linha++;

            }

            //fecha Excel
            xls.Dispose();

            Console.WriteLine("".PadRight(10,'-'));
            Console.WriteLine("Feito!!");

            Console.ReadKey();
        
        }

        protected void LinkWebpage(object sender, EventArgs e)
        {
            //Vai ligar-se ao portal de pedidos

            WebRequest request = WebRequest.Create("https://claimopenpt.duckdns.org/auth/login");
            request.Method = "GET";
            request.Credentials = new NetworkCredential("nuno.pereira@pt.softinsa.com", "init1234");
            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            //envia para o servidor a autenticação
            Stream dataStream = response.GetResponseStream();
         
        }
        protected void Page_Load( EventArgs e)
        {

            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("https://claimopenpt.duckdns.org/timesheet");
            // Set the Method property of the request to POST.
            request.Method = "POST";

            // Create POST data and convert it to a byte array.
            string postData = "Teste";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

        }
    }
}
