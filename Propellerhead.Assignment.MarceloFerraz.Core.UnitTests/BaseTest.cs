using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Propellerhead.Assignment.MarceloFerraz.Core.UnitTests
{
    public class BaseTest
    {
        protected Random random;

        public BaseTest()
        {
            random = new Random(new Random().Next());
        }

        protected static void AssertShouldThrow<T>(Action functionToFail, string expectedMessage)
        {
            try
            {
                functionToFail();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }
    }
}
