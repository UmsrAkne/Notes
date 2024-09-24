using Notes.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace Notes.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DesignTimeMainVm : BindableBase, IMainWindowViewModel
    {
        public DesignTimeMainVm()
        {
            ScrapContainer = new ScrapContainer();
            var list = new DummyScrapService().GetScraps();
            foreach (var scrap in list)
            {
                ScrapContainer.Scraps.Add(scrap);
            }
        }

        public TextWrapper TextWrapper { get; set; } = new ();

        public DelegateCommand CreateScrapCommand { get; }

        public ScrapContainer ScrapContainer { get; set; }
    }
}