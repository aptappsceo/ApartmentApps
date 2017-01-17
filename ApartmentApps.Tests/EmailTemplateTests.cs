using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ApartmentApps.Api;
using ApartmentApps.Modules.Prospect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace ApartmentApps.Tests
{
    [TestClass]
    public class EmailTemplateTests : PropertyTest
    {
        [TestInitialize]
        public override void Init()
        {
            base.Init();
        }
        [TestMethod]
        public void Test()
        {
            var alertsModule = Context.Kernel.Get<AlertsModule>();
        
            alertsModule.SendUserEngagementLetter(Context.UserContext.CurrentUser);


        }

       

        [TestCleanup]
        public override void DeInit()
        {
            base.DeInit();
        }
    }

   
}