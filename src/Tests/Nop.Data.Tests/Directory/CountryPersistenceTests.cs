﻿using System.Linq;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Shipping;
using Nop.Tests;
using NUnit.Framework;

namespace Nop.Data.Tests.Directory
{
    [TestFixture]
    public class CountryPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_country()
        {
            var country = TestsData.GetCountry;

            var fromDb = SaveAndLoadEntity(country);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("United States");
            fromDb.AllowsBilling.ShouldEqual(true);
            fromDb.AllowsShipping.ShouldEqual(true);
            fromDb.TwoLetterIsoCode.ShouldEqual("US");
            fromDb.ThreeLetterIsoCode.ShouldEqual("USA");
            fromDb.NumericIsoCode.ShouldEqual(1);
            fromDb.SubjectToVat.ShouldEqual(true);
            fromDb.Published.ShouldEqual(true);
            fromDb.DisplayOrder.ShouldEqual(1);
            fromDb.LimitedToStores.ShouldEqual(true);
        }

        [Test]
        public void Can_save_and_load_country_with_states()
        {
            var country = TestsData.GetCountry;
            country.StateProvinces.Add(TestsData.GetStateProvince);

            var fromDb = SaveAndLoadEntity(country);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("United States");

            fromDb.StateProvinces.ShouldNotBeNull();
            (fromDb.StateProvinces.Count == 1).ShouldBeTrue();
            fromDb.StateProvinces.First().Name.ShouldEqual("Louisiana");
        }

        [Test]
        public void Can_save_and_load_country_with_restrictions()
        {
            var country = TestsData.GetCountry;

            country.RestrictedShippingMethods.Add(TestsData.GetShippingMethod);
            var fromDb = SaveAndLoadEntity(country);

            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("United States");

            fromDb.RestrictedShippingMethods.ShouldNotBeNull();
            (fromDb.RestrictedShippingMethods.Count == 1).ShouldBeTrue();
            fromDb.RestrictedShippingMethods.First().Name.ShouldEqual("By train");
        }
    }
}
