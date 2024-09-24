using Notes.Models;
using Prism.Commands;

namespace Notes.ViewModels
{
    public interface IMainWindowViewModel
    {
        public TextWrapper TextWrapper { get; }

        public DelegateCommand CreateScrapCommand { get; }

        public ScrapContainer ScrapContainer { get; }
    }
}