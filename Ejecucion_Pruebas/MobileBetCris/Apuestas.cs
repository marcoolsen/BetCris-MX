using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Variables;
using System.Data;

namespace Ejecucion_Pruebas.MobileBetCris
{
    public class Apuestas
    {
        Helper helper = new Helper();

        public bool InsertStraightBet(string sport, string manual, string typebet, string riskAmount)
        {
            try
            {
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='main-menu']/div[1]/div[1]")).Click();
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='left-side-menu']/div[1]/a[2]")).Click();
                helper.EsperaCargar(2);
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

                ChooseSport(sport, manual, typebet);
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//span[@class='betslip-button']")).Click();
                helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 10, By.XPath("//a[@id='betslip-tab']"));
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='input-group']/input[@aria-label='Risk']")).SendKeys(riskAmount);
                helper.EsperaCargar(1);
                VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-review']/div[1]/div[2]/span[@class='amount']"));
                var WinBefore = helper.RemoveSpecialCharacters(VariablesGlobales.Selement.Text);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='place-bet-container']/button")).Click();
                helper.ElementWait(VariablesGlobales.Sdriver, 30, By.XPath("//div[@class='bet success bet-message']/div[@class='message']"));
             
                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='openbets-tab']")).Click();
                helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a"));
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a")).Click();
                helper.EsperaCargar(1);
                VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//app-open-bet-ticket[1]/div[1]/div[1]/div[1]/p[1]"));
                var RiskAfter = helper.getBetween(VariablesGlobales.Selement.Text, "Risk: $", " -");
                if (RiskAfter == "")
                {
                    RiskAfter = helper.getBetween(VariablesGlobales.Selement.Text, "En juego: $", " -");
                }
                var WinAfter = helper.getBetween(VariablesGlobales.Selement.Text + "*", "Win: $", "*");
                if (WinAfter == "")
                {
                    WinAfter = helper.getBetween(VariablesGlobales.Selement.Text + "*", "Para ganar: $", "*");
                }
                if (riskAmount == RiskAfter)
                {
                    if (WinBefore == WinAfter)
                    {
                        helper.EsperaCargar(3);
                        return true;
                    }
                    else
                    {
                        throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " El Win cambio despues de la apuesta. Validar!!");
                    }
                }
                else
                {
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " El Risk cambio despues de la apuesta. Validar!!");
                }
            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.CierraNavegador(VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " Error en el metodo InsertStraightBet. Validar!!");
            }
        }

        public bool InsertParlay(DataTable table, string riskAmount)
        {
            try
            {
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='main-menu']/div[1]/div[1]")).Click();
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='left-side-menu']/div[1]/a[2]")).Click();
                helper.EsperaCargar(2);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//span[@class='betslip-button']")).Click();
                helper.EsperaCargar(2);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-header']/div/div/div/button[@id='dropdownheader']")).Click();
                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='wagertp_2']")).Click();
                helper.EsperaCargar(1);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@class='close-betslip']")).Click();
                helper.EsperaCargar(1);
                foreach (DataRow row in table.Rows)
                {
                    ChooseSport(row["Sport"].ToString(), row["Search"].ToString(), row["TypeBet"].ToString());
                    helper.EsperaCargar(2);
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@class='back nav-link']")).Click();
                    helper.EsperaCargar(2);
                }
                VariablesGlobales.Sdriver.FindElement(By.XPath("//span[@class='betslip-button']")).Click();
                helper.EsperaCargar(2);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='input-group']/input[@aria-label='Risk']")).SendKeys("10");
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='place-bet-container']/button")).Click();
                helper.ElementWait(VariablesGlobales.Sdriver, 30, By.XPath("//div[@class='bet bet-message success']/div[@class='message']"));
                helper.EsperaCargar(2);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='openbets-tab']")).Click();
                helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a"));
                helper.EsperaCargar(2);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a")).Click();
                helper.EsperaCargar(2);
                return true;
            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.CierraNavegador(VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " Error en el metodo InsertParlay. Validar!!");
            }
        }

        public bool ChooseSport(string sport, string manual, string typebet)
        {
            try
            {
                if (manual == "1")
                {
                    switch (sport)
                    {
                        case "FOOTBALL":
                            #region Logica

                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_1']"));
                            if (!VariablesGlobales.Selement.Displayed)
                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='leagues']/a[@cat='FOOTBALL']")).Click();
                            }
                            helper.EsperaCargar(2);
                            VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_1']")).Click();
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            var query = String.Format("//div[@class='sports-league']/app-schedule-dategroup[{0}]/div[2]/app-schedule-game-american[{1}]/app-game-general[1]/div[5]/div[1]/div[3]/div[1]/div[2]/app-spread-line/label/span[@class='points-line']", VariablesGlobales.x, VariablesGlobales.y);
                            List<IWebElement> elementList4 = new List<IWebElement>();
                            elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath(query)));
                            if (elementList4.Count == 0)
                            {
                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en FOOTBALL. Validar!!");
                            }
                            else
                            {
                                VariablesGlobales.Sdriver.FindElement(
                                By.XPath(query)).Click();
                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                return true;
                            }
                        #endregion
                        case "BASKETBALL":
                            #region Logica
                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_3']"));

                            if (!VariablesGlobales.Selement.Displayed)
                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='leagues']/a[@cat='BASKETBALL']")).Click();
                            }
                            helper.EsperaCargar(2);
                            VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_3']")).Click();
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            query = String.Format("//div[@class='sports-league']/app-schedule-dategroup[{0}]/div[2]/app-schedule-game-american[{1}]/app-game-general[1]/div[4]/div[1]/div[3]/div[1]/div[1]/app-spread-line/label/span[@class='points-line']", VariablesGlobales.x, VariablesGlobales.y);
                            List<IWebElement> elementList3 = new List<IWebElement>();
                            elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath(query)));
                            if (elementList3.Count == 0)
                            {
                                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en BASKETBALL. Validar!!");
                            }
                            else
                            {
                                VariablesGlobales.Sdriver.FindElement(
                                    By.XPath(query)).Click();
                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                return true;
                            }
                        #endregion
                        case "SOCCER":
                            #region Logica
                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_10016']"));
                            if (!VariablesGlobales.Selement.Displayed)
                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='leagues']/a[@cat='SOCCER']")).Click();
                            }
                            helper.EsperaCargar(2);
                            VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_10016']")).Click();
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            List<IWebElement> elementList2 = new List<IWebElement>();
                            query = String.Format("//div[@class='sports-league']/app-schedule-dategroup[{0}]/div[2]/app-schedule-game-american[{1}]/app-game-soc/div[1]/div[1]/div[3]/div/div[3]/app-money-line/label/span[@class='odds']", VariablesGlobales.x, VariablesGlobales.y);
                            elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath(query)));
                            if (elementList2.Count == 0)
                            {
                                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en SOCCER. Validar!!");
                            }
                            else
                            {
                                VariablesGlobales.Sdriver.FindElement(
                                By.XPath(query)).Click();
                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                return true;
                            }

                        #endregion
                        case "HOCKEY":
                            #region Logica
                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_7']"));
                            if (!VariablesGlobales.Selement.Displayed)

                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='leagues']/a[@cat='HOCKEY']")).Click();
                            }
                            helper.EsperaCargar(2);
                            VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_7']")).Click();
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            List<IWebElement> elementList1 = new List<IWebElement>();
                            query = String.Format("//div[@class='sports-league']/app-schedule-dategroup[{0}]/div[2]/app-schedule-game-american[{1}]/app-game-soc/div[1]/div[1]/div[3]/div/div[3]/app-money-line/label/span[@class='odds']", VariablesGlobales.x, VariablesGlobales.y);
                            elementList1.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath(query)));
                            if (elementList1.Count == 0)
                            {
                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en HOCKEY. Validar!!");
                            }
                            else
                            {
                                VariablesGlobales.Sdriver.FindElement(
                                By.XPath(query)).Click();
                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                return true;
                            }
                        #endregion
                        case "E-SPORTS":
                            #region Logica
                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_13117']"));
                            if (!VariablesGlobales.Selement.Displayed)
                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='leagues']/a[@cat='E-SPORTS']")).Click();
                            }
                            helper.EsperaCargar(2);
                            VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_13117']")).Click();
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            query = String.Format("//div[@class='sports-league']/app-schedule-dategroup[{0}]/div[2]/app-schedule-game-american[{1}]/app-game-mu/div[1]/div[1]/div[3]/div[1]/div[1]/app-money-line/label/span[@class='odds']", VariablesGlobales.x, VariablesGlobales.y);
                            List<IWebElement> elementList = new List<IWebElement>();
                            elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath(query)));
                            if (elementList.Count == 0)
                            {
                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en E-SPORTS. Validar!!");
                            }
                            else
                            {
                                VariablesGlobales.Sdriver.FindElement(
                                By.XPath(query)).Click();
                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                return true;
                            }
                        #endregion
                        default:
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Se ingreso un Sport no invalido. Validar!!");
                    }
                }
                else
                {
                    switch (sport)
                    {
                        case "FOOTBALL":
                            #region Logica
                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_1']"));
                            if (!VariablesGlobales.Selement.Displayed)
                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='leagues']/a[@cat='FOOTBALL']")).Click();
                            }
                            helper.EsperaCargar(2);
                            VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_1']")).Click();
                            //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            List<IWebElement> elementList4 = new List<IWebElement>();
                            switch (typebet)
                            {
                                case "spread":
                                    elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")));
                                    if (elementList4.Count == 0)
                                    {
                                        elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")));
                                        if (elementList4.Count == 0)
                                        {
                                            elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")));
                                            if (elementList4.Count == 0)
                                            {
                                                elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")));
                                                if (elementList4.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en FOOTBALL. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")).Click();
                                                    //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")).Click();
                                                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")).Click();
                                            //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")).Click();
                                        //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                case "total":
                                    elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]//div[6]//div[1]/app-total-line/label/span")));
                                    if (elementList4.Count == 0)
                                    {
                                        elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath(">//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]//div[6]//div[1]/app-total-line/label/span")));
                                        if (elementList4.Count == 0)
                                        {
                                            elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]//div[6]//div[1]/app-total-line/label/span")));
                                            if (elementList4.Count == 0)
                                            {
                                                elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]//div[6]//div[1]/app-total-line/label/span")));
                                                if (elementList4.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en FOOTBALL. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[5]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='points-line']")).Click();
                                                    //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]//div[6]//div[1]/app-total-line/label/span")).Click();
                                                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]//div[6]//div[1]/app-total-line/label/span")).Click();
                                            //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]//div[6]//div[1]/app-total-line/label/span")).Click();
                                        //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                default:
                                    //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                    //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No existe el tipo de apuesta " + typebet + ". Validar!!");

                            }
                        #endregion
                        case "BASKETBALL":
                            #region Logica
                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_3']"));

                            if (!VariablesGlobales.Selement.Displayed)
                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='leagues']/a[@cat='BASKETBALL']")).Click();
                            }
                            helper.EsperaCargar(2);
                            VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_3']")).Click();
                            //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            List<IWebElement> elementList3 = new List<IWebElement>();
                            switch (typebet)
                            {
                                case "spread":
                                    elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")));
                                    if (elementList3.Count == 0)
                                    {
                                        elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")));
                                        if (elementList3.Count == 0)
                                        {
                                            elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")));
                                            if (elementList3.Count == 0)
                                            {
                                                elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")));
                                                if (elementList3.Count == 0)
                                                {
                                                    //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en BASKETBALL. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")).Click();
                                                    //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")).Click();
                                                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")).Click();
                                            //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-spread-line/label/span")).Click();
                                        //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                case "total":
                                    elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[6]/div[1]/app-total-line/label/span")));
                                    if (elementList3.Count == 0)
                                    {
                                        elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[6]/div[1]/app-total-line/label/span")));
                                        if (elementList3.Count == 0)
                                        {
                                            elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[6]/div[1]/app-total-line/label/span")));
                                            if (elementList3.Count == 0)
                                            {
                                                elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[6]/div[1]/app-total-line/label/span")));
                                                if (elementList3.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en BASKETBALL. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[6]/div[1]/app-total-line/label/span")).Click();
                                                    //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[6]/div[1]/app-total-line/label/span")).Click();
                                                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[6]/div[1]/app-total-line/label/span")).Click();
                                            //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-general-mobile-condensed[1]/div[1]/div[2]/div[6]/div[1]/app-total-line/label/span")).Click();
                                        //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                default:
                                    //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                    //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No existe el tipo de apuesta " + typebet + ". Validar!!");
                            }

                        #endregion
                        case "SOCCER":
                            #region Logica
                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_10016']"));
                            if (!VariablesGlobales.Selement.Displayed)
                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='leagues']/a[@cat='SOCCER']")).Click();
                            }
                            helper.EsperaCargar(2);
                            VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_10016']")).Click();
                            //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            List<IWebElement> elementList2 = new List<IWebElement>();
                            switch (typebet)
                            {
                                case "moneyline":
                                    elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-soc-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-money-line/label/span")));
                                    if (elementList2.Count == 0)
                                    {
                                        elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-soc-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-money-line/label/span")));
                                        if (elementList2.Count == 0)
                                        {
                                            elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-soc-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-money-line/label/span")));
                                            if (elementList2.Count == 0)
                                            {
                                                elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-soc-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-money-line/label/span")));
                                                if (elementList2.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en SOCCER. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-soc-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-money-line/label/span")).Click();
                                                    //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-soc-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-money-line/label/span")).Click();
                                                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[2]/app-game-soc-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-money-line/label/span")).Click();
                                            //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-mobile-condensed[1]/app-game-soc-mobile-condensed[1]/div[1]/div[2]/div[2]/div[1]/app-money-line/label/span")).Click();
                                        //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                case "total":
                                    elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")));
                                    if (elementList2.Count == 0)
                                    {
                                        elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")));
                                        if (elementList2.Count == 0)
                                        {
                                            elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")));
                                            if (elementList2.Count == 0)
                                            {
                                                elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")));
                                                if (elementList2.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en SOCCER. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")).Click();
                                                    //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")).Click();
                                                //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")).Click();
                                            //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")).Click();
                                        //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                default:
                                    //helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                    //System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No existe el tipo de apuesta " + typebet + ". Validar!!");
                            }
                        #endregion
                        case "HOCKEY":
                            #region Logica
                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_7']"));
                            if (!VariablesGlobales.Selement.Displayed)

                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='leagues']/a[@cat='HOCKEY']")).Click();
                            }
                            helper.EsperaCargar(2);
                            VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_7']")).Click();
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            List<IWebElement> elementList1 = new List<IWebElement>();
                            switch (typebet)
                            {
                                case "moneyline":
                                    elementList1.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-nhl/div[1]/div[1]/div[3]/div[1]/div[2]/app-money-line/label/span[@class='odds']")));
                                    if (elementList1.Count == 0)
                                    {
                                        elementList1.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-nhl/div[1]/div[1]/div[3]/div[1]/div[2]/app-money-line/label/span[@class='odds']")));
                                        if (elementList1.Count == 0)
                                        {
                                            elementList1.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-nhl/div[1]/div[1]/div[3]/div[1]/div[2]/app-money-line/label/span[@class='odds']")));
                                            if (elementList1.Count == 0)
                                            {
                                                elementList1.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-nhl/div[1]/div[1]/div[3]/div[1]/div[2]/app-money-line/label/span[@class='odds']")));
                                                if (elementList1.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en HOCKEY. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-nhl/div[1]/div[1]/div[3]/div[1]/div[2]/app-money-line/label/span[@class='odds']")).Click();
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-nhl/div[1]/div[1]/div[3]/div[1]/div[2]/app-money-line/label/span[@class='odds']")).Click();
                                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-nhl/div[1]/div[1]/div[3]/div[1]/div[2]/app-money-line/label/span[@class='odds']")).Click();
                                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-nhl/div[1]/div[1]/div[3]/div[1]/div[2]/app-money-line/label/span[@class='odds']")).Click();
                                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                case "total":
                                    elementList1.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-nhl/div[1]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='odds']")));
                                    if (elementList1.Count == 0)
                                    {
                                        elementList1.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-nhl/div[1]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='odds']")));
                                        if (elementList1.Count == 0)
                                        {
                                            elementList1.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-nhl/div[1]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='odds']")));
                                            if (elementList1.Count == 0)
                                            {
                                                elementList1.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-nhl/div[1]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='odds']")));
                                                if (elementList1.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en HOCKEY. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-nhl/div[1]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='odds']")).Click();
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-nhl/div[1]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='odds']")).Click();
                                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-nhl/div[1]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='odds']")).Click();
                                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-nhl/div[1]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='odds']")).Click();
                                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                default:
                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No existe el tipo de apuesta " + typebet + ". Validar!!");
                            }

                        #endregion
                        case "E-SPORTS":
                            #region Logica
                            VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_13117']"));
                            if (!VariablesGlobales.Selement.Displayed)
                            {
                                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@id='leagues']/a[@cat='E-SPORTS']")).Click();
                            }
                            helper.EsperaCargar(2);
                            VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='league_13117']")).Click();
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            List<IWebElement> elementList = new List<IWebElement>();
                            switch (typebet)
                            {
                                case "moneyline":
                                    elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-mu/div[1]/div[1]/div[3]/div[1]/div[1]/app-money-line/label/span[@class='odds']")));
                                    if (elementList.Count == 0)
                                    {
                                        elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-mu/div[1]/div[1]/div[3]/div[1]/div[1]/app-money-line/label/span[@class='odds']")));
                                        if (elementList.Count == 0)
                                        {
                                            elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-mu/div[1]/div[1]/div[3]/div[1]/div[1]/app-money-line/label/span[@class='odds']")));
                                            if (elementList.Count == 0)
                                            {
                                                elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-mu/div[1]/div[1]/div[3]/div[1]/div[1]/app-money-line/label/span[@class='odds']")));
                                                if (elementList.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en E-SPORTS. Validar!!");

                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-mu/div[1]/div[1]/div[3]/div[1]/div[1]/app-money-line/label/span[@class='odds']")).Click();
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-mu/div[1]/div[1]/div[3]/div[1]/div[1]/app-money-line/label/span[@class='odds']")).Click();
                                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-mu/div[1]/div[1]/div[3]/div[1]/div[1]/app-money-line/label/span[@class='odds']")).Click();
                                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-mu/div[1]/div[1]/div[3]/div[1]/div[1]/app-money-line/label/span[@class='odds']")).Click();
                                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                case "spread":
                                    elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-mu/div[1]/div[1]/div[4]/div[1]/div[1]/app-spread-line/label/span[@class='odds']")));
                                    if (elementList.Count == 0)
                                    {
                                        elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-mu/div[1]/div[1]/div[4]/div[1]/div[1]/app-spread-line/label/span[@class='odds']")));
                                        if (elementList.Count == 0)
                                        {
                                            elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-mu/div[1]/div[1]/div[4]/div[1]/div[1]/app-spread-line/label/span[@class='odds']")));
                                            if (elementList.Count == 0)
                                            {
                                                elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-mu/div[1]/div[1]/div[4]/div[1]/div[1]/app-spread-line/label/span[@class='odds']")));
                                                if (elementList.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en E-SPORTS. Validar!!");

                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-mu/div[1]/div[1]/div[4]/div[1]/div[1]/app-spread-line/label/span[@class='odds']")).Click();
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-mu/div[1]/div[1]/div[4]/div[1]/div[1]/app-spread-line/label/span[@class='odds']")).Click();
                                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-mu/div[1]/div[1]/div[4]/div[1]/div[1]/app-spread-line/label/span[@class='odds']")).Click();
                                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-mu/div[1]/div[1]/div[4]/div[1]/div[1]/app-spread-line/label/span[@class='odds']")).Click();
                                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                default:
                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No existe el tipo de apuesta " + typebet + ". Validar!!");
                            }
                        #endregion
                        default:
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            //     helper.CierraNavegador(VariablesGlobales.Sdriver);
                            throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Se ingreso un Sport no invalido. Validar!!");
                    }
                }

            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " Error en el metodo ChooseSport. Validar!!");
            }
        }
    }
}
