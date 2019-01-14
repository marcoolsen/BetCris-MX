using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Variables;

namespace Ejecucion_Pruebas.MobileBetCris
{
    public class PreLogin : Apuestas
    {
        Helper helper = new Helper();
        public bool GeneralReview()
        {
            try
            {
                VariablesGlobales.DirectorioSecundario = helper.CreaDirectorioSecundario(VariablesGlobales.strDirectorio,
                System.Reflection.MethodBase.GetCurrentMethod().Name);

                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='btn-try-ux']")).Click();
                helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 15, By.XPath("//img[@alt='BetCRIS']"));
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//app-modal-release/div[1]/div[1]/div[1]/div[1]/h5"));
                //if (VariablesGlobales.Selement.Text.Contains("Información importante"))
                //{
                //    VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='defaultCheck1']")).Click();

                //    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                //    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //    VariablesGlobales.Sdriver.FindElement(By.XPath("//button[contains(text(),'Ok')]")).Click();
                //    helper.EsperaCargar(2);
                //}

                MenuLateralIzquierdo();
                Apuestas();

                return true;
            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.CierraNavegador(VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex);
            }
        }

        public bool MenuLateralIzquierdo()
        {
            try
            {
                VariablesGlobales.DirectorioTerciario = helper.CreaDirectorioTerciario(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name);
                //liveBetting
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='main-menu']/div[1]/div[1]")).Click();
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='left-side-menu']/div[1]/a[3]")).Click();
                helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='live-betting']"));
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //Casino
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='main-menu']/div[1]/div[1]")).Click();
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='left-side-menu']/div[1]/a[4]")).Click();
                helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='casino']"));
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //loyalty
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='main-menu']/div[1]/div[1]")).Click();
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='left-side-menu']/div[1]/a[5]")).Click();
                helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='loyalty']"));
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//img[@class='img-fluid box-loyalty']"));
                helper.ScrollToView(VariablesGlobales.Selement);
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                return true;
            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " Ocurrio un error en el metodo: MenuLateralIzquierdo");
            }
        }

        public bool Apuestas()
        {
            try
            {             
                VariablesGlobales.DirectorioTerciario = helper.CreaDirectorioTerciario(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name);
                
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='main-menu']/div[1]/div[1]")).Click();
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='left-side-menu']/div[1]/a[2]")).Click();
                helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 10, By.XPath("//div[@id='leagues']"));
                ChooseSport("FOOTBALL", "0", "spread");
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@cat='FOOTBALL']")).Click();
                //helper.EsperaCargar(1);
                ////helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                ////System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_1']")).Click(); 
                //helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='sports-league']"));
                ////helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                ////System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='sports-league']/app-schedule-dategroup/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]")).Click();
                helper.EsperaCargar(1);
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//span[@class='betslip-button']")).Click();
                helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 10, By.XPath("//a[@id='betslip-tab']"));
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='input-group']/input[@aria-label='Risk']")).SendKeys("100");
                helper.EsperaCargar(1);
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//button[@id='dropdownheader']")).Click(); 
                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='wagertp_2']")).Click();
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@class='close-betslip']")).Click();
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='main-menu']/div[1]/div[1]")).Click();
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='left-side-menu']/div[1]/a[2]")).Click();
                ChooseSport("BASKETBALL", "0", "spread");
                //VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='sports-league']/app-schedule-dategroup/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]"));
                //helper.ScrollToView(VariablesGlobales.Selement);
                //helper.EsperaCargar(1);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='sports-league']/app-schedule-dategroup/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]")).Click();
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='sports-league']/app-schedule-dategroup/div[2]/app-schedule-game-mobile-condensed[3]/app-game-soc-mobile-condensed[1]/div[1]/div[2]/div[2]")).Click();
                //helper.EsperaCargar(1);
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//span[@class='betslip-button']")).Click();
                helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 10, By.XPath("//a[@id='betslip-tab']"));
                helper.EsperaCargar(1);
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='input-group']/input[@aria-label='Risk']")).SendKeys("50");
                //helper.EsperaCargar(1);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='place-bet-container']/button")).Click();
                //helper.EsperaCargar(2);
                ////helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                ////System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='modal-dialog']//div[@class='modal-header']//button[@type='button']")).Click();
                //helper.EsperaCargar(1);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//button[@id='dropdownopen']")).Click();
                //helper.EsperaCargar(1);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//app-shopping-header/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/a[2]")).Click();
                helper.EsperaCargar(2);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='place-bet-container']/button")).Click();
                helper.EsperaCargar(2);
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioTerciario,
                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='modal-dialog']//div[@class='modal-header']//button[@type='button']")).Click();
                //helper.EsperaCargar(1);
                //VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@class='close-betslip']")).Click();
                return true;
            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " Ocurrio un error en el metodo: Apuestas");
            }
        }
    }
}
