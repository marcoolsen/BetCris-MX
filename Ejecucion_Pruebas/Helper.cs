using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Ejecucion_Pruebas
{
    public class Helper
    {
        /*Browser*/
        public bool IniciaBrowser(string url, string navegador)
        {
            try
            {
                try
                {
                    switch (navegador.ToUpper())

                    {
                        case "CHROME":
                            ChromeOptions options = new ChromeOptions();
                            options.AddArguments("--incognito");
                            VariablesGlobales.Sdriver = new ChromeDriver(options);
                            //DesiredCapabilities capability = new DesiredCapabilities();
                            //capability.SetCapability("browserName", "Chrome");
                            ////capability.SetCapability("browser_version", "61.0");
                            //capability.SetCapability("os", "Windows");
                            //capability.SetCapability("os_version", "10");
                            ////capability.SetCapability("resolution", "1280x1024");
                            ////capability.SetCapability("browserstack.user", "marcoolsen1");
                            ////capability.SetCapability("browserstack.key", "9yyuSsS1DbN8jS824LnP");
                            ////capability.SetCapability("browserstack.timezone", "America/Mexico_City");
                            ////capability.SetCapability("browserstack.geoLocation", "MX");

                          //  VariablesGlobales.Sdriver = new RemoteWebDriver(new Uri("http://10.0.223.191:4444/wd/hub/"), capability);
                            break;
                        case "FIREFOX":
                            VariablesGlobales.Sdriver = new FirefoxDriver();
                            break;
                        case "EXPLORER":
                            VariablesGlobales.Sdriver = new InternetExplorerDriver();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " NO se logro inicializar el webdriver");
                }

                VariablesGlobales.Sdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                VariablesGlobales.Sdriver.Manage().Window.Maximize();
                VariablesGlobales.Sdriver.Url = url;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IniciaBrowserMobile(string url, string device)
        {
            try
            {
                try
                {

                    ChromeOptions optionsChrome = new ChromeOptions();
                    optionsChrome.EnableMobileEmulation(device);
                  //  optionsChrome.AddArguments("--incognito");
                    VariablesGlobales.Sdriver = new ChromeDriver(optionsChrome);
                    //DesiredCapabilities capability = new DesiredCapabilities();
                    //capability.SetCapability("browser", "Chrome");
                    //capability.SetCapability("browser_version", "62.0");
                    //capability.SetCapability("os", "Windows");
                    //capability.SetCapability("os_version", "10");
                    //capability.SetCapability("resolution", "1024x768");
                    //capability.SetCapability("browserstack.user", "marcoolsen1");
                    //capability.SetCapability("browserstack.key", "9yyuSsS1DbN8jS824LnP");

                    //VariablesGlobales.Sdriver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
                    // VariablesGlobales.Sdriver = new ChromeDriver();
                }
                catch (Exception ex)
                {
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " NO se logro inicializar el webdriver");
                }

               // VariablesGlobales.Sdriver.Manage().Window.Maximize();
                VariablesGlobales.Sdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);


                VariablesGlobales.Sdriver.Url = url;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CierraNavegador(IWebDriver Sdriver)
        {
            //Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            //foreach (var chromeDriverProcess in chromeDriverProcesses)
            //{
            //    chromeDriverProcess.Kill();
            //}
            Sdriver.Close();
            Sdriver.Quit();
        }

        /*Parametrizacion Screenshot*/

        public void CapturaScreenShotWeb(string strDirectorio, string screenShotName, IWebDriver Sdriver)
        {
            try
            {
                ActualizaContador();
                ITakesScreenshot takes = (ITakesScreenshot)Sdriver;
                Screenshot screenshot = takes.GetScreenshot();


                string finalpth = strDirectorio + '\\' + screenShotName + ".png";

                string localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizaContador()
        {
            Variables.VariablesGlobales.Contador = Variables.VariablesGlobales.Contador + 1;
        }

        public void InicilizaContador()
        {
            Variables.VariablesGlobales.Contador = 0;
        }

        public string CreaDirectorio(string strDirectorio)
        {
            try
            {

                string Directorio = @"C:\Automation\BetCris\Evidencias\" + strDirectorio + '_' + DateTime.Now.Year.ToString() + '_' + DateTime.Now.Month.ToString() + '_' +
                DateTime.Now.Day.ToString() + '_' + DateTime.Now.Hour.ToString() + '_' + DateTime.Now.Minute.ToString() + '_' + DateTime.Now.Second.ToString();


                if (Directory.Exists(Directorio) == false)
                {
                    Directory.CreateDirectory(Directorio);
                    return Directorio;
                }
                else
                {
                    return Directorio;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public void CreaArchivoResultados(string path)
        {
            try
            {
               // string result = "SignUp-Results " + Environment.NewLine;
                File.WriteAllText(path, "");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EscribeArchivo(string path, string result)
        {
            try
            {
                File.AppendAllText(path, result + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreaDirectorioSecundario(string DirectorioPrincipal, string MetodoActual)
        {
            try
            {
                string DirectorioSecundario = string.Empty;

                DirectorioSecundario = DirectorioPrincipal + @"\" + MetodoActual + '_' + DateTime.Now.Year.ToString() + '_' + DateTime.Now.Month.ToString() + '_' +
                    DateTime.Now.Day.ToString() + '_' + DateTime.Now.Hour.ToString() + '_' + DateTime.Now.Minute.ToString() + '_' + DateTime.Now.Second.ToString();


                if (Directory.Exists(DirectorioSecundario) == false)
                {
                    Directory.CreateDirectory(DirectorioSecundario);
                    return DirectorioSecundario;
                }
                else
                {
                    return DirectorioSecundario;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string CreaDirectorioTerciario(string DirectorioSecundario, string MetodoActual)
        {
            try
            {
                string DirectorioTerciario = string.Empty;

                DirectorioTerciario = DirectorioSecundario + @"\" + MetodoActual + '_' + DateTime.Now.Year.ToString() + '_' + DateTime.Now.Month.ToString() + '_' +
                    DateTime.Now.Day.ToString() + '_' + DateTime.Now.Hour.ToString() + '_' + DateTime.Now.Minute.ToString() + '_' + DateTime.Now.Second.ToString();


                if (Directory.Exists(DirectorioTerciario) == false)
                {
                    Directory.CreateDirectory(DirectorioTerciario);
                    return DirectorioTerciario;
                }
                else
                {
                    return DirectorioTerciario;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /*Waits*/

        public void EsperaCargar(int TimeSec)
        {
            Thread.Sleep(TimeSec * 1000);
        }

        public void ImplicitWait(IWebDriver Sdriver, int TimeSec)
        {
            Sdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TimeSec);
        }

        public void ElementWait(IWebDriver Sdriver, int TimeSec, By element)
        {
            WebDriverWait wait = new WebDriverWait(Sdriver, TimeSpan.FromSeconds(TimeSec));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public void InvisibilityOfElementLocated(IWebDriver Sdriver, int TimeSec, By element)
        {

            WebDriverWait wait = new WebDriverWait(Sdriver, TimeSpan.FromSeconds(TimeSec));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
        }

        public void VisibilityOfElementLocated(IWebDriver Sdriver, int TimeSec, By element)
        {

            WebDriverWait wait = new WebDriverWait(Sdriver, TimeSpan.FromSeconds(TimeSec));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
        }

        public void ElementToBeClickableSelenium(IWebDriver Sdriver, int TimeSec, By elementBy)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Sdriver, TimeSpan.FromSeconds(TimeSec));

                wait.Until(ExpectedConditions.ElementToBeClickable(elementBy));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /*Scroll pantalla*/

        public void ScrollToView(IWebElement Selement)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)VariablesGlobales.Sdriver;
            var js1 = String.Format("window.scrollTo({0}, {1})", VariablesGlobales.Selement.Location.X, VariablesGlobales.Selement.Location.Y);
            js.ExecuteScript(js1);
        }

        /*GenericsMethods*/

        public string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}
