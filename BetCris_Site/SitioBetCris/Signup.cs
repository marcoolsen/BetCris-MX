using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Variables;
using Ejecucion_Pruebas;
using System.Data;
using NUnit.Framework;
using System.Reflection;
using System.Linq;

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


        [Test]
        public void SignUpAllCountries()
        {
            VariablesGlobales.strCarpetaPrincipal = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VariablesGlobales.strDirectorio = helper.CreaDirectorio(VariablesGlobales.strCarpetaPrincipal);

            helper.InicilizaContador();

            #region MyRegion
            Random random = new Random();
            string firsName = "Automation";
            string lastName = "Test";
            string day = "1";
            string month = "1";
            string year = "1990";
            string email = string.Format("qa{0:0000}@test.com", random.Next(100000));
            string password = "ABC123xyz";
            string repassword = "ABC123xyz";
            string phone = "88888888";
            string coin = "1";

            #endregion

            helper.CreaArchivoResultados(VariablesGlobales.path);
            helper.CreaArchivoResultados(VariablesGlobales.pathemail);
            /*paises que no van 
             CzechRepublic, Finland, Germany, Lithuania, Luxembourg, Malta, Netherlands, Norway, Romania, Slovakia, Uruguay, 
             */
            AssertAll.Succeed(
            () => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email, password, repassword, "Aland Islands", phone, coin)),
            () => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Albania", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Algeria", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Angola", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Anguilla", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Antarctica", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Andorra", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Antigua And Barbuda", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Armenia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Aruba", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Azerbaijan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Bahamas", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Bahrain", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Bangladesh", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Barbados", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Belarus", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Belize", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Benin", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Bermuda", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Bhutan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Bolivia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Bosnia and Herzegovina", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Botswana", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Bouvet Island", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Brazil", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Brunei", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Burkina Faso", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Burundi", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Cambodia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Cameroon", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Canada", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Cape Verde", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Cayman Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Central African Republic", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Chad", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Chile", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "China", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Christmas Island", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Cocos(Keeling)Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Comoros", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Congo", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Congo Democractic Republic of the", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Cook Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "CoteD'Ivoire(IvoryCoast)", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Croatia(Hrvatska)", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Cuba", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Djibouti", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Dominica", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Dominican Republic", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "East Timor (Timor-Leste)", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Ecuador", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Egypt", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "El Salvador", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Equatorial Guinea", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Eritrea", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Ethiopia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Falkland Islands(Islas Malvinas)", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Faroe Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Fiji Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "French Guiana", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "French Polynesia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Gabon", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Gambia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Georgia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Ghana", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Greenland", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Grenada", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Guadeloupe", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Guatemala", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Guinea", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Guinea-Bissau", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Guyana", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Haiti", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Heard and McDonald Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Honduras", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Hong Kong S.A.R.", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Iceland", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "India", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Indonesia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Iran", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Iraq", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Jamaica", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Japan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Jordan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Kazakhstan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Kenya", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Kiribati", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Korea", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Korea North", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Kuwait", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Kyrgyzstan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Laos", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Lebanon", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Lesotho", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Liberia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Libya", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Liechtenstein", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Macau S.A.R.", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Macedonia Former Yugoslav Republic of", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Madagascar", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Malawi", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Malaysia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Maldives", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Mali", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Marshall Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Martinique", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Mauritania", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Mauritius", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Mayotte", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Mexico", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Micronesia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Moldova", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Monaco", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Mongolia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Montenegro", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Montserrat", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Morocco", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Mozambique", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Myanmar", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Namibia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Nauru", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Nepal", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Netherlands Antilles", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "New Caledonia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "New Zealand", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Nicaragua", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Niger", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Nigeria", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Niue", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Norfolk Island", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Northern Mariana Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Oman", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Pakistan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Palau", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Panama", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Papua new Guinea", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Paraguay", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Peru", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Philippines", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Qatar", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Reunion", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Russia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Rwanda", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Saint Kitts And Nevis", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Saint Lucia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Saint Pierre and Miquelon", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "SaintVincent And The Grenadines", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Samoa", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "San Marino", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Sao Tome and Principe", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Saudi Arabia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Senegal", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Serbia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Seychelles", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Sierra Leone", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Singapore", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Somalia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "South Africa", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "SriLanka", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Sudan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Suriname", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Svalbard And Jan Mayen Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Swaziland", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Switzerland", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Syria", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Taiwan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Tajikistan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Tanzania", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Thailand", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Togo", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Tokelau", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Tonga", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Trinidad And Tobago", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Tunisia", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Turkmenistan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Turks And Caicos Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Tuvalu", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Uganda", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Ukraine", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "United Arab Emirates", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Uzbekistan", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Vanuatu", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Vatican City State (HolySee)", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Venezuela", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Vietnam", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Wallis And Futuna Islands", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Western Sahara", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Yemen", phone, coin)),
            //() => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Zambia", phone, coin)),
            () => NUnit.Framework.Assert.IsTrue(signup.ReviewSignup(firsName, lastName, day, month, year, email = string.Format("qa{0:0000}@test.com", random.Next(100000)), password, repassword, "Zimbabwe", phone, coin))
            );
        }

        public static class AssertAll
        {
            public static void Succeed(params Action[] assertions)
            {
                var errors = new List<Exception>();
                Helper helper = new Helper();
                foreach (var assertion in assertions)
                    try
                    {
                        helper.IniciaBrowser(VariablesGlobales.urlbetcrisPrd, VariablesGlobales.navegador);

                        assertion();

                        helper.CierraNavegador(VariablesGlobales.Sdriver);
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex);
                    }

                if (errors.Any())
                {
                    var ex = new AssertionException(
                        string.Join(Environment.NewLine, errors.Select(e => e.Message)),
                        errors.First());

                    // Use stack trace from the first exception to ensure first
                    // failed Assert is one click away
                    ReplaceStackTrace(ex, errors.First().StackTrace);

                    throw ex;
                }
            }

            static void ReplaceStackTrace(Exception exception, string stackTrace)
            {
                var remoteStackTraceString = typeof(Exception)
                    .GetField("_remoteStackTraceString",
                        BindingFlags.Instance | BindingFlags.NonPublic);

                remoteStackTraceString.SetValue(exception, stackTrace);
            }
        }
    }
}
