using System.Collections.Generic;
using Propellerhead.Assignment.MarceloFerraz.Core.Search.Models;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Search
{
    public interface ISearchRepository
    {
        IList<CustomerSearchModel> Search(string term);
        CustomerSearchModel Get(int id);
    }
}