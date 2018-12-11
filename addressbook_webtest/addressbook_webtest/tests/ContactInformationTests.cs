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

            //Console.WriteLine(app.Contacts.GetContactBirthdayFromForm(0));
            //Console.WriteLine(app.Contacts.GetContactAgeFromForm(0));
            //Console.WriteLine(app.Contacts.GetContactAnniversaryFromForm(0));
            //Console.WriteLine(app.Contacts.GetContactAnniversaryPeriodFromForm(0));
            //Console.Write(app.Contacts.GetContactInformationFromDetails(0));
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            string contactFromEditForm = fromForm.FirstName + fromForm.MiddleName + fromForm.LastName + fromForm.Nickname + fromForm.Title+fromForm.Company + fromForm.Address +
                "H:" + fromForm.HomeTelephone + "M:" + fromForm.MobileTelephone + "W:" + fromForm.WorkTelephone + "F:" + fromForm.FaxTelephone + fromForm.Email + fromForm.Email2 + fromForm.Email3 +
                "Homepage:" + fromForm.Homepage + "Birthday" + fromForm.Birthdate + fromForm.Age + "Anniversary" + fromForm.Anniversary + fromForm.AnniversaryPeriod
                + fromForm.AddressSecondary + "P:"+fromForm.HomeSecondary + fromForm.NotesSecondary;
            string cleanedContactFromEditForm = contactFromEditForm.Replace("\r", "").Replace("\n", "").Replace(" ", "");
            string contactFromDetails = app.Contacts.GetContactInformationFromDetails(0);
            string cleanedContactFromDetails= contactFromDetails.Replace("\r", "").Replace("\n", "").Replace(" ", "");


            ////verification
            Assert.AreEqual(cleanedContactFromEditForm, cleanedContactFromDetails);

        }
    }
}
