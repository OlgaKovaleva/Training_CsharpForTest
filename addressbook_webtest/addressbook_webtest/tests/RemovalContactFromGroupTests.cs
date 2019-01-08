using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    public class RemovalContactFromGroupTests: AuthTestBase
    {
        [Test]
        public void TestRemovalContactFromGroup()
        {
            //preparation
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
            int amountOfContactsInsideGroup = groupFromDb.GetContacts().Count;
            if (amountOfContactsInsideGroup<1)
            {
                ContactData contactToAdd = ContactData.GetAll().Except(groupFromDb.GetContacts()).First();
                app.Contacts.AddContactToGroup(contactToAdd, groupFromDb);
            }

            ContactData contactToRemove = groupFromDb.GetContacts().First();
            List<ContactData> oldList = groupFromDb.GetContacts();

            //action
            app.Contacts.RemoveContactFromGroup(contactToRemove, groupFromDb);

            //checks
            List<ContactData> newList = groupFromDb.GetContacts();
            oldList.Remove(contactToRemove);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }
    }
}
