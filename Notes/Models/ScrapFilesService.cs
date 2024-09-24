using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
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

        public IDirectoryInfo CurrentDirectory { get; set; }

        private IDirectoryInfo RootDirectoryInfo { get; set; }

        public IEnumerable<Scrap> GetScraps()
        {
            return CurrentDirectory.GetFiles("*.json")
                .OrderBy(f => f.Name)
                .Select(f =>
                {
                    using var reader = f.OpenText();
                    return JsonSerializer.Deserialize<Scrap>(reader.ReadToEnd());
                });
        }

        public void AddScrap(Scrap scrap, IFileInfo fileInfo)
        {
            var jsonString = JsonSerializer.Serialize(scrap, new JsonSerializerOptions { WriteIndented = true, });
            using var sr = fileInfo.CreateText();
            sr.Write(jsonString);
        }

        public int GetMaxId()
        {
            var maxIdObject = RootDirectoryInfo.GetFiles("*.json", SearchOption.AllDirectories)
                .OrderByDescending(f => f.Name)
                .FirstOrDefault();

            if (maxIdObject != null)
            {
                var id = maxIdObject.Name[..4];
                if (int.TryParse(id, out var maxId))
                {
                    return maxId;
                }
            }

            return 0;
        }
    }
}