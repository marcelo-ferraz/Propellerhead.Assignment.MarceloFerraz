using Moq;
using NUnit.Framework;
using Propellerhead.Assignment.MarceloFerraz.Core.Commons;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Data;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Models;
using Propellerhead.Assignment.MarceloFerraz.Core.Notes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Propellerhead.Assignment.MarceloFerraz.Core.UnitTests.Customers.Models
{
    public class NoteTests: BaseTest
    {
     

        [TestCase]
        public void Validate_with_negative_id()
        {
            var note = new Note(null);

            note.Id = random.Next(-10, 0);

            AssertShouldThrow<BusinessException>(() => note.Validate(), Note.InvalidIdMessage);
        }
        
        [TestCase]
        public void Validate_with_invalid_customer()
        {
            var customerId = 
                random.Next();

            var repositoryMock = 
                new Mock<ICustomerRepository>();

            repositoryMock
                .Setup(r => r.Get(customerId))
                .Returns((Customer)null);

            var note = new Note(repositoryMock.Object);

            note.Id = random.Next(0, 10);

            note.CustomerId = customerId;

            AssertShouldThrow<BusinessException>(() => note.Validate(), Note.CustomerNotFoundMessage);
        }
    }
}
