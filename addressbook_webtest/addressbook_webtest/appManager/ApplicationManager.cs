using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        
        protected LoginHelper loginHelper; //объявление переменной с типом LoginHelper
        protected NavigationHelper navigationHelper; //объявление переменной для хелпера
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>(); //специальный объект, который будет утсанавливать соответствие между текущим потоком и типом ApplicationManager


        private ApplicationManager()//конструктор
        {
            
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            baseURL = "http://localhost:8080";

            //код инициализации хелперов
            loginHelper = new LoginHelper(this); //код, создающий хелпер
            navigationHelper = new NavigationHelper(this, baseURL); //инициализация хелпера
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

         ~ApplicationManager()//деструктор, используется вместо  Stop для остановки потока; вызывается автоматически, поэтому не нужно писать модификатор видимости  к нему
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
                
                //app.Value = new ApplicationManager();
            }

            return app.Value;
        }

      
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;

            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}
