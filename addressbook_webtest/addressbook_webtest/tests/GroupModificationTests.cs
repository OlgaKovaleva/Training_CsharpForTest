using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupModificationTests:TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData = new GroupData("group_name new3");

            newGroupData.Header = "group_header new3";
            newGroupData.Footer = "group_footer new3";
            app.Groups.Modify(1, newGroupData);
            app.Auth.Logout();
        }
    }
}
