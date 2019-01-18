using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Variables;
using Ejecucion_Pruebas;

namespace BetCris_Site.MobileBetCris
{
    [TestClass]
    public class PreLogin
    {
        Ejecucion_Pruebas.Helper helper = new Helper();
        Ejecucion_Pruebas.MobileBetCris.PreLogin preLogin = new Ejecucion_Pruebas.MobileBetCris.PreLogin();

      //  [TestMethod]
        public void RevisionGeneral()
        {
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();

            helper.IniciaBrowserMobile(VariablesGlobales.urlbetcrisMX, VariablesGlobales.mobiledevice);
            Assert.IsTrue(preLogin.GeneralReview());
           // helper.CierraNavegador(VariablesGlobales.Sdriver);
        }
    }
}
