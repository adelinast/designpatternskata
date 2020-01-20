using NUnit.Framework;

namespace DPKata2
{
    public class AppTest
    {
        private ConfigRules _configRules;
        private Application _app;

        [SetUp]
        public void Init()
        {
            _configRules = new ConfigRules();
            _app = new Application();
        }

        [TearDown]
        public void Dispose()
        {
        }

        #region Sample_TestCode

        [TestCase()]
        public void ScanEicar()
        {
            _configRules.ConfigAntivirusRule("antivirus-rule");
            _app.SetURL("http://eicar.org/download/eicar.com");

            var result =_app.Run();

            Assert.AreEqual(result, FilterResult.MALWARE);
        }
       
        #endregion
    }
}
