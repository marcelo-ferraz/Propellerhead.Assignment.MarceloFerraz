using System;
using System.Collections.Generic;
using System.Text;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Commons
{
    public class BaseRepositoryWithDapper
    {
        static BaseRepositoryWithDapper()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}