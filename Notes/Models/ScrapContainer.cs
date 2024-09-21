using System.Collections.ObjectModel;

namespace Notes.Models
{
    public class ScrapContainer
    {
        public ScrapContainer()
        {
            CursorManager = new CursorManager
            {
                Items = Scraps,
            };
        }

        public ObservableCollection<Scrap> Scraps { get; private set; } = new ();

        public CursorManager CursorManager { get; set; }
    }
}