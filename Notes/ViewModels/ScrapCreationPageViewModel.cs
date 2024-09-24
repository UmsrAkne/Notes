using System;
using Notes.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Notes.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ScrapCreationPageViewModel : BindableBase, IDialogAware
    {
        private readonly ScrapContainer scrapContainer;
        private Scrap scrap = new ();

        public ScrapCreationPageViewModel(IContainerProvider containerProvider)
        {
            scrapContainer = containerProvider.Resolve<ScrapContainer>();
        }

        public event Action<IDialogResult> RequestClose;

        public string Title => string.Empty;

        public Scrap Scrap { get => scrap; private set => SetProperty(ref scrap, value); }

        public DelegateCommand AddScrapCommand => new DelegateCommand(() =>
        {
            scrapContainer.Add(Scrap);
            Scrap = new Scrap();
        });

        public DelegateCommand CloseCommand => new DelegateCommand(() =>
        {
            RequestClose?.Invoke(new DialogResult());
        });

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}