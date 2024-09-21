using System.Collections.ObjectModel;

namespace Notes.Models
{
    public class ScrapContainer
    {
        public ObservableCollection<Scrap> Scraps { get; private set; } = new ();
    }
}