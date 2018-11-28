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
    public class ContactModificationTests:AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {

            if (!app.Contacts.CheckContactExistence())
            {
                ContactData contact = new ContactData("FirstName new", "LastName new");
                app.Contacts.Create(contact);
            }
            ContactData updatedContact = new ContactData("updated FirstName new", "updated LastName new");

            app.Contacts.Modify(1, updatedContact);

      
        }
    }
}
