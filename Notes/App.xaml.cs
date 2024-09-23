using System.IO;
using System.IO.Abstractions;
using System.Windows;
using Notes.Models;
using Notes.Views;
using Prism.Ioc;

namespace Notes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            const string folderName = "ScrapFiles";
            containerRegistry.RegisterInstance<IScrapService>(new ScrapFilesService(
                new DirectoryInfoWrapper(new FileSystem(), new DirectoryInfo(folderName)),
                new FileInfoWrapper(new FileSystem(), new FileInfo($"{folderName}\\.groupInfo"))));
        }
    }
}