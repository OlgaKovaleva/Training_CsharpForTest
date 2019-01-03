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

            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];

            ContactData updatedContact = new ContactData("updated FirstName new", "updated LastName new");

            app.Contacts.Modify(oldData, updatedContact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            //List<ContactData> newContacts = app.Contacts.GetContactList();
            List<ContactData> newContacts = ContactData.GetAll();


            oldContacts[0].LastName = updatedContact.LastName;
            oldContacts[0].FirstName = updatedContact.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    if (updatedContact.LastName == contact.LastName)
                    {
                        Assert.AreEqual(updatedContact.FirstName, contact.FirstName);
                    }
                    // сначала указываем ожидаемый результат, а затем фактический
                }
            }


        }
    }
}
