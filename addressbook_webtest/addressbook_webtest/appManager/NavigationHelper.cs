﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper:HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager,string baseURL):base (manager)//конструктор хелпера
        {
            this.baseURL = baseURL;

        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
            
        }

        public void OpenGroupsPage()
        {
            if (driver.Url==baseURL+ "/addressbook/group.php"
                &&IsElementPresent(By.Name("new")))
            {
                return;
            }

            driver.FindElement(By.LinkText("groups")).Click();

        }

    }
}
