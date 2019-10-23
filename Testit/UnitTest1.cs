using Microsoft.VisualStudio.TestTools.UnitTesting;
using Peli;

namespace Testit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VastaLuodunLemmikinOverAllHealthOnNolla()
        {
            var lemmikki = new Lemmikki();
            int result = 0;
            Assert.AreEqual(result, lemmikki.OverAllHealth);
        }

        //[TestMethod]
        //public void UusiTestiMetodi()
        //{

        //}
    }
}
