using System;
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

                //string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;//div#contecnt - блок с нужным нам идентификатором и form
                // string[] parts=allGroupNames.Split('\n');
                //int shift=groupCache.Count-parts.Length;
                //for(int i=0;i<groupCache.Count; i++)
                //{
                //if (i<shift)
                //{
                //    groupCache[i].Name = "";
                //}
                //groupCache[i].Name = parts[i-shift].Trim();  //удалит лишние пробельные символы в начале и в конце
                //}
            }
            return new List<GroupData>(groupCache);//сам кеш возвращать нельзя, нужно возвращать его копию. Новый список посторенный из старого (кеша)
           

        }

        

        public GroupHelper Modify(int index, GroupData groupUpdated)
        {
            manager.Navigator.OpenGroupsPage();
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(groupUpdated);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(GroupData groupToBeUpdated, GroupData groupNew)
        {
            manager.Navigator.OpenGroupsPage();
            SelectGroup(groupToBeUpdated.Id);
            InitGroupModification();
            FillGroupForm(groupNew);
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
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(GroupData toBeRemovedGroup)
        {
            manager.Navigator.OpenGroupsPage();
            SelectGroup(toBeRemovedGroup.Id);
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

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
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

        public bool CheckGroupExistence()
        {
            manager.Navigator.OpenGroupsPage();
            return IsElementPresent(By.ClassName("group"));
            
        }
    }
}
