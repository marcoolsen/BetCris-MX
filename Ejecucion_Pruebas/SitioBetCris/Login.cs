using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Variables;

namespace Ejecucion_Pruebas.Sitio
{
    public class Login
    {
        Helper helper = new Helper();

        public bool IngresaSiteBetCris(string playerid, string playerpass)
        {
            try
            {
                VariablesGlobales.DirectorioSecundario = helper.CreaDirectorioSecundario(VariablesGlobales.strDirectorio,
                System.Reflection.MethodBase.GetCurrentMethod().Name);

                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='account']")).SendKeys(playerid);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='password']")).SendKeys(playerpass);
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//button[@type='submit'][1]")).Click();

                helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 10, By.XPath("//div[@id='ctl00_mainClass']"));

                VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//img[@src='assets/images/logo.svg']"));
                if (VariablesGlobales.Selement.Enabled)
                {
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//app-modal-release/div[1]/div[1]/div[1]/div[1]/h5"));
                    if (VariablesGlobales.Selement.Text.Contains("Información importante") || VariablesGlobales.Selement.Text.Contains("Important information"))
                    {
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='defaultCheck1']")).Click();

                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//button[contains(text(),'Ok')]")).Click();
                        helper.EsperaCargar(2);
                    }
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    return true;
                }
                else
                {
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    helper.CierraNavegador(VariablesGlobales.Sdriver);
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se ingreso al programa. LogIn Fail");
                }

            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.CierraNavegador(VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " No se ingreso al programa. LogIn Fail");
            }
        }


    }
}
