using System.Collections.Generic;
using System.IO.Abstractions;

namespace Notes.Models
{
    public interface IScrapService
    {
        public IDirectoryInfo CurrentDirectory { get; set; }

        public IEnumerable<Scrap> GetScraps();

        public void AddScrap(Scrap scrap, IFileInfo fileInfo);

        public int GetMaxId();
    }
}