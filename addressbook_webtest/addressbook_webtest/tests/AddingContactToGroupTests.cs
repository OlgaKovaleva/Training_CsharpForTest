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
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contactToAdd =ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contactToAdd, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contactToAdd);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
