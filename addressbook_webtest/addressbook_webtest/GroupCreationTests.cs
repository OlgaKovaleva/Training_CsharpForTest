using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            OpenGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("group_name new");
            group.Header = "group_header new";
            group.Footer = "group_footer new";
            FillGroupCreation(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }

    }
}
