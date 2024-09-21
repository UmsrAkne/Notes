using Notes.Models;
using Prism.Mvvm;

namespace Notes.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DesignTimeMainVm : BindableBase, IMainWindowViewModel
    {
        public DesignTimeMainVm()
        {
            ScrapContainer = new ScrapContainer();

            for (var i = 0; i < 30; i++)
            {
                ScrapContainer.Scraps.Add(new Scrap
                {
                    IndentCount = 0,
                    Title = $"Title{i + 1}",
                    Description = $"Description{i + 1}",
                    IsMarked = false,
                    Kind = ScrapKind.Text,
                });
            }
        }

        public TextWrapper TextWrapper { get; set; } = new ();

        public ScrapContainer ScrapContainer { get; set; }
    }
}