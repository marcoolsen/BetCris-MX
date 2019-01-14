using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Variables;


namespace Ejecucion_Pruebas.MobileBetCris
{
    public class LoginMobile
    {
        Helper helper = new Helper();

        public bool IngresaMobileBetCris(string playerId, string pass)
        {
            try
            {
                VariablesGlobales.DirectorioSecundario = helper.CreaDirectorioSecundario(VariablesGlobales.strDirectorio,
                System.Reflection.MethodBase.GetCurrentMethod().Name);

                //VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='main-menu']/div[1]/div[4]/a")).Click();
                //helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 5, By.XPath("//span[@class='user-level']"));
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='modal-login-form']//input[@id='account']")).SendKeys(playerId);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='modal-login-form']//input[@id='password']")).SendKeys(pass);
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//button[@class='btn btn-primary w-100']")).Click();

                helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='component-loader global']"));
                helper.EsperaCargar(1);
                //  return true;
                VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//img[@src='assets/images/logo.svg']"));
                if (VariablesGlobales.Selement.Enabled)
                {
                    List<IWebElement> elementList = new List<IWebElement>();
                    elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@id='modalWindowRelease']//h5[@id='modalWindowLabel']")));
                    if (elementList.Count != 0)
                    {
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='modalFooterRelease']//input[@id='defaultCheck1']")).Click();

                        //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//button[contains(text(),'Ok')]")).Click();
                        helper.EsperaCargar(2);
                    }
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//span[@class='betslip-button']")).Click();
                    helper.EsperaCargar(2);
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='input-group']/input[@aria-label='Risk']")).SendKeys("10");
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='place-bet-container']/button")).Click();
                    helper.ElementWait(VariablesGlobales.Sdriver, 30, By.XPath("//div[@class='bet bet-message success']/div[@class='message']"));

                    VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='openbets-tab']")).Click();
                    helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a"));
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a")).Click();
                    helper.EsperaCargar(2);
                    return true;
                }
                else
                {
                    return false;
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
