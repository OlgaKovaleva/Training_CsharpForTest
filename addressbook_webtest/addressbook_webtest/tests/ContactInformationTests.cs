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
        public void ContactInformationMainPageTest()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllTelephones, fromForm.AllTelephones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void ContactInformationDetailsTest()
        {
            
            Console.WriteLine(app.Contacts.GetContactBirthdayFromForm(1));
            Console.WriteLine(app.Contacts.GetContactAgeFromForm(1));
            Console.WriteLine(app.Contacts.GetContactAnniversaryFromForm(1));
            Console.WriteLine(app.Contacts.GetContactAnniversaryPeriodFromForm(1));
            Console.Write(app.Contacts.GetContactInformationFromDetails(1));
            //ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            //string ContactFromEditForm = app.Contacts.
            //string ContactFromDetails = app.Contacts.GetContactInformationFromDetails(0);


            //verification
            //Assert.AreEqual(ContactFromEditForm, ContactFromDetails);

        }
    }
}
