using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests: AuthTestBase
    {
        

        [Test]
        public void TestAddingContactToGroup()
        {
            if (!app.Contacts.CheckContactExistence())
            {
                ContactData contact = new ContactData("FirstName new", "LastName new");
                app.Contacts.Create(contact);
            }
            if (!app.Groups.CheckGroupExistence())
            {
                GroupData group = new GroupData("group_name new");
                group.Header = "group_header new";
                group.Footer = "group_footer new";
                app.Groups.Create(group);

            }

            
            GroupData groupFromDb = GroupData.GetAll()[0];


            List<ContactData> oldList = groupFromDb.GetContacts();
            int amountOfContactsOutOfGroup = ContactData.GetAll().Except(oldList).Count();
            if (amountOfContactsOutOfGroup==0)
            {
                ContactData contact = new ContactData("Very FirstName new", "Very LastName new");
                app.Contacts.Create(contact);
                oldList = groupFromDb.GetContacts();
            }

            ContactData contactToAdd =ContactData.GetAll().Except(oldList).First();

                       
            app.Contacts.AddContactToGroup(contactToAdd, groupFromDb);

            List<ContactData> newList = groupFromDb.GetContacts();
            oldList.Add(contactToAdd);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
