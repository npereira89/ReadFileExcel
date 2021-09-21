using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using ReadExcel;

namespace ToolsQA
{
    public class ConetaSite 
    {
        IWebDriver driver;

     
        public void IniciaLigacao()
        {

            driver = new FirefoxDriver();
            Console.WriteLine("vou ligar!!");
        }

  
        public void AbreLigacao()
        {
            Console.WriteLine("A ligar...");

            IWebDriver liga = new FirefoxDriver();

            liga.Navigate().GoToUrl("https://claimopenpt.duckdns.org/auth/login");

            //

            liga.FindElement(By.Name("email")).SendKeys("nuno.pereira@pt.softinsa.com");
            Console.WriteLine("Login entered");

            liga.FindElement(By.Name("password")).SendKeys("init1234");
            Console.WriteLine("password entered");

            liga.FindElement(By.TagName("button")).Click();

            liga.Navigate().GoToUrl("https://claimopenpt.duckdns.org/timesheet");

            // Colocar Data do registo



            // Colocar ID do projeto

            liga.FindElement(By.XPath("//button[.=' Insert Line ']")).Click();
            liga.FindElement(By.CssSelector("[ng-model*='obj.type_id']")).SendKeys("IN PROJECT");

            // Colocar Consultoria


            // Colocar Horas de registo

            // Colocar Id do catalogo OpenSGC
        }


        public void FechaLigacao()
        {
            Console.WriteLine("Adeus!");
            driver.Quit(); //fecha o browser

        }
        
    }
}