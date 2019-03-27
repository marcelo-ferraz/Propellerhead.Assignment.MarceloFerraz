using NUnit.Framework;
using Propellerhead.Assignment.MarceloFerraz.Core.Search;
using Propellerhead.Assignment.MarceloFerraz.Core.Search.Model;
using Propellerhead.Assignment.MarceloFerraz.Core.Search.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Propellerhead.Assignment.MarceloFerraz.Core.UnitTests.Search.Data
{
    [TestFixture]
    public class SearchRepositoryTests: BaseTest
    {
        private class SearchRepositoryStub : SearchRepository
        {
            public SearchRepositoryStub(string connectionstring) 
                : base(connectionstring)
            {
            }

            public new CustomerSearchModel AddNotes(CustomerSearchModel customer, IEnumerable<NoteSearchModel> notes)
            {
                return base.AddNotes(customer, notes);
            }
        }

        [Test]
        public void AddNotes_adds_notes_to_Customers()
        {
            var costumerIds = new[] {
                random.Next(),
                random.Next(),
                random.Next()
            };

            var expectedLength = 2;

            var notes = new[] {
                new NoteSearchModel { CustomerId = costumerIds[0] },
                new NoteSearchModel { CustomerId = costumerIds[1] },
                new NoteSearchModel { CustomerId = costumerIds[2] },
                new NoteSearchModel { CustomerId = costumerIds[0] },
                new NoteSearchModel { CustomerId = costumerIds[1] },
                new NoteSearchModel { CustomerId = costumerIds[2] }
            };

            var customer = new CustomerSearchModel { Id = costumerIds[random.Next(0, 3)] };

            var result = new SearchRepositoryStub(null)
                .AddNotes(customer, notes);

            Assert.AreEqual(expectedLength, result.Notes.Length);
        }
    }
}
