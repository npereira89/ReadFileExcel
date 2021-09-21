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

            // Faz a ligação com as credenciais de acesso

            liga.FindElement(By.Name("email")).SendKeys("nuno.pereira@pt.softinsa.com");
            Console.WriteLine("Login entered");

            liga.FindElement(By.Name("password")).SendKeys("init1234");
            Console.WriteLine("password entered");

            liga.FindElement(By.TagName("button")).Click();

            liga.Navigate().GoToUrl("https://claimopenpt.duckdns.org/timesheet");

            // Vai para a semana especifica
            liga.FindElement(By.CssSelector("[ng-click='addObject()']")).Click();

            // Colocar Data do registo
            liga.FindElement(By.CssSelector("[ng-model='obj.weekday']")).SendKeys("2021-10-11");

            // Colocar ID do projeto e o tipo de projeto
            //liga.FindElement(By.XPath("//button[.=' Insert Line ']")).Click();
            liga.FindElement(By.CssSelector("[ng-model='obj.type_id']")).SendKeys("IN PROJECT");

            //Adiciona o pedido para registo de hora
            liga.FindElement(By.CssSelector("[class='glyphicon glyphicon-search']")).Click();
            liga.FindElement(By.CssSelector("[ng-model='searchCond']")).SendKeys("S190710_000430");
            liga.FindElement(By.CssSelector("[ng-click='initWorkObjects(1, searchCol, searchCond)']")).Click();
            //liga.FindElement(By.XPath("//ng-repeat='props in scopeProp.data'//'client_id':'S190710_000430','summary':'COLOCAÇÃO DE FONTES / BINÁRIOS / POWERBUILDER'}']")).Click();
            liga.FindElement(By.CssSelector("[ng-click='handleSelectClick(props)']")).Click();

            // Colocar Consultoria

            liga.FindElement(By.CssSelector("[ng-options='activity.activity_id']")).SendKeys("CS");

            // Colocar Horas de registo

            liga.FindElement(By.CssSelector("[ng-options='activity.activity_id']")).SendKeys("CS");
            liga.FindElement(By.CssSelector("[ng-model='value']")).SendKeys("0.5");
            liga.FindElement(By.CssSelector("[ng-model='obj.claim_type']")).SendKeys("Normal");

            // Colocar Id do catalogo OpenSGC

            liga.FindElement(By.CssSelector("[ng-model='obj.observations']")).SendKeys("17016");
        }


        public void FechaLigacao()
        {
            Console.WriteLine("Adeus!");
            driver.Quit(); //fecha o browser

        }
        
    }
}