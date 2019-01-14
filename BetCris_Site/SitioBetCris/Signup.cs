using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Variables;
using Ejecucion_Pruebas;
using System.Data;

namespace BetCris_Site.SitioBetCris
{
    /// <summary>
    /// Summary description for Signup
    /// </summary>
    [TestClass]
    public class Signup
    {
        Helper helper = new Helper();
        Ejecucion_Pruebas.SitioBetCris.Signup signup = new Ejecucion_Pruebas.SitioBetCris.Signup();

        [TestMethod]
        public void SignUpAllCountries()
        {
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();

            #region MyRegion
            Random random = new Random();
            DataTable table = new DataTable();

            table.Columns.Add("country", typeof(string));
            //table.Rows.Add("Aland Islands");
            //table.Rows.Add("Albania");
            //table.Rows.Add("Algeria");
            //table.Rows.Add("Angola");
            //table.Rows.Add("Anguilla");
            //table.Rows.Add("Antarctica");
            //table.Rows.Add("Andorra");
            //table.Rows.Add("Antigua And Barbuda");
            //table.Rows.Add("Armenia");
            //table.Rows.Add("Aruba");
            //table.Rows.Add("Azerbaijan");
            //table.Rows.Add("Bahamas");
            //table.Rows.Add("Bahrain");
            //table.Rows.Add("Bangladesh");
            //table.Rows.Add("Barbados");
            //table.Rows.Add("Belarus");
            //table.Rows.Add("Belize");
            //table.Rows.Add("Benin");
            //table.Rows.Add("Bermuda");
            //table.Rows.Add("Bhutan");
            //table.Rows.Add("Bolivia");
            //table.Rows.Add("Bosnia and Herzegovina");
            //table.Rows.Add("Botswana");
            table.Rows.Add("Bouvet Island");
            table.Rows.Add("Brazil");
            table.Rows.Add("Brunei");
            table.Rows.Add("Burkina Faso");
            table.Rows.Add("Burundi");
            table.Rows.Add("Cambodia");
            table.Rows.Add("Cameroon");
            table.Rows.Add("Canada");
            table.Rows.Add("Cape Verde");
            table.Rows.Add("Cayman Islands");
            table.Rows.Add("Central African Republic");
            table.Rows.Add("Chad");
            table.Rows.Add("Chile");
            table.Rows.Add("China");
            table.Rows.Add("Christmas Island");
            table.Rows.Add("Cocos(Keeling)Islands");
            table.Rows.Add("Comoros");
            table.Rows.Add("Congo");
            table.Rows.Add("Congo Democractic Republic of the");
            table.Rows.Add("Cook Islands");
            table.Rows.Add("CoteD'Ivoire(IvoryCoast)");
            table.Rows.Add("Croatia(Hrvatska)");
            table.Rows.Add("Cuba");
            table.Rows.Add("CzechRepublic");
            table.Rows.Add("Djibouti");
            table.Rows.Add("Dominica");
            table.Rows.Add("Dominican Republic");
            table.Rows.Add("East Timor (Timor-Leste)");
         //   table.Rows.Add("Ecuador");
            table.Rows.Add("Egypt");
            table.Rows.Add("El Salvador");
            table.Rows.Add("Equatorial Guinea");
            table.Rows.Add("Eritrea");
            table.Rows.Add("Ethiopia");
            table.Rows.Add("Falkland Islands(Islas Malvinas)");
            table.Rows.Add("Faroe Islands");
            table.Rows.Add("Fiji Islands");
            table.Rows.Add("Finland");
          //  table.Rows.Add("French Guiana");
            table.Rows.Add("French Polynesia");
            table.Rows.Add("Gabon");
            table.Rows.Add("Gambia");
            table.Rows.Add("Georgia");
            table.Rows.Add("Germany");
            table.Rows.Add("Ghana");
            table.Rows.Add("Greenland");
            table.Rows.Add("Grenada");
            table.Rows.Add("Guadeloupe");
            table.Rows.Add("Guatemala");
            table.Rows.Add("Guinea");
            table.Rows.Add("Guinea-Bissau");
            table.Rows.Add("Guyana");
            table.Rows.Add("Haiti");
            table.Rows.Add("Heard and McDonald Islands");
            table.Rows.Add("Honduras");
            table.Rows.Add("Hong Kong S.A.R.");
            table.Rows.Add("Iceland");
            table.Rows.Add("India");
            table.Rows.Add("Indonesia");
            table.Rows.Add("Iran");
            table.Rows.Add("Iraq");
            table.Rows.Add("Jamaica");
            table.Rows.Add("Japan");
            table.Rows.Add("Jordan");
            table.Rows.Add("Kazakhstan");
            table.Rows.Add("Kenya");
            table.Rows.Add("Kiribati");
            table.Rows.Add("Korea");
            table.Rows.Add("Korea North");
            table.Rows.Add("Kuwait");
            table.Rows.Add("Kyrgyzstan");
            table.Rows.Add("Laos");
            table.Rows.Add("Lebanon");
            table.Rows.Add("Lesotho");
            //table.Rows.Add("Liberia");
            //table.Rows.Add("Libya");
            //table.Rows.Add("Liechtenstein");
            //table.Rows.Add("Lithuania");
            //table.Rows.Add("Luxembourg");
            //table.Rows.Add("Macau S.A.R.");
            //table.Rows.Add("Macedonia Former Yugoslav Republic of");
            //table.Rows.Add("Madagascar");
            //table.Rows.Add("Malawi");
            //table.Rows.Add("Malaysia");
            //table.Rows.Add("Maldives");
            //table.Rows.Add("Mali");
            //table.Rows.Add("Malta");
            //table.Rows.Add("Marshall Islands");
            //table.Rows.Add("Martinique");
            //table.Rows.Add("Mauritania");
            //table.Rows.Add("Mauritius");
            //table.Rows.Add("Mayotte");
            //table.Rows.Add("Mexico");
            //table.Rows.Add("Micronesia");
            //table.Rows.Add("Moldova");
            //table.Rows.Add("Monaco");
            //table.Rows.Add("Mongolia");
            //table.Rows.Add("Montenegro");
            //table.Rows.Add("Montserrat");
            //table.Rows.Add("Morocco");
            //table.Rows.Add("Mozambique");
            //table.Rows.Add("Myanmar");
            //table.Rows.Add("Namibia");
            //table.Rows.Add("Nauru");
            //table.Rows.Add("Nepal");
            //table.Rows.Add("Netherlands");
            //table.Rows.Add("Netherlands Antilles");
            //table.Rows.Add("New Caledonia");
            //table.Rows.Add("New Zealand");
            //table.Rows.Add("Nicaragua");
            //table.Rows.Add("Niger");
            //table.Rows.Add("Nigeria");
            //table.Rows.Add("Niue");
            //table.Rows.Add("Norfolk Island");
            //table.Rows.Add("Northern Mariana Islands");
            //table.Rows.Add("Norway");
            //table.Rows.Add("Oman");
            //table.Rows.Add("Pakistan");
            //table.Rows.Add("Palau");
            //table.Rows.Add("Panama");
            //table.Rows.Add("Papua new Guinea");
            //table.Rows.Add("Paraguay");
            //table.Rows.Add("Peru");
            //table.Rows.Add("Philippines");
            //table.Rows.Add("Qatar");
            //table.Rows.Add("Reunion");
            //table.Rows.Add("Romania");
            //table.Rows.Add("Russia");
            //table.Rows.Add("Rwanda");
            //table.Rows.Add("Saint Kitts And Nevis");
            //table.Rows.Add("Saint Lucia");
            //table.Rows.Add("Saint Pierre and Miquelon");
            //table.Rows.Add("SaintVincent And The Grenadines");
            //table.Rows.Add("Samoa");
            //table.Rows.Add("San Marino");
            //table.Rows.Add("Sao Tome and Principe");
            //table.Rows.Add("Saudi Arabia");
            //table.Rows.Add("Senegal");
            //table.Rows.Add("Serbia");
            //table.Rows.Add("Seychelles");
            //table.Rows.Add("Sierra Leone");
            //table.Rows.Add("Singapore");
            //table.Rows.Add("Slovakia");
            //table.Rows.Add("Somalia");
            //table.Rows.Add("South Africa");
            //table.Rows.Add("SriLanka");
            //table.Rows.Add("Sudan");
            //table.Rows.Add("Suriname");
            //table.Rows.Add("Svalbard And Jan Mayen Islands");
            //table.Rows.Add("Swaziland");
            //table.Rows.Add("Switzerland");
            //table.Rows.Add("Syria");
            //table.Rows.Add("Taiwan");
            //table.Rows.Add("Tajikistan");
            //table.Rows.Add("Tanzania");
            //table.Rows.Add("Thailand");
            //table.Rows.Add("Togo");
            //table.Rows.Add("Tokelau");
            //table.Rows.Add("Tonga");
            //table.Rows.Add("Trinidad And Tobago");
            //table.Rows.Add("Tunisia");
            //table.Rows.Add("Turkmenistan");
            //table.Rows.Add("Turks And Caicos Islands");
            //table.Rows.Add("Tuvalu");
            //table.Rows.Add("Uganda");
            //table.Rows.Add("Ukraine");
            //table.Rows.Add("United Arab Emirates");
            //table.Rows.Add("Uruguay");
            //table.Rows.Add("Uzbekistan");
            //table.Rows.Add("Vanuatu");
            //table.Rows.Add("Vatican City State (HolySee)");
            //table.Rows.Add("Venezuela");
            //table.Rows.Add("Vietnam");
            //table.Rows.Add("Wallis And Futuna Islands");
            //table.Rows.Add("Western Sahara");
            //table.Rows.Add("Yemen");
            //table.Rows.Add("Zambia");
            //table.Rows.Add("Zimbabwe");

            #endregion

            helper.CreaArchivoResultados(VariablesGlobales.path);
            helper.CreaArchivoResultados(VariablesGlobales.pathemail);

            foreach (DataRow row in table.Rows)
            {
                string firsName = "Automation";
                string lastName = "Test";
                string day = "1";
                string month = "1";
                string year = "1990";
                string email = string.Format("qa{0:0000}@test.com", random.Next(100000));
                string password = "ABC123xyz";
                string repassword = "ABC123xyz";
                string country = row["country"].ToString();
                string phone = "88888888";
                string coin = "1";


                helper.IniciaBrowser(VariablesGlobales.urlbetcrisPrd, VariablesGlobales.navegador);
                Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email, password, repassword, country, phone, coin));
                helper.CierraNavegador(VariablesGlobales.Sdriver);
            }

        }
    }
}
