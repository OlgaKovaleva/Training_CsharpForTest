﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel; //создание короткого префикса

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: GroupTestBase
    {
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv"); //возвращаемое значение - массив
            foreach (string l in lines)
            {
                string[] parts=l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header=parts[1],
                    Footer=parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
            
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));

        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range=sheet.UsedRange;
            for (int i=1; i<=range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;


        }

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0;i<5;i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header= GenerateRandomString(100),
                    Footer= GenerateRandomString(100)

                });
            }
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void GroupCreationTest(GroupData group)
        {
           
            
            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            
            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());


            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            
            
        }

        [Test]
        public void TestDBConnectivity()
        {
            //DateTime start = DateTime.Now;
            //List<GroupData> fromUi = app.Groups.GetGroupList();
            //DateTime finish = DateTime.Now;
            //System.Console.Out.WriteLine("From browser: "+finish.Subtract(start));

            //start = DateTime.Now;
            //List<GroupData> fromDb = GroupData.GetAll();
            //finish = DateTime.Now;
            //System.Console.Out.WriteLine("From DB: " + finish.Subtract(start));
            int groupCount = GroupData.GetAll().Count;
            System.Console.Out.Write(groupCount);
            foreach (GroupData group in GroupData.GetAll())
            {
                int contactCountOfGroup = group.GetContacts().Count;
                if (contactCountOfGroup > 0)
                { System.Console.Out.Write(group.Id); }
                else break;
            }



            //foreach (ContactData contact in GroupData.GetAll()[0].GetContacts())
            //{
            //    System.Console.Out.Write("Контакты " + contact);
            //}




            //List<GroupData> groups = GroupData.GetAll();
            //int groupCount = groups.Count;
            //GroupData group = new GroupData();
            //group.Id=53

            //for (int i=0;i<groupCount; i++)
            //{
            //    if (groups[i].GetContacts().Count>1)
            //    {
            //        System.Console.Out.WriteLine(groups[i].Id);
            //    }
            //}
           
           






        }



    }
}
