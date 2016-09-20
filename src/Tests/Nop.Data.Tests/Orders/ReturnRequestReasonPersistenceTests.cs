﻿using Nop.Tests;
using NUnit.Framework;

namespace Nop.Data.Tests.Orders
{
    [TestFixture]
    public class ReturnRequestReasonPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_returnRequestReason()
        {
            var returnRequestReason = TestsData.GetReturnRequestReason;

            var fromDb = SaveAndLoadEntity(returnRequestReason);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("Name 1");
            fromDb.DisplayOrder.ShouldEqual(1);
        }
    }
}
