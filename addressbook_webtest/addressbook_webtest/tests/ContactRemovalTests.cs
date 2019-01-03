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

            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];
            
            app.Contacts.Remove(toBeRemoved);
            
            //List<ContactData> newContacts = app.Contacts.GetContactList();
            List<ContactData> newContacts = ContactData.GetAll();

            Assert.AreEqual(oldContacts.Count()-1, app.Contacts.GetContactCount());
            oldContacts.RemoveAt(0); //удалить первый элемент с указателем 0
            
            Assert.AreEqual(oldContacts, newContacts); //сравниваем не размеры, а сами списки
          
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }
    }
}