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
using System.Globalization;


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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells=driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllTelephones = allPhones,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index+1);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string homeSecondary=driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string addressSecondary = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");
            string birthday=GetContactBirthdayFromForm(index);
            int age = GetContactAgeFromForm(index);
            string anniversary=GetContactAnniversaryFromForm(index);
            int anniversaryPeriod = GetContactAnniversaryPeriodFromForm(index);




            return new ContactData(firstName, lastName)
            {
                Address = address,
                AddressSecondary = addressSecondary,
                MiddleName=middleName,
                Nickname=nickName,
                Company=company,
                Title=title,
                FaxTelephone=fax,
                Homepage=homepage,
                NotesSecondary=notes,
                HomeTelephone = homePhone,
                MobileTelephone = mobilePhone,
                WorkTelephone = workPhone,
                HomeSecondary=homeSecondary,
                Email = email,
                Email2=email2,
                Email3=email3,
                Birthdate=birthday,
                Anniversary=anniversary,
                Age=age,
                AnniversaryPeriod=anniversaryPeriod
            
            };

        }

        public string GetContactBirthdayFromForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
          
            SelectElement selectedBd = new SelectElement(driver.FindElement(By.Name("bday")));
            string selectedBday = selectedBd.SelectedOption.Text;

            if (selectedBday=="-")
            {
                return null;
            }
           
            SelectElement selectedBm = new SelectElement(driver.FindElement(By.Name("bmonth")));
            string selectedBmonth = selectedBm.SelectedOption.Text;

            string selectedByear = driver.FindElement(By.Name("byear")).GetAttribute("value");
           
            DateTime birthdayDate=Convert.ToDateTime(selectedBday+selectedBmonth+selectedByear, CultureInfo.CurrentCulture );

            string birthday = selectedBday + ". " + selectedBmonth + " " + selectedByear;

            return birthday;

        }

        public string GetContactAgeFromForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            SelectElement selectedBd = new SelectElement(driver.FindElement(By.Name("bday")));
            string selectedBday = selectedBd.SelectedOption.Text;

            if (selectedBday == "-")
            {
                return null;
            }

            SelectElement selectedBm = new SelectElement(driver.FindElement(By.Name("bmonth")));
            string selectedBmonth = selectedBm.SelectedOption.Text;
            string selectedByear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            DateTime birthdayDate = Convert.ToDateTime(selectedBday + selectedBmonth + selectedByear, CultureInfo.CurrentCulture);

            int age = DateTime.Today.Year - birthdayDate.Year;
            if (DateTime.Today.DayOfYear < birthdayDate.DayOfYear)
            {
                age = age - 1;
            }
            string ContactAge = age.ToString();
            return ContactAge;
        }

        public string GetContactAnniversaryFromForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            SelectElement selectedAd = new SelectElement(driver.FindElement(By.Name("aday")));
            string selectedAday = selectedAd.SelectedOption.Text;

            if (selectedAday == "-")
            {
                return null;
            }

            SelectElement selectedAm = new SelectElement(driver.FindElement(By.Name("amonth")));
            string selectedAmonth = selectedAm.SelectedOption.Text;
            
            string selectedAyear = driver.FindElement(By.Name("ayear")).GetAttribute("value");


            DateTime anniversaryDate = Convert.ToDateTime(selectedAday + selectedAmonth + selectedAyear, CultureInfo.CurrentCulture);

            string anniversary = selectedAday + ". " + selectedAmonth + " " + selectedAyear;

            return anniversary;
        }

        public string GetContactAnniversaryPeriodFromForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            SelectElement selectedAd = new SelectElement(driver.FindElement(By.Name("aday")));
            string selectedAday = selectedAd.SelectedOption.Text;

            if (selectedAday == "-")
            {
                return null;
            }

            SelectElement selectedAm = new SelectElement(driver.FindElement(By.Name("amonth")));
            string selectedAmonth = selectedAm.SelectedOption.Text;
            string selectedAyear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            DateTime anniversaryDate = Convert.ToDateTime(selectedAday + selectedAmonth + selectedAyear, CultureInfo.CurrentCulture);

            int anniversaryPeriod = DateTime.Today.Year - anniversaryDate.Year;
            if (DateTime.Today.DayOfYear < anniversaryDate.DayOfYear)
            {
                anniversaryPeriod = anniversaryPeriod - 1;
            }
            string ContactAnniversaryPeriod= anniversaryPeriod.ToString();
            return ContactAnniversaryPeriod;
        }

        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactDetails(index);
            string details=driver.FindElement(By.Id("content")).Text;
            return details;



        }

        public ContactHelper InitContactDetails(int index)
        {
              driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"))[6]
                 .FindElement(By.TagName("a")).Click();
            return this;
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
            //SelectContact(index);
            InitContactModification(index);
            FillContactForm(contact);
            UpdateContactForm();
            return this;
        }

        public ContactHelper Remove(int index, bool removalConfirmation)
        {
            manager.Navigator.OpenHomePage();
           // SelectContact(index);
            InitContactRemoval(index);
            ConfirmContactRemoval(removalConfirmation);
            contactCache = null;
            manager.Navigator.OpenHomePage();
            return this;
        }


        //public ContactHelper SelectContact(int index)
       // {
       //     driver.FindElement(By.XPath("(//*[@id='maintable']/tbody/tr/td[1])[" + index + "]")).Click();
       //     return this;
       // }

        public ContactHelper InitContactRemoval(int index)
        {
            driver.FindElement(By.XPath("(//*[@id='maintable']/tbody/tr/td[1])[" + index + "]")).Click();
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
            driver.FindElement(By.XPath("(//*[@id='maintable']/tbody/tr/td[1])[" + (index +1)+ "]")).Click();
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();
          //  driver.FindElements(By.Name("entry"))[index]
          //      .FindElements(By.TagName("td"))[7]
           //     .FindElement(By.TagName("a")).Click;
            return this;

            
        }

        public bool CheckContactExistence()
        {
            return IsElementPresent(By.Name("entry"));
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
