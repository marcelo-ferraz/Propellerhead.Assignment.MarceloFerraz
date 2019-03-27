using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Propellerhead.Assignment.MarceloFerraz.Web.Commons
{
    [Serializable]
    public class NewIdResponse
    {
        private int id;

        public NewIdResponse(int id)
        {
            this.id = id;
        }

        public int Id => id;
    }
}
