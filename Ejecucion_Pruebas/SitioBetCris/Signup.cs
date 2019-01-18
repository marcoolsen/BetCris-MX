using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Variables;
using System.Data;
using OpenQA.Selenium.Support.UI;

namespace Ejecucion_Pruebas.SitioBetCris
{
    public class Signup
    {
        Helper helper = new Helper();

        public bool ReviewSignup(string firsName, string lastName, string day, string month, string year, string email, string password, string repassword, string country, string phone, string coin)
        {
            try
            {
                VariablesGlobales.DirectorioSecundario = helper.CreaDirectorioSecundario(VariablesGlobales.strDirectorio,
                System.Reflection.MethodBase.GetCurrentMethod().Name + "-" + country);

                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='sg_txtfirstName']")).SendKeys(firsName);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='sg_txtlastName']")).SendKeys(lastName);
                SelectElement select = new SelectElement(VariablesGlobales.Sdriver.FindElement(By.XPath("//select[@id='sg_ddlbirthDateDay']")));
                select.SelectByValue(day);
                select = new SelectElement(VariablesGlobales.Sdriver.FindElement(By.XPath("//select[@id='sg_ddlbirthDateMonth']")));
                select.SelectByValue(month);
                select = new SelectElement(VariablesGlobales.Sdriver.FindElement(By.XPath("//select[@id='sg_ddlbirthDateYear']")));
                select.SelectByValue(year);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='sg_txtemail']")).SendKeys(email);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='sg_txtpassword']")).SendKeys(password);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='sg_txtpasswordR']")).SendKeys(repassword);
                select = new SelectElement(VariablesGlobales.Sdriver.FindElement(By.XPath("//select[@id='sg_ddlcountry']")));
                select.SelectByText(country);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='sg_txtphone']")).SendKeys(phone);
                if (country == "Honduras")
                {
                    select = new SelectElement(VariablesGlobales.Sdriver.FindElement(By.XPath("//select[@id='sg_ddlcurrency']")));
                    select.SelectByValue("30");
                }
                else
                {
                    select = new SelectElement(VariablesGlobales.Sdriver.FindElement(By.XPath("//select[@id='sg_ddlcurrency']")));
                    select.SelectByValue(coin);
                }

                VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='sg_chkMarketingChannel']")).Click();
                VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='sg_chkterms']")).Click();

                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                VariablesGlobales.Sdriver.FindElement(By.XPath("//button[@id='sg_btnProcess']")).Click();

                helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 120, By.XPath("//div[@id='divSignupManager']"));

                if (country == "Panama")
                {
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='welcomePanama']"));
                    if (VariablesGlobales.Selement.Displayed)
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        helper.EscribeArchivo(VariablesGlobales.path, country + " -OK");
                       // helper.IniciaBrowser(VariablesGlobales.urlbetcrisPrd, VariablesGlobales.navegador);
                        return true;
                    }
                    else
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        helper.EscribeArchivo(VariablesGlobales.path, country + " FAIL****************************************");
                      //  helper.CierraNavegador(VariablesGlobales.Sdriver);
                     //   helper.IniciaBrowser(VariablesGlobales.urlbetcrisPrd, VariablesGlobales.navegador);
                        return false;
                    }
                }
                else
                {
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='welcomeMainDiv']//h1"));
                    if (VariablesGlobales.Selement.Displayed)
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                        helper.EscribeArchivo(VariablesGlobales.pathemail, email);

                        VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='welc-btn']/a[@id='cashier']")).Click();
                        VariablesGlobales.Sdriver.SwitchTo().Window(VariablesGlobales.Sdriver.WindowHandles.Last());
                        if (country == "Chile" || country == "French Guiana" || country == "Guadeloupe" || country == "Martinique" || country == "Mayotte" || country == "Philippines" || country == "Reunion") 
                        {
                            helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 60, By.XPath("//div[@class='infowrap']"));
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            helper.EscribeArchivo(VariablesGlobales.path, country + " -OK");
                            return true;
                        }
                        else
                        {
                            helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 60, By.XPath("//h1[@class='hidden loading-text']"));
                            helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 60, By.XPath("//a[@data-dismiss='modal']"));
                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@data-dismiss='modal']"));
                            if (VariablesGlobales.Selement.Displayed)
                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@data-dismiss='modal']")).Click();
                            }
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            helper.EscribeArchivo(VariablesGlobales.path, country + " -OK");
                            //helper.CierraNavegador(VariablesGlobales.Sdriver);
                            //helper.IniciaBrowser(VariablesGlobales.urlbetcrisPrd, VariablesGlobales.navegador);
                            return true;
                        }

                    }
                    else
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        helper.EscribeArchivo(VariablesGlobales.path, country + " FAIL****************************************");
                        //helper.CierraNavegador(VariablesGlobales.Sdriver);
                        //helper.IniciaBrowser(VariablesGlobales.urlbetcrisPrd, VariablesGlobales.navegador);
                        return false;
                        //  throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Error. No se logro realizar el signUp correctamente. Validar!!");
                    }
                }
               
            }
            catch (Exception)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.EscribeArchivo(VariablesGlobales.path, country + " FAIL****************************************");
                helper.CierraNavegador(VariablesGlobales.Sdriver);
              //  helper.IniciaBrowser(VariablesGlobales.urlbetcrisPrd, VariablesGlobales.navegador);
                return false;
                //throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " Error en el metodo ReviewSignup. Validar!!");
            }
        }
    }
}
