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
    public class GroupHelper:HelperBase
    {
       
        public GroupHelper(ApplicationManager manager):base(manager)//конструктор хелпера
        {
            
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.OpenGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache==null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.OpenGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group")); //ICollection это более общий тип в отличие от списка
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)//выбирает текст элемента и помещает в объект типа GroupData
                    {
                        Id= element.FindElement(By.TagName("input")).GetAttribute("value")
                });
                    
                   
                }

            }
            return new List<GroupData>(groupCache);//сам кеш возвращать нельзя, нужно возвращать его копию. Новый список посторенный из старого (кеша)
           

        }


        public GroupHelper Modify(int index, GroupData groupUpdated)
        {
            manager.Navigator.OpenGroupsPage();
            if (! IsElementPresent(By.ClassName("group")))
            {
                InitGroupCreation();
                GroupData group = new GroupData("group_name new");
                group.Header = "group_header new";
                group.Footer = "group_footer new";
                FillGroupForm(group);
                SubmitGroupCreation();
                ReturnToGroupPage();

            }
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(groupUpdated);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.OpenGroupsPage();
            if (!IsElementPresent(By.ClassName("group")))
            {
                InitGroupCreation();
                GroupData group = new GroupData("group_name new");
                group.Header = "group_header new";
                group.Footer = "group_footer new";
                FillGroupForm(group);
                SubmitGroupCreation();
                ReturnToGroupPage();

            }
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }


        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }


        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {

            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        

        public GroupHelper InitGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
