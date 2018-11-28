using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests:AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            if (!app.Contacts.CheckContactExistence())
            {
                ContactData contact = new ContactData("FirstName new", "LastName new");
                app.Contacts.Create(contact);
            }
            app.Contacts.Remove(1, true);
            app.Auth.Logout();

        }
    }
}