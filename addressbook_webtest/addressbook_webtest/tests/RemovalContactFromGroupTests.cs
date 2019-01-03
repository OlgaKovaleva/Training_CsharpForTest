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
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contactToRemove = ContactData.GetAll().Except(oldList).First();

            app.Contacts.RemoveContactFromGroup(contactToRemove, group);

            //List<ContactData> newList = group.GetContacts();
            //oldList.Add(contactToAdd);
            //newList.Sort();
            //oldList.Sort();

            //Assert.AreEqual(oldList, newList);

        }
    }
}
