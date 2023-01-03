using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.IO;
using OpenQA.Selenium.Interactions;

namespace GoogleSearchTest
{
    public class TesteBusca
    {

        [Fact]
        public void AbrirGoogleSearchVerificarTitulo()
        {

            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("https://www.google.com/");

            Assert.Contains("Google", driver.Title);

            driver.Close();

        }

        [Fact]
        public void BarraClicavel()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.google.com/");
            
            
            driver.FindElement(By.Name("q")).Click();
          
     
            driver.Close();

        }
        [Fact]
        public void TesteBuscaVazio()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.google.com/");

            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.CssSelector("center:nth-child(1) > .gNO89b")).Click();

            Assert.Contains("Google", driver.Title);
            driver.Close();
        }
        [Fact]
        public void SugestaoTermo()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.google.com/");

            driver.FindElement(By.Name("q")).SendKeys("gitrub");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);

            var sugestao = driver.FindElement(By.XPath("//*[@id=\"fprs\"]/span[1]")).Text;

            Assert.Equal("Exibindo resultados para", sugestao);

            driver.Close();
        }

        [Fact]
        public void ResultadoPesquisa()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.google.com/");

            driver.FindElement(By.Name("q")).SendKeys("github");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);

            Assert.Contains("github", driver.Title);

            driver.Close();
        }
    }
        

    public class TesteLogo
    {
        [Fact]
        public void LogoExibida() 
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.google.com/");

            var element = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/img"));

            bool status = element.Displayed;

            Assert.True(status);

            driver.Close();
        }
    }

    public class TesteLuck
    {
        [Fact]
        public void ResultadoPesquisaLuck()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.google.com/");

            driver.FindElement(By.Name("q")).SendKeys("github");
            driver.FindElement(By.CssSelector("center:nth-child(1) > .RNmpXc")).Click();

            Assert.Contains("GitHub", driver.Title);

            driver.Close();
        }
    }
}





