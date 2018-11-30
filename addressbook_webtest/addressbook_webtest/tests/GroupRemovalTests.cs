using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: AuthTestBase
    {
       

        [Test]
        public void GroupRemovalTest()
        {
            
            if (!app.Groups.CheckGroupExistence())
            {
                GroupData group = new GroupData("group_name new");
                group.Header = "group_header new";
                group.Footer = "group_footer new";
                app.Groups.Create(group);

            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            
            app.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count-1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0); //удалить первый элемент с указателем 0
           
            Assert.AreEqual(oldGroups, newGroups); //сравниваем не размеры, а сами списки
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
     
    }
}
