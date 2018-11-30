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
    public class ContactHelper:HelperBase
    {
      
        public ContactHelper(ApplicationManager manager):base(manager)//конструктор хелпера
        {
            
        }

        private List<ContactData> contactCache = null;

       public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//*[@id='maintable']/tbody/tr[@name='entry']")); //ICollection это более общий тип в отличие от списка
                foreach (IWebElement element in elements)
                 {
                    string firstName = element.FindElement(By.XPath("./td[3]")).Text;
                    string lastName = element.FindElement(By.XPath("./td[2]")).Text;
                    string Id = element.FindElement(By.TagName("input")).GetAttribute("id");
                    contactCache.Add(new ContactData(firstName, lastName)
                       { Id = element.FindElement(By.TagName("input")).GetAttribute("id") });

            
                 }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactForm();
            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//*[@id='maintable']/tbody/tr[@name='entry']")).Count;
        }

        public ContactHelper Modify(int index, ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(index);
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
            contactCache = null;
            manager.Navigator.OpenHomePage();
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
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
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

        public bool CheckContactExistence()
        {
            return IsElementPresent(By.Name("entry"));
        }

    }
}
