using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Variables;
using Ejecucion_Pruebas;
using System.Data;

namespace BetCris_Site.MobileBetCris
{
    [TestClass]
    public class Apuestas
    {
        Ejecucion_Pruebas.Helper helper = new Helper();
        Ejecucion_Pruebas.MobileBetCris.LoginMobile login = new Ejecucion_Pruebas.MobileBetCris.LoginMobile();
        Ejecucion_Pruebas.MobileBetCris.Apuestas apuestas = new Ejecucion_Pruebas.MobileBetCris.Apuestas();


        [TestMethod]
        public void PreloginBetEnd()
        {
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();

            // helper.IniciaBrowserMobile(VariablesGlobales.urlbetcrisMX, VariablesGlobales.mobiledevice);
            Assert.IsTrue(login.IngresaMobileBetCris(VariablesGlobales.playerid, VariablesGlobales.playerpass));
        }

        [TestMethod]
        public void StraightBet()
        {
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();
            #region VariablesLocales
            string sport = "FOOTBALL";
            string manual = "0";
            string typebet = "spread";
            string riskAmount = "10.00";
            #endregion
            // helper.IniciaBrowserMobile(VariablesGlobales.urlbetcrisMX, VariablesGlobales.mobiledevice);
            Assert.IsTrue(apuestas.InsertStraightBet(sport, manual, typebet, riskAmount));
        }
        [TestMethod]
        public void Parlay()
        {
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();

            #region VariablesLocales

            DataTable table = new DataTable();
            table.Columns.Add("Sport", typeof(string));
            table.Columns.Add("Search", typeof(string));
            table.Columns.Add("TypeBet", typeof(string));
            string riskAmount = "2.00";
            table.Rows.Add("FOOTBALL", "0", "total");
            table.Rows.Add("BASKETBALL", "0", "spread");
            table.Rows.Add("SOCCER", "0", "moneyline");
            #endregion
            // helper.IniciaBrowserMobile(VariablesGlobales.urlbetcrisMX, VariablesGlobales.mobiledevice);
            Assert.IsTrue(apuestas.InsertParlay(table, riskAmount));
        }

    }
}
