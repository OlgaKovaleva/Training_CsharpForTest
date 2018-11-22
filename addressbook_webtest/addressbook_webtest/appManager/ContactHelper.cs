﻿using System;
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
    public class ContactHelper:HelperBase
    {
      
        public ContactHelper(ApplicationManager manager):base(manager)//конструктор хелпера
        {
            
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactForm();
            return this;
        }

        public ContactHelper Modify(int index, ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            FillContactForm(contact);
            UpdateContactForm();
            return this;
        }

        public ContactHelper Remove(int index, bool removalConfirmation)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(index);
            InitContactRemoval();
            ConfirmContactRemoval(removalConfirmation);
            return this;
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//*[@id='maintable']/tbody/tr/td[1])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper InitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ConfirmContactRemoval(bool removalConfirmation)
        {
            
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(removalConfirmation), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        

        public ContactHelper UpdateContactForm()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"),contact.FirstName);
            Type(By.Name("lastname"),contact.LastName);
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

    }
}