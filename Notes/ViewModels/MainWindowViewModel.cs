using System.Diagnostics;
using Notes.Models;
using Prism.Mvvm;

namespace Notes.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            SetDummies();
        }

        public TextWrapper TextWrapper { get; set; } = new ();

        public ScrapContainer ScrapContainer { get; private set; } = new();

        [Conditional("DEBUG")]
        private void SetDummies()
        {
            var list = new DummyScrapService().GetScraps();
            foreach (var scrap in list)
            {
                ScrapContainer.Scraps.Add(scrap);
            }
        }
    }
}