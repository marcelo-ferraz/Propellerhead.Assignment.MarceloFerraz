using NUnit.Framework;
using Propellerhead.Assignment.MarceloFerraz.Core.Commons;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Propellerhead.Assignment.MarceloFerraz.Core.UnitTests.Customers.Models
{
    public class CustomerTests: BaseTest
    {
        [Test]
        public void Validate_with_invalid_status()
        {
            var customer = new Customer();

            customer.Id = random.Next(1);
            customer.Status = CustomerStatus.None;

            AssertShouldThrow<BusinessException>(() => customer.Validate(), Customer.InvalidStatusMessage);
        }
        
        [Test]
        public void Validate_with_null_name()
        {
            var customer = new Customer();

            customer.Id = random.Next(1);
            customer.Status = (CustomerStatus)random.Next(0, 2);
            customer.Name = null;

            AssertShouldThrow<BusinessException>(() => customer.Validate(), Customer.NullOrEmptyNameMessage);
        }

        [Test]
        public void Validate_with_empty_name()
        {
            var customer = new Customer();

            customer.Id = random.Next(1);
            customer.Status = (CustomerStatus)random.Next(0, 2);
            customer.Name = string.Empty;

            AssertShouldThrow<BusinessException>(() => customer.Validate(), Customer.NullOrEmptyNameMessage);
        }

    }
}
