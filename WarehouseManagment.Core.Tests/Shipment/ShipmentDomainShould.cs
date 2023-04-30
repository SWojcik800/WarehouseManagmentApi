using System;
using System.Collections.Generic;
using WarehouseManagment.Core.Exceptions;
using WarehouseManagment.Core.Shipment;
using Xunit;

namespace WarehouseManagment.Core.Tests.Shipment
{
    public class ShipmentDomainShould
    {
        [Fact]
        public void AcceptShouldThrowWhenProductsAreEmpty()
        {
            var shipment = new ShipmentDomain(1, new List<ShipmentProduct>(), DateTime.Now);

            Assert.Throws<DomainException>(() => shipment.Accept());
        }

        [Fact]
        public void AcceptShouldThrowWhenProductsCountEqualsZero()
        {
            var products = new List<ShipmentProduct>()
            {
                new ShipmentProduct(1, "ProductName", "ProductDesc", "ManufacturerName", 0),
                new ShipmentProduct(1, "ProductName1", "ProductDesc1", "ManufacturerName1", 0)
            };
            var shipment = new ShipmentDomain(1, products, DateTime.Now);

            Assert.Throws<DomainException>(() => shipment.Accept());
        }

        [Fact]
        public void IssueShouldThrownWhenIssuedToIsNullOrEmpty()
        {
            var products = new List<ShipmentProduct>()
            {
                new ShipmentProduct(1, "ProductName", "ProductDesc", "ManufacturerName", 0),
                new ShipmentProduct(1, "ProductName1", "ProductDesc1", "ManufacturerName1", 0)
            };
            var shipment = new ShipmentDomain(1, products, DateTime.Now);

            Assert.Throws<DomainException>(() => shipment.Issue(""));
            Assert.Throws<DomainException>(() => shipment.Issue(" "));
            Assert.Throws<DomainException>(() => shipment.Issue(string.Empty));
            Assert.Throws<DomainException>(() => shipment.Issue(null));
        }
    }
}
