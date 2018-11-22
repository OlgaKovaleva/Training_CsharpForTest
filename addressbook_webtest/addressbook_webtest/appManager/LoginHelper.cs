﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class LoginHelper:HelperBase
    {
        
        public LoginHelper(ApplicationManager manager):base(manager)//конструктор хелпера
        {
           
        }

        public LoginHelper Login(AccountData account)
        {
            Type(By.Name("user"),account.Username);
            Type(By.Name("pass"),account.Password);
            driver.FindElement(By.XPath("//html")).Click();
            driver.FindElement(By.XPath("//form[@id='LoginForm']/input[3]")).Click();
            return this;
        }


        public LoginHelper Logout()
        {

            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

    }
}