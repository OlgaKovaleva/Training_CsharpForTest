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


            //пробегаться по группе и проверять, что в ней есть хотя бы 1 контакт
            int groupCount = GroupData.GetAll().Count;
            
            foreach (GroupData group in GroupData.GetAll())
            {
                int contactCountOfGroup = group.GetContacts().Count;
                if (contactCountOfGroup > 0)
                {
                    ContactData contactToRemove = group.GetContacts().First();
                    List<ContactData> oldList = group.GetContacts();

                    //action
                    app.Contacts.RemoveContactFromGroup(contactToRemove, group);

                    //checks
                    List<ContactData> newList = group.GetContacts();
                    oldList.Remove(contactToRemove);
                    newList.Sort();
                    oldList.Sort();

                    Assert.AreEqual(oldList, newList);
                }
                else break;
            }
           
        }
    }
}
