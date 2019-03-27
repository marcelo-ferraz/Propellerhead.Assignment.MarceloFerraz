
using Propellerhead.Assignment.MarceloFerraz.Core.Notes.Models;
using System.Threading.Tasks;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Notes
{
    public interface INotesService
    {
        int Create(Note customer);
        void Update(Note customer);
    }
}