using System;
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
            if (IsLoggedIn())
            {
                if(IsLoggedIn())
                {
                    return this;

                }

                Logout();
            }
            Type(By.Name("user"),account.Username);
            Type(By.Name("pass"),account.Password);
            driver.FindElement(By.XPath("//html")).Click();
            driver.FindElement(By.XPath("//form[@id='LoginForm']/input[3]")).Click();
            return this;
        }

        

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
               
            }

            
        }

       
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
            
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Username;
            
        }

        public string GetLoggedUserName()
        {
            string  text=driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2); //вырезаем текст, начиная с позиции 1 (2й эелемент) и заканчивая предпоследним элементом)
        }
    }
}
