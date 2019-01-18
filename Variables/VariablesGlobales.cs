using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Data;

namespace Variables
{
    public class VariablesGlobales
    {
        #region VariablesSelenium
        public static IWebDriver Sdriver;
        public static IWebElement Selement;

        #endregion

        #region BetCris
        public const string urlbetcrisMX = "https://qa.betcris.mx/";
        public const string urlbetcrisPrd = "https://betcris.com/";
        public const string navegador = "chrome";
        public static string mobiledevice = "iPhone 6/7/8 Plus"; 

        public const string playerid = "testgraph";
        public const string playerpass = "prog2";
        public const string x = "2";
        public const string y = "4";

        #endregion

        #region VariablesScreent
        public static string strDirectorio;
        public static string strCarpetaPrincipal;
        public static string DirectorioSecundario;
        public static string DirectorioTerciario;
        public static int Contador;
        #endregion

        public static string path = @"C:\Automation\BetCris\Evidencias\" + "SignUp-Results-" + DateTime.Now.Year.ToString() + '_' + DateTime.Now.Month.ToString() + '_' + DateTime.Now.Day.ToString() + ".txt";
        public static string pathemail = @"C:\Automation\BetCris\Evidencias\" + "Emails-" + DateTime.Now.Year.ToString() + '_' + DateTime.Now.Month.ToString() + '_' + DateTime.Now.Day.ToString() + ".txt";


    }
}
