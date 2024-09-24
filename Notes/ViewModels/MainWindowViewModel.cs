using System.Diagnostics;
using Notes.Models;
using Notes.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Notes.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDialogService dialogService;

        public MainWindowViewModel(IScrapService scrapService, IContainerProvider containerProvider, IDialogService dialogService)
        {
            ScrapContainer = containerProvider.Resolve<ScrapContainer>();
            SetDummies();
            ScrapContainer.ScrapService = scrapService;
            this.dialogService = dialogService;
        }

        public TextWrapper TextWrapper { get; set; } = new ();

        public ScrapContainer ScrapContainer { get; private set; }

        public DelegateCommand CreateScrapCommand => new DelegateCommand(() =>
        {
            dialogService.ShowDialog(nameof(ScrapCreationPage), new DialogParameters(), _ => { });
        });

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