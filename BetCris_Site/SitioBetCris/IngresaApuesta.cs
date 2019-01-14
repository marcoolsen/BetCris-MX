using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Variables;
using Ejecucion_Pruebas;
using System.Collections.Generic;
using System.Data;


namespace BetCris_Site.Sitio
{
    [TestClass]
    public class IngresaApuesta
    {
        Ejecucion_Pruebas.Helper helper = new Helper();
        Ejecucion_Pruebas.Sitio.Login login = new Ejecucion_Pruebas.Sitio.Login();
        Ejecucion_Pruebas.SitioBetCris.IngresaApuesta ingresaApuesta = new Ejecucion_Pruebas.SitioBetCris.IngresaApuesta();

        [TestMethod]
        [TestInitialize]
        public void LoginSite()
        {
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();

            Assert.IsTrue(helper.IniciaBrowser(VariablesGlobales.urlbetcrisMX, VariablesGlobales.navegador));
            Assert.IsTrue(login.IngresaSiteBetCris(VariablesGlobales.playerid, VariablesGlobales.playerpass));
        }

        [TestMethod]
        public void InsertStraighBet()
        {
            #region VariablesLocales
            string riskAmount = "3.00";
            string sport = "E-SPORTS";
            string manual = "0";
            string typebet = "spread";
            #endregion
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();

            Assert.IsTrue(ingresaApuesta.InsertStrainghBet(riskAmount, sport, manual, typebet));
            helper.CierraNavegador(VariablesGlobales.Sdriver);

        }

        [TestMethod]
        public void InsertStraighBetWithFP()
        {
            #region VariablesLocales
            string riskAmount = "2.00";
            string sport = "HOCKEY";
            string manual = "0";
            string typebet = "spread";
            #endregion
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();

            Assert.IsTrue(ingresaApuesta.InsertStrainghtBetFreePlay(riskAmount, sport, manual, typebet));

        }

        [TestMethod]
        public void InsertStraighBetMultiples()
        {
            #region VariablesLocales
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Sport", typeof(string));
            table.Columns.Add("amount", typeof(string));
            table.Columns.Add("Search", typeof(string));
            table.Columns.Add("TypeBet", typeof(string));

            table.Rows.Add("0","FOOTBALL","2.00", "0", "total");
            table.Rows.Add("1", "BASKETBALL", "2.00", "0", "total");
            table.Rows.Add("2", "SOCCER", "2.00", "0", "moneyline");

            #endregion
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();

            Assert.IsTrue(ingresaApuesta.InsertStraingtMultiples(table));

        }

        [TestMethod]
        public void InsertParlay()
        {
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
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();

            Assert.IsTrue(ingresaApuesta.InsertParlay(table, riskAmount));

        }

        [TestMethod]
        public void InsertTeaser()
        {
            #region VariablesLocales
            DataTable table = new DataTable();
            table.Columns.Add("Sport", typeof(string));
            table.Columns.Add("Search", typeof(string));
            table.Columns.Add("TypeBet", typeof(string));
            string riskAmount = "2.00";
            table.Rows.Add("BASKETBALL", "0", "spread");
            table.Rows.Add("FOOTBALL", "0", "total");
            #endregion
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();


            Assert.IsTrue(ingresaApuesta.InsertTeaser(riskAmount, table));

        }
    }
}
