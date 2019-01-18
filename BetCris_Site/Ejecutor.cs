using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Variables;
using Ejecucion_Pruebas;

namespace BetCris_Site
{
    [TestClass]
    public class Ejecutor
    {
        Helper helper = new Helper();
        BetCris_Site.Sitio.IngresaApuesta ingresaApuesta = new Sitio.IngresaApuesta();
        BetCris_Site.MobileBetCris.PreLogin preLogin = new MobileBetCris.PreLogin();
        BetCris_Site.MobileBetCris.Apuestas apuestas = new MobileBetCris.Apuestas();

       // [TestMethod]
        public void Disparador()
        {
            ingresaApuesta.LoginSite();
            //ingresaApuesta.InsertStraighBet();
            ////ingresaApuesta.InsertStraighBetWithFP();
            //ingresaApuesta.InsertStraighBetMultiples();
            //ingresaApuesta.InsertParlay();
            //ingresaApuesta.InsertTeaser();
        }

       // [TestMethod]
        public void DisparadorMobile()
        {
            preLogin.RevisionGeneral();
            apuestas.PreloginBetEnd();
            apuestas.StraightBet();
            apuestas.Parlay();
        }

    }
}
