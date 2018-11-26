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
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newGroupData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newGroupData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);

            foreach (GroupData group in newGroups)
            {
                if(group.Id==oldData.Id)
                {
                    Assert.AreEqual(newGroupData.Name, group.Name);// сначала указываем ожидаемый результат, а затем фактический
                }
            }
        }
    }
}
