using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Variables;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Data;

namespace Ejecucion_Pruebas.SitioBetCris
{
    public class IngresaApuesta
    {
        Helper helper = new Helper();

        #region StraightBets

        public bool InsertStrainghBet(string riskAmount, string sport, string manual, string typebet)
        {
            try
            {
                VariablesGlobales.DirectorioSecundario = helper.CreaDirectorioSecundario(VariablesGlobales.strDirectorio,
                System.Reflection.MethodBase.GetCurrentMethod().Name);

                ChooseSport(sport, manual, typebet);

                VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-review']"));
                if (VariablesGlobales.Selement.Displayed)
                {
                    // VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@class='btn btn-success d-block']"))
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='input-group']/input[@placeholder='Risk']")).SendKeys(riskAmount);
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-review']/div[1]/div[2]/span[@class='amount']"));
                    var WinBefore = helper.RemoveSpecialCharacters(VariablesGlobales.Selement.Text);
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//button[contains(text(),'Place Bet')]")).Click();
                    helper.EsperaCargar(2);
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 10, By.XPath("//p[contains(text(),'Bet successfully placed!')]"));
                    //   helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 5, By.XPath("//div[@class='component-loader']"));
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//p[contains(text(),'Bet successfully placed!')]"));
                    if (VariablesGlobales.Selement.Text.Contains("Bet successfully placed!"))
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        //         helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 3, By.XPath("//a[@id='openbets-tab']"));
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='openbets-tab']")).Click();
                        helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a"));
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a")).Click();
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                        VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//app-open-bet-ticket[1]/div[1]/div[1]/div[1]/p[1]"));
                        var RiskAfter = helper.getBetween(VariablesGlobales.Selement.Text, "Risk: $", " -");
                        var WinAfter = helper.getBetween(VariablesGlobales.Selement.Text + "*", "Win: $", "*");
                        if (riskAmount == RiskAfter)
                        {
                            if (WinBefore == WinAfter)
                            {
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
                    else
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        helper.CierraNavegador(VariablesGlobales.Sdriver);
                        throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se logro apostar de forma satisfactoria. Validar!!");
                    }
                }
                else
                {
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    helper.CierraNavegador(VariablesGlobales.Sdriver);
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se puede agregar el monto de la apuesta. Validar!!");
                }

            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.CierraNavegador(VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " Error en el metodo InsertStrainghBet. Validar!!");
            }
        }

        public bool InsertStrainghtBetFreePlay(string riskAmount, string sport, string manual, string typebet)
        {
            try
            {
                VariablesGlobales.DirectorioSecundario = helper.CreaDirectorioSecundario(VariablesGlobales.strDirectorio,
                System.Reflection.MethodBase.GetCurrentMethod().Name);

                ChooseSport(sport, manual, typebet);

                VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-review']"));
                if (VariablesGlobales.Selement.Displayed)
                {
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//input[@id='defaultCheck1']")).Click();
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='input-group']/input[@placeholder='Risk']")).SendKeys(riskAmount);
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-review']/div[1]/div[3]/span[@class='amount']"));
                    var WinBefore = helper.RemoveSpecialCharacters(VariablesGlobales.Selement.Text);
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//button[contains(text(),'Place Bet')]")).Click();
                    helper.EsperaCargar(2);
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    helper.ElementWait(VariablesGlobales.Sdriver, 30, By.XPath("//p[contains(text(),'Bet successfully placed!')]"));
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//p[contains(text(),'Bet successfully placed!')]"));
                    if (VariablesGlobales.Selement.Text.Contains("Bet successfully placed!"))
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        //         helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 3, By.XPath("//a[@id='openbets-tab']"));
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='openbets-tab']")).Click();
                        helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 20, By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a"));
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a")).Click();
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//app-open-bet-ticket[1]/div[1]/div[1]/div[1]/p[1]"));
                        var RiskAfter = helper.getBetween(VariablesGlobales.Selement.Text, "Risk: $", " -");
                        var WinAfter = helper.getBetween(VariablesGlobales.Selement.Text + "*", "Win: $", "*");
                        if ("0.00" == RiskAfter)
                        {
                            if (WinBefore == WinAfter)
                            {
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
                    else
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        //helper.CierraNavegador(VariablesGlobales.Sdriver);
                        throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se logro apostar de forma satisfactoria. Validar!!");
                    }
                }
                else
                {
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    helper.CierraNavegador(VariablesGlobales.Sdriver);
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se puede agregar el monto de la apuesta. Validar!!");
                }
            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.CierraNavegador(VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " Error en el metodo InsertStrainghBet con Free Play. Validar!!");
            }
        }

        public bool InsertStraingtMultiples(DataTable table)

        {
            try
            {
                VariablesGlobales.DirectorioSecundario = helper.CreaDirectorioSecundario(VariablesGlobales.strDirectorio,
                System.Reflection.MethodBase.GetCurrentMethod().Name);


                foreach (DataRow row in table.Rows)
                {
                    ChooseSport(row["Sport"].ToString(), row["Search"].ToString(), row["TypeBet"].ToString());
                    List<IWebElement> elementList = new List<IWebElement>();
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-review']"));
                    if (VariablesGlobales.Selement.Displayed)
                    {
                        elementList.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='input-group']/input[@placeholder='Risk']")));
                        elementList[(int)row["Id"]].SendKeys(row["Amount"].ToString());
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    }
                    else
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        helper.CierraNavegador(VariablesGlobales.Sdriver);
                        throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se logro apostar de forma satisfactoria. Validar!!");
                    }
                }

                VariablesGlobales.Sdriver.FindElement(By.XPath("//button[contains(text(),'Place Bet')]")).Click();
                helper.EsperaCargar(2);
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.VisibilityOfElementLocated(VariablesGlobales.Sdriver, 30, By.XPath("//p[contains(text(),'Bets successfully placed!')]"));
                //   helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 5, By.XPath("//div[@class='component-loader']"));
                VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//p[contains(text(),'Bets successfully placed!')]"));
                if (VariablesGlobales.Selement.Text.Contains("Bets successfully placed!"))
                {
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    //         helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 3, By.XPath("//a[@id='openbets-tab']"));
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='openbets-tab']")).Click();
                    helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 30, By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a"));
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a")).Click();
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    return true;
                }
                else
                {
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    // helper.CierraNavegador(VariablesGlobales.Sdriver);
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se logro apostar de forma satisfactoria. Validar!!");
                }

             
            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.CierraNavegador(VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " Error en el metodo InsertStrainghBet Multiples. Validar!!");
            }
        }

        #endregion

        #region Parlay

        public bool InsertParlay(DataTable table, string riskAmount)
        {
            try
            {
                VariablesGlobales.DirectorioSecundario = helper.CreaDirectorioSecundario(VariablesGlobales.strDirectorio,
                System.Reflection.MethodBase.GetCurrentMethod().Name);

                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='betslip-tab']")).Click();
                helper.EsperaCargar(2);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-header']/div/div/div/button[@id='dropdownheader']")).Click();
                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='wagertp_2']")).Click();
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.ImplicitWait(VariablesGlobales.Sdriver, 10);

                foreach (DataRow row in table.Rows)
                {
                    ChooseSport(row["Sport"].ToString(), row["Search"].ToString(), row["TypeBet"].ToString());
                }

                VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-review']"));
                if (VariablesGlobales.Selement.Displayed)
                {
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='input-group']/input[@placeholder='Risk']")).SendKeys(riskAmount);
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-review']/div[1]/div[2]/span[@class='amount']"));
                    var WinBefore = helper.RemoveSpecialCharacters(VariablesGlobales.Selement.Text);
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//button[contains(text(),'Place Bet')]")).Click();
                    helper.EsperaCargar(2);
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 10, By.XPath("//p[contains(text(),'Parlay has been placed!')]"));
                    //   helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 5, By.XPath("//div[@class='component-loader']"));
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//p[contains(text(),'Parlay has been placed!')]"));
                    if (VariablesGlobales.Selement.Text.Contains("Parlay has been placed!"))
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        //         helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 3, By.XPath("//a[@id='openbets-tab']"));
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='openbets-tab']")).Click();
                        helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a"));
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a")).Click();
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//app-open-bet-ticket[1]/div[1]/div[1]/div[1]/p[1]"));
                        var RiskAfter = helper.getBetween(VariablesGlobales.Selement.Text, "Risk: $", " -");
                        var WinAfter = helper.getBetween(VariablesGlobales.Selement.Text + "*", "Win: $", "*");
                        if (riskAmount == RiskAfter)
                        {
                            if (WinBefore == WinAfter)
                            {
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
                    else
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        // helper.CierraNavegador(VariablesGlobales.Sdriver);
                        throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se logro apostar de forma satisfactoria. Validar!!");
                    }
                }
                else
                {
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    // helper.CierraNavegador(VariablesGlobales.Sdriver);
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se puede agregar el monto de la apuesta. Validar!!");
                }
            }
            catch (Exception ex)
            {
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.CierraNavegador(VariablesGlobales.Sdriver);
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ex + " Error en el metodo InsertParlay. Validar!!");
            }
        }

        #endregion

        #region Teaser

        public bool InsertTeaser(string riskAmount, DataTable table)
        {
            try
            {
                VariablesGlobales.DirectorioSecundario = helper.CreaDirectorioSecundario(VariablesGlobales.strDirectorio,
                System.Reflection.MethodBase.GetCurrentMethod().Name);
                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='betslip-tab']")).Click();
                helper.EsperaCargar(2);

                VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-header']/div/div/div/button[@id='dropdownheader']")).Click();
                VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='wagertp_3']")).Click();
                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                helper.ImplicitWait(VariablesGlobales.Sdriver, 10);

                foreach (DataRow row in table.Rows)
                {
                    ChooseSport(row["Sport"].ToString(), row["Search"].ToString(), row["TypeBet"].ToString());
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@class='back nav-link']")).Click();
                    helper.EsperaCargar(1);
                }

                VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-review']"));
                if (VariablesGlobales.Selement.Displayed)
                {
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='input-group']/input[@placeholder='Risk']")).SendKeys(riskAmount);
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-review']/div[1]/div[2]/span[@class='amount']"));
                    var WinBefore = helper.RemoveSpecialCharacters(VariablesGlobales.Selement.Text);
                    VariablesGlobales.Sdriver.FindElement(By.XPath("//button[contains(text(),'Place Bet')]")).Click();
                    helper.EsperaCargar(2);
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 10, By.XPath("//p[contains(text(),'1 Teaser has been placed!')]"));
                    //   helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 5, By.XPath("//div[@class='component-loader']"));
                    VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//p[contains(text(),'1 Teaser has been placed!')]"));
                    if (VariablesGlobales.Selement.Text.Contains("1 Teaser has been placed!"))
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        //         helper.InvisibilityOfElementLocated(VariablesGlobales.Sdriver, 3, By.XPath("//a[@id='openbets-tab']"));
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//a[@id='openbets-tab']")).Click();
                        helper.ElementToBeClickableSelenium(VariablesGlobales.Sdriver, 10, By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a"));
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        VariablesGlobales.Sdriver.FindElement(By.XPath("//div[@class='betslip-container open-bets']/div[2]/div[1]/div[1]/div[1]/div[2]/a")).Click();
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        VariablesGlobales.Selement = VariablesGlobales.Sdriver.FindElement(By.XPath("//app-open-bet-ticket[1]/div[1]/div[1]/div[1]/p[1]"));
                        var RiskAfter = helper.getBetween(VariablesGlobales.Selement.Text, "Risk: $", " -");
                        var WinAfter = helper.getBetween(VariablesGlobales.Selement.Text + "*", "Win: $", "*");
                        if (riskAmount == RiskAfter)
                        {
                            if (WinBefore == WinAfter)
                            {
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
                    else
                    {
                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                        // helper.CierraNavegador(VariablesGlobales.Sdriver);
                        throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se logro apostar de forma satisfactoria. Validar!!");
                    }
                }
                else
                {
                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                    // helper.CierraNavegador(VariablesGlobales.Sdriver);
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No se puede agregar el monto de la apuesta. Validar!!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region GenericsMethods

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
                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                            List<IWebElement> elementList4 = new List<IWebElement>();
                            switch (typebet)
                            {
                                case "spread":
                                    elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[5]/div[1]/div[3]/div[1]/div[2]/app-spread-line/label/span[@class='points-line']")));
                                    if (elementList4.Count == 0)
                                    {
                                        elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[5]/div[1]/div[3]/div[1]/div[2]/app-spread-line/label/span[@class='points-line']")));
                                        if (elementList4.Count == 0)
                                        {
                                            elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[5]/div[1]/div[3]/div[1]/div[2]/app-spread-line/label/span[@class='points-line']")));
                                            if (elementList4.Count == 0)
                                            {
                                                elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[5]/div[1]/div[3]/div[1]/div[2]/app-spread-line/label/span[@class='points-line']")));
                                                if (elementList4.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en FOOTBALL. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[5]/div[1]/div[3]/div[1]/div[2]/app-spread-line/label/span[@class='points-line']")).Click();
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[5]/div[1]/div[3]/div[1]/div[2]/app-spread-line/label/span[@class='points-line']")).Click();
                                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[5]/div[1]/div[3]/div[1]/div[2]/app-spread-line/label/span[@class='points-line']")).Click();
                                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[5]/div[1]/div[3]/div[1]/div[2]/app-spread-line/label/span[@class='points-line']")).Click();
                                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                case "total":
                                    elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[5]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='points-line']")));
                                    if (elementList4.Count == 0)
                                    {
                                        elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[5]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='points-line']")));
                                        if (elementList4.Count == 0)
                                        {
                                            elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[5]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='points-line']")));
                                            if (elementList4.Count == 0)
                                            {
                                                elementList4.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[5]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='points-line']")));
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
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[5]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='points-line']")).Click();
                                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[5]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='points-line']")).Click();
                                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[5]/div[1]/div[4]/div[1]/div[2]/app-total-line/label/span[@class='points-line']")).Click();
                                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                default:
                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No existe el tipo de apuesta "+typebet+ ". Validar!!");

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
                            List<IWebElement> elementList3 = new List<IWebElement>();
                            switch (typebet)
                            {
                                case "spread":
                                    elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[4]/div[1]/div[3]/div[1]/div[1]/app-spread-line/label/span[@class='points-line']")));
                                    if (elementList3.Count == 0)
                                    {
                                        elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[4]/div[1]/div[3]/div[1]/div[1]/app-spread-line/label/span[@class='points-line']")));
                                        if (elementList3.Count == 0)
                                        {
                                            elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[4]/div[1]/div[3]/div[1]/div[1]/app-spread-line/label/span[@class='points-line']")));
                                            if (elementList3.Count == 0)
                                            {
                                                elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[4]/div[1]/div[3]/div[1]/div[1]/app-spread-line/label/span[@class='points-line']")));
                                                if (elementList3.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en BASKETBALL. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[4]/div[1]/div[3]/div[1]/div[1]/app-spread-line/label/span[@class='points-line']")).Click();
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[4]/div[1]/div[3]/div[1]/div[1]/app-spread-line/label/span[@class='points-line']")).Click();
                                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[4]/div[1]/div[3]/div[1]/div[1]/app-spread-line/label/span[@class='points-line']")).Click();
                                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[4]/div[1]/div[3]/div[1]/div[1]/app-spread-line/label/span[@class='points-line']")).Click();
                                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                        return true;
                                    }
                                case "total":
                                    elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[4]/div[1]/div[4]/div[1]/div[1]/app-total-line/label/span[@class='points-line']")));
                                    if (elementList3.Count == 0)
                                    {
                                        elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[4]/div[1]/div[4]/div[1]/div[1]/app-total-line/label/span[@class='points-line']")));
                                        if (elementList3.Count == 0)
                                        {
                                            elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[4]/div[1]/div[4]/div[1]/div[1]/app-total-line/label/span[@class='points-line']")));
                                            if (elementList3.Count == 0)
                                            {
                                                elementList3.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[4]/div[1]/div[4]/div[1]/div[1]/app-total-line/label/span[@class='points-line']")));
                                                if (elementList3.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en BASKETBALL. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[4]/div[1]/div[4]/div[1]/div[1]/app-total-line/label/span[@class='points-line']")).Click();
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[4]/div[1]/div[4]/div[1]/div[1]/app-total-line/label/span[@class='points-line']")).Click();
                                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-general[1]/div[4]/div[1]/div[4]/div[1]/div[1]/app-total-line/label/span[@class='points-line']")).Click();
                                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-general[1]/div[4]/div[1]/div[4]/div[1]/div[1]/app-total-line/label/span[@class='points-line']")).Click();
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
                            switch (typebet)
                            {
                                case "moneyline":
                                    elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-soc/div[1]/div[1]/div[3]/div/div[3]/app-money-line/label/span[@class='odds']")));
                                    if (elementList2.Count == 0)
                                    {
                                        elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-soc/div[1]/div[1]/div[3]/div/div[3]/app-money-line/label/span[@class='odds']")));
                                        if (elementList2.Count == 0)
                                        {
                                            elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-soc/div[1]/div[1]/div[3]/div/div[3]/app-money-line/label/span[@class='odds']")));
                                            if (elementList2.Count == 0)
                                            {
                                                elementList2.AddRange(VariablesGlobales.Sdriver.FindElements(By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-soc/div[1]/div[1]/div[3]/div/div[3]/app-money-line/label/span[@class='odds']")));
                                                if (elementList2.Count == 0)
                                                {
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);

                                                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " No hay lineas parametrizadas para apostar en SOCCER. Validar!!");
                                                }
                                                else
                                                {
                                                    VariablesGlobales.Sdriver.FindElement(
                                                    By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[2]/app-game-soc/div[1]/div[1]/div[3]/div/div[3]/app-money-line/label/span[@class='odds']")).Click();
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-soc/div[1]/div[1]/div[3]/div/div[3]/app-money-line/label/span[@class='odds']")).Click();
                                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-soc/div[1]/div[1]/div[3]/div/div[3]/app-money-line/label/span[@class='odds']")).Click();
                                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-soc/div[1]/div[1]/div[3]/div/div[3]/app-money-line/label/span[@class='odds']")).Click();
                                        helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                        System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
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
                                                    helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                    return true;
                                                }
                                            }
                                            else
                                            {
                                                VariablesGlobales.Sdriver.FindElement(
                                                By.XPath("//div[@class='sports-league']/app-schedule-dategroup[2]/div[2]/app-schedule-game-american[1]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")).Click();
                                                helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                                System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            VariablesGlobales.Sdriver.FindElement(
                                            By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[2]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")).Click();
                                            helper.CapturaScreenShotWeb(VariablesGlobales.DirectorioSecundario,
                                            System.Reflection.MethodBase.GetCurrentMethod().Name + '_' + VariablesGlobales.Contador, VariablesGlobales.Sdriver);
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        VariablesGlobales.Sdriver.FindElement(
                                        By.XPath("//div[@class='sports-league']/app-schedule-dategroup[1]/div[2]/app-schedule-game-american[1]/app-game-soc/div[1]/div[1]/div[4]/div/div[2]/app-total-line/label/span[@class='odds']")).Click();
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

        #endregion
    }
}
