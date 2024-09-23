using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text.Json;

namespace Notes.Models
{
    public class ScrapFilesService : IScrapService
    {

        /// <summary>
        /// このクラスのインスタンスを生成します。生成時、すべてのファイルを格納するためのルートディレクトリと、ルートディレクトリの情報を記録するテキストファイルを一緒に生成します。
        /// </summary>
        /// <param name="rootDirectoryInfoWrapper">すべてのファイルを格納するためのルートディレクトリの情報を入力します。</param>
        /// <param name="folderInformationFile">ルートディレクトリの情報が書かれたテキストファイルの情報を入力します。</param>
        public ScrapFilesService(IDirectoryInfo rootDirectoryInfoWrapper, IFileInfo folderInformationFile)
        {
            RootDirectoryInfo = rootDirectoryInfoWrapper;
            if (!RootDirectoryInfo.Exists)
            {
                RootDirectoryInfo.Create();
            }

            CurrentDirectory = RootDirectoryInfo;

            if (folderInformationFile.Exists)
            {
                return;
            }

            using var sr = folderInformationFile.CreateText();
            sr.Write("Folder Information");
        }

        private IDirectoryInfo RootDirectoryInfo { get; set; }

        public IDirectoryInfo CurrentDirectory { get; set; }

        public IEnumerable<Scrap> GetScraps()
        {
            throw new System.NotImplementedException();
        }

        public void AddScrap(Scrap scrap, IFileInfo fileInfo)
        {
            var jsonString = JsonSerializer.Serialize(scrap, new JsonSerializerOptions { WriteIndented = true, });
            using var sr = fileInfo.CreateText();
            sr.Write(jsonString);
        }
    }
}