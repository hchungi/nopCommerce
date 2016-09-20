﻿using System;
using Nop.Core.Domain.Logging;
using Nop.Tests;
using NUnit.Framework;

namespace Nop.Data.Tests.Logging
{
    [TestFixture]
    public class LogPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_log()
        {
            var log = TestsData.GetLog;

            var fromDb = SaveAndLoadEntity(log);
            fromDb.ShouldNotBeNull();
            fromDb.LogLevel.ShouldEqual(LogLevel.Error);
            fromDb.ShortMessage.ShouldEqual("ShortMessage1");
            fromDb.FullMessage.ShouldEqual("FullMessage1");
            fromDb.IpAddress.ShouldEqual("127.0.0.1");
            fromDb.PageUrl.ShouldEqual("http://www.someUrl1.com");
            fromDb.ReferrerUrl.ShouldEqual("http://www.someUrl2.com");
            fromDb.CreatedOnUtc.ShouldEqual(new DateTime(2010, 01, 01));
        }

        [Test]
        public void Can_save_and_load_log_with_customer()
        {
            var log = TestsData.GetLog;
            log.Customer = TestsData.GetCustomer();

            var fromDb = SaveAndLoadEntity(log);
            fromDb.ShouldNotBeNull();
            fromDb.LogLevel.ShouldEqual(LogLevel.Error);
            fromDb.CreatedOnUtc.ShouldEqual(new DateTime(2010, 01, 01));
            
            fromDb.Customer.ShouldNotBeNull();
            fromDb.Customer.AdminComment.ShouldEqual("some comment here");
        }
    }
}
