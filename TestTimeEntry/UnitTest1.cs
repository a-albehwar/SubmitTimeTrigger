using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubmitTimeTrigger.Interfaces;
using System;

namespace TestTimeEntry
{
    [TestClass]
    public class UnitTest1
    {

        private readonly IHelper _helper;
        private readonly IAuth _auth;
        private readonly IValidation _validation;
        private readonly ITimeEntry _entrytime;
        public UnitTest1(IHelper helper, IAuth auth, IValidation validation, ITimeEntry entrytime)
        {
            this._helper = helper;
            this._auth = auth;
            this._validation = validation;
            this._entrytime = entrytime;
        }

        [TestMethod]
        public void TestTimeEntry()
        {
            Guid guid=_entrytime.AddTimeEntry(Convert.ToDateTime("12/12/2020"),Convert.ToDateTime( "12/12/2020"));
            Assert.AreNotEqual(Guid.Empty, guid);
        }
        [TestMethod]
        public void TestConnectionString()
        {
            string connection = _helper.GetConnectionStringFromSettings("DataVerseConnectionString");
            Assert.AreNotEqual("", connection);
        }
    }
}