using System.Collections.Generic;
using System.Configuration;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using AutomatedOnlineStore.PageObjects;
using AutomatedOnlineStore.TestBase;
using AutomatedOnlineStore.WrapperFactory;
using NUnit.Framework;


namespace AutomatedOnlineStoreTests.Tests
{
    [TestFixture]
    public class LoginPageTest : BaseClass
    {
        private static string _path = ConfigurationManager.AppSettings["path"];
        [Test,TestCaseSource("GetLoginTestData")]
        public void ValidateLogin(string userName, string password, string expectedResult, string isValid)
        {
            var login = new LoginPage(Browser.Driver);
            login.Login(userName, password);
            if (isValid.Equals("y"))
            {
                string actual = login.SuccessMessage();
                Assert.IsTrue(actual.Contains(expectedResult), "Login Failed");
            }
            else
            {
                string actual = login._errorMessage.Text;
                Assert.IsTrue(actual.Contains(expectedResult), "Inappropriate Error Messages Displayed");
            }

        }

        private static IEnumerable<string[]> GetLoginTestData()
        {
            
            using (CsvReader csv = new CsvReader(new StreamReader(_path),true))
            {
                while (csv.ReadNextRecord())
                {
                    string userName = csv[0];
                    string password = csv[1];
                    string expectedOutput = csv[2];
                    string isValid = csv[3];
              
                    yield return new[] { userName, password, expectedOutput,isValid };
                }
            }
           
        }

    }
}
