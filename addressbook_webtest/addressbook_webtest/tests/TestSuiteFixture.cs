using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    //public static ApplicationManager app; 

    [SetUpFixture]
    public class TestSuiteFixture
    {
        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app =ApplicationManager.GetInstance();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

    }
}
