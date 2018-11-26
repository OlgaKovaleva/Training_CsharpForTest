using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupModificationTests:AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData = new GroupData("group_name new3");

            newGroupData.Header = "group_header new3";
            newGroupData.Footer = "group_footer new3";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newGroupData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newGroupData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}
