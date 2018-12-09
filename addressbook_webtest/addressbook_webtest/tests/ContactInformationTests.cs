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
    class ContactInformationTests: AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllTelephones, fromForm.AllTelephones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }   
    }
}
