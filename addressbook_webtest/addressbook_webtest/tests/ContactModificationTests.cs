using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests:AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            

            ContactData newContactData = new ContactData("updated FirstName new", "updated LastName new");

            app.Contacts.Modify(1, newContactData);

      
        }
    }
}
