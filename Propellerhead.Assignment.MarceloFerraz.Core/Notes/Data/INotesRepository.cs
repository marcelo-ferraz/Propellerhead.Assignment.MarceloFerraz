using Propellerhead.Assignment.MarceloFerraz.Core.Notes.Models;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Notes.Data
{
    public interface INotesRepository
    {
        Note Get(int id);
        int Create(Note note);
        void Update(Note note);
    }
}
