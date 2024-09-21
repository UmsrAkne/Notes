using Notes.Models;

namespace Notes.ViewModels
{
    public interface IMainWindowViewModel
    {
        public TextWrapper TextWrapper { get; }

        public ScrapContainer ScrapContainer { get; }
    }
}