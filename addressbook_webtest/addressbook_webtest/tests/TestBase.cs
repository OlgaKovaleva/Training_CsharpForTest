﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;


        [SetUp]
        protected void SetupTest()
        {
           app = ApplicationManager.GetInstance();

        }

        
    }
}
