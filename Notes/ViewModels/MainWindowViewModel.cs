using Notes.Models;
using Prism.Mvvm;

namespace Notes.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        public TextWrapper TextWrapper { get; set; } = new ();

        public ScrapContainer ScrapContainer { get; private set; } = new();
    }
}