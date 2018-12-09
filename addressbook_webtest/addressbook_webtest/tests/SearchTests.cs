using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class SearchTests:AuthTestBase
    {
        [Test]
        public void SearchTest()
        {
            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
        }
    }
}
