using System;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupModificationTests: GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            
            if (! app.Groups.CheckGroupExistence())
            {
                GroupData group = new GroupData("group_name new");
                group.Header = "group_header new";
                group.Footer = "group_footer new";
                app.Groups.Create(group);
                
            }
            GroupData updatedGroup = new GroupData("Updated group_name new3");

            updatedGroup.Header = "Updated group_header new3";
            updatedGroup.Footer = "Updated group_footer new3";

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData oldData = oldGroups[0];


            app.Groups.Modify(oldData, updatedGroup);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();

            oldData.Name = updatedGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);

            foreach (GroupData group in newGroups)
            {
                if(group.Id==oldData.Id)
                {
                    Assert.AreEqual(updatedGroup.Name, group.Name);// сначала указываем ожидаемый результат, а затем фактический
                }
            }
        }
    }
}
