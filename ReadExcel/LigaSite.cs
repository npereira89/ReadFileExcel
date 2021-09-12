using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace ToolsQA
{
    class ConetaSite
    {
        IWebDriver driver;

        [SetUp]
        public void IniciaLigacao()
        {

            driver = new FirefoxDriver();

        }

        [Test]
        public void AbreLigacao()
        {
            driver.Navigate().GoToUrl("https://claimopenpt.duckdns.org/auth/login");
        }

        [TearDown]
        public void FechaLigacao()
        {
            driver.Close(); //fecha o browser

        }
        
    }
}